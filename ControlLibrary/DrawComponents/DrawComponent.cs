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
    }

    public interface IComponentContainer
    {

    }


    /// <summary>
    /// Base class for all 
    /// other drawable elements
    /// </summary>
    public abstract class DrawComponent
    {
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

        protected virtual void OnResize() { }

        protected virtual void OnReposition(Point point) { }

        protected virtual void OnRemargin() { }

        public byte ZOrder { get; set; }

        public abstract void OnPaint(PaintEventArgs pe, ISkinProvider skin);
    }

    /// <summary>
    /// Simple header/footer
    /// </summary>
    class TooltipHeader : DrawComponent
    {
        public TooltipHeader()
        {
            Size = new Size(Size.Width, 12);
            Margin = Padding.Empty;
        }

        public override void OnPaint(PaintEventArgs pe, ISkinProvider skin)
        {
            pe.Graphics.FillRectangle(skin.AccentColor, new Rectangle(Offset.X, Offset.Y, Offset.X + Size.Width, Offset.Y + Size.Height));
        }
    }


    /// <summary>
    /// On/Off type of switch
    /// </summary>
    class ToggleComponent : DrawComponent, IInputEnabled
    {
        public string TextLabel { get; set; }
        public ToggleStateEnum ToggleState { get; set; }

        public ToggleComponent()
        {
            Size = new Size(Size.Width, 48);
        }

        public override void OnPaint(PaintEventArgs pe, ISkinProvider skin)
        {
            StringFormat drawFormat = new StringFormat();
            pe.Graphics.DrawString(TextLabel, skin.PrimaryFont, skin.PrimaryFontColor, Margin.Left, Offset.Y + Margin.Top, drawFormat);

            Image toggleImage = ToggleState == ToggleStateEnum.On ? Resource.toggle_on : Resource.toggle_off;

            pe.Graphics.DrawImage(toggleImage, new Rectangle
                (Size.Width - toggleImage.Width / 4 - Margin.Right,   // X
                 Offset.Y + Margin.Top,                          // Y
                 toggleImage.Width / 4,                               // Width
                 toggleImage.Height / 4));                            // Height

            drawFormat.Dispose();
        }

        public InputResult OnInput(InputType inputType, MouseEventArgs beginArgs, MouseEventArgs endArgs, object args)
        {
            if (inputType == InputType.Click)
            {
                ToggleState = ToggleState == ToggleStateEnum.On
                ? ToggleStateEnum.Off
                : ToggleStateEnum.On;

                return InputResult.Consumed;
            }

            return InputResult.Bubble;
        }
    }

    class LabelComponent : DrawComponent
    {
        public string TextLabel { get; set; }
        public string TextValue { get; set; }

        public LabelComponent()
        {
            Size = new Size(Size.Width, 48);
        }

        public override void OnPaint(PaintEventArgs pe, ISkinProvider skin)
        {
            StringFormat drawFormat = new StringFormat();

            pe.Graphics.DrawString(TextLabel, skin.PrimaryFont, skin.PrimaryFontColor, Margin.Left, Offset.Y + Margin.Top, drawFormat);
            pe.Graphics.DrawString(TextValue, skin.SecondaryFont, skin.SecondaryFontColor, Size.Width - TextRenderer.MeasureText(TextValue, skin.SecondaryFont).Width - Margin.Left, Offset.Y + Margin.Top, drawFormat);

            drawFormat.Dispose();
        }
    }

    class DescriptionComponent : DrawComponent
    {
        public string TextLabel { get; set; }
        public string TextValue { get; set; }

        public DescriptionComponent()
        {
            Size = new Size(Size.Width, 196);
        }

        public override void OnPaint(PaintEventArgs pe, ISkinProvider skin)
        {
            StringFormat drawFormat = new StringFormat();

            pe.Graphics.DrawString(TextLabel, skin.PrimaryFont, skin.PrimaryFontColor, Margin.Left, Offset.Y + Margin.Top, drawFormat);
            pe.Graphics.DrawString(TextValue, skin.SecondaryFont, skin.SecondaryFontColor,
                new RectangleF(Margin.Left, Offset.Y + 3 * Margin.Top, Size.Width - Margin.Left, Size.Height - 3 * Margin.Top));

            drawFormat.Dispose();
        }
    }

    class IconLabelComponent : LabelComponent
    {
        public Image Icon;

        public override void OnPaint(PaintEventArgs pe, ISkinProvider skin)
        {
            StringFormat drawFormat = new StringFormat();

            pe.Graphics.DrawImage(Icon, new Rectangle
                (Margin.Left,                          // X
                 Offset.Y + Margin.Top,                // Y
                 Icon.Width / 4,                   // Width
                 Icon.Height / 4));                // Height

            pe.Graphics.DrawString(TextLabel, skin.SmallFont, skin.PrimaryFontColor, 4 * Margin.Left, Offset.Y + 1.5f * Margin.Top, drawFormat);
            pe.Graphics.DrawString(TextValue, skin.SmallFont, skin.SecondaryFontColor,
                Size.Width - TextRenderer.MeasureText(TextValue, skin.SecondaryFont).Width - Margin.Left, Offset.Y + 1.5f * Margin.Top, drawFormat);

            drawFormat.Dispose();
        }
    }
}
