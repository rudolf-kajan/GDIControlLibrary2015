using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ControlLibrary.DrawComponents
{
    public enum ToggleStateEnum
    {
        On,
        Off
    };

    public enum InputResult
    {
        Bubble,
        Consumed,
    }

    public interface IInputEnabled
    {
        InputResult OnInput(InputType inputType, MouseEventArgs beginArgs, MouseEventArgs endArgs, object args);

        void ChangeFocus(bool isFocused);
    }

    public interface IComponentContainer
    {
        void AddChild(DrawComponent drawComponent);
        void ClearChildren();
        void RecalculateComponentsLayout();
    }


    /// <summary>
    /// Base class for all 
    /// other drawable elements
    /// </summary>
    public abstract class DrawComponent
    {
        protected bool IsFocused;
        
        private Size _size;
        public Size Size
        {
            get { return _size; }
            set { _size = value; OnResize(); }
        }

        private Point _offset;
        public Point Offset
        {
            get { return _offset; }
            set
            {
                OnReposition(value - (Size)_offset);
                _offset = value;
            }
        }

        private Padding _margin = new Padding(10);
        public Padding Margin
        {
            get { return _margin; }
            set { _margin = value; OnRemargin(); }
        }

        public IComponentContainer ParentContainer;

        protected virtual void OnResize() { }

        protected virtual void OnReposition(Point point) { }

        protected virtual void OnRemargin() { }

        public byte ZOrder { get; set; }

        public abstract void OnPaint(PaintEventArgs pe, ISkinProvider skin);
    }
}
