using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlLibrary.DrawComponents
{
    class ImageGalleryPreviewComponent : DrawComponent, IInputEnabled
    {
        public List<Image> Icons;

        private int _horizContentOffset = -45;

        public ImageGalleryPreviewComponent()
        {
            Size.Height = 96;
        }

        public override void OnPaint(PaintEventArgs pe, ISkinProvider skin)
        {
            for (int i = 0; i < Icons.Count; i++)
            {
                Image image = Icons[i];
                pe.Graphics.DrawImage(image, new Rectangle(
                        (Margin.Left + _horizContentOffset + i * 100),            // X
                        Offset.Height + Margin.Top,         // Y
                        90,                                 // Width
                        Size.Height - 2 * Margin.Top));     // Height
            }
        }

        private void SetContentOffset(int offsetDelta)
        {
            _horizContentOffset += offsetDelta;
        }

        public InputResult OnInput(InputType inputType, MouseEventArgs beginArgs, MouseEventArgs endArgs, object args)
        {
            if (inputType != InputType.Drag)
                return InputResult.Bubble;

            if ((args as DragDirection? ?? DragDirection.Left) == DragDirection.Left)
            {
                SetContentOffset(endArgs.X - beginArgs.X);
            }

            if ((args as DragDirection? ?? DragDirection.Left) == DragDirection.Right)
            {
                SetContentOffset(endArgs.X - beginArgs.X);
            }

            return InputResult.Consumed;
        }

        
    }
}
