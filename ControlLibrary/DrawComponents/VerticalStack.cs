using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlLibrary.DrawComponents
{
    /// <summary>
    /// Virtual control responsible for stacking
    /// up other elements in a single column
    /// </summary>
    class VerticalStack : DrawComponent, IInputEnabled, IComponentContainer
    {
        private readonly List<DrawComponent> _drawComponents;
        private int _heightOfAllChildren;

        private int _scrollOffset = 0;

        public VerticalStack(Size size)
        {
            _drawComponents = new List<DrawComponent>(10);
            Size = size;
        }

        public void SetContentOffset(int contentOffset)
        {
            // prevents scrolling past content borders
            if (_scrollOffset + contentOffset > 0)
                return;

            if (_scrollOffset + contentOffset <= Size.Height - _heightOfAllChildren)
                return;
            ///////////////////////////////////////////

            _scrollOffset += contentOffset;

            foreach (DrawComponent drawComponent in _drawComponents)
                drawComponent.Offset.Height += contentOffset;
        }

        public void AddChild(DrawComponent drawComponent)
        {
            drawComponent.Offset.Height = _heightOfAllChildren;
            drawComponent.Resize(new Size(Size.Width, drawComponent.Size.Height));

            _drawComponents.Add(drawComponent);
            _heightOfAllChildren += drawComponent.Size.Height;
        }

        public override void OnPaint(PaintEventArgs pe, ISkinProvider skin)
        {
            pe.Graphics.FillRectangle(skin.Background, new Rectangle(Offset.Width, Offset.Height, Size.Width, Size.Height));

            foreach (DrawComponent drawComponent in _drawComponents)
                drawComponent.OnPaint(pe, skin);
        }

        public InputResult OnInput(InputType inputType, MouseEventArgs beginArgs, MouseEventArgs endArgs, object args)
        {
            foreach (DrawComponent drawComponent in _drawComponents)
            {
                if (drawComponent is IInputEnabled && Utils.IsInputStartInBounds(drawComponent, beginArgs))
                {
                    InputResult result = (drawComponent as IInputEnabled).OnInput(inputType, beginArgs, endArgs, args);

                    if (result == InputResult.Consumed)
                        return InputResult.Consumed;
                }
            }

            // try to consume the gesture by myself
            if (inputType == InputType.Drag)
            {
                if ((args as DragDirection? ?? DragDirection.Left) == DragDirection.Down)
                    SetContentOffset(endArgs.Y - beginArgs.Y);

                if ((args as DragDirection? ?? DragDirection.Left) == DragDirection.Up)
                    SetContentOffset(endArgs.Y - beginArgs.Y);

                return InputResult.Consumed;
            }

            return InputResult.Bubble;
        }
    }
}
