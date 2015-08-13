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
        public Size Offset = Size.Empty;
        public Size Size = new Size(120, 24);
        public Padding Margin = new Padding(10,10,10,10);
        
        public abstract void OnPaint(PaintEventArgs pe, ISkinProvider skin);
        

        public void Resize(Size size)
        {
            Size = size;
        }
    }


    

    /// <summary>
    /// Simple header/footer
    /// </summary>
    class TooltipHeader : DrawComponent
    {
        public TooltipHeader()
        {
            Size.Height = 12;
        }

        public override void OnPaint(PaintEventArgs pe, ISkinProvider skin)
        {
            pe.Graphics.FillRectangle(skin.AccentColor, new Rectangle(0, 0, pe.ClipRectangle.Width, Offset.Height + Size.Height));
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
            Size.Height = 48;
        }

        public override void OnPaint(PaintEventArgs pe, ISkinProvider skin)
        {
            StringFormat drawFormat = new StringFormat();
            pe.Graphics.DrawString(TextLabel, skin.PrimaryFont, skin.PrimaryFontColor, Margin.Left, Offset.Height + Margin.Top, drawFormat);

            Image toggleImage = ToggleState == ToggleStateEnum.On ? Resource.toggle_on : Resource.toggle_off;

            pe.Graphics.DrawImage(toggleImage, new Rectangle
                (Size.Width - toggleImage.Width / 4 - Margin.Right,   // X
                 Offset.Height + Margin.Top,                          // Y
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
            Size.Height = 48;
        }

        public override void OnPaint(PaintEventArgs pe, ISkinProvider skin)
        {
            StringFormat drawFormat = new StringFormat();

            pe.Graphics.DrawString(TextLabel, skin.PrimaryFont, skin.PrimaryFontColor, Margin.Left, Offset.Height + Margin.Top, drawFormat);
            pe.Graphics.DrawString(TextValue, skin.SecondaryFont, skin.SecondaryFontColor, Size.Width - TextRenderer.MeasureText(TextValue, skin.SecondaryFont).Width - Margin.Left, Offset.Height + Margin.Top, drawFormat);

            drawFormat.Dispose();
        }
    }

    class DescriptionComponent : DrawComponent
    {
        public string TextLabel { get; set; }
        public string TextValue { get; set; }

        public DescriptionComponent()
        {
            Size.Height = 196;
        }

        public override void OnPaint(PaintEventArgs pe, ISkinProvider skin)
        {
            StringFormat drawFormat = new StringFormat();

            pe.Graphics.DrawString(TextLabel, skin.PrimaryFont, skin.PrimaryFontColor, Margin.Left, Offset.Height + Margin.Top, drawFormat);
            pe.Graphics.DrawString(TextValue, skin.SecondaryFont, skin.SecondaryFontColor,
                new RectangleF(Margin.Left, Offset.Height + 3 * Margin.Top, Size.Width - Margin.Left, Size.Height - 3 * Margin.Top));

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
                 Offset.Height + Margin.Top,                // Y
                 Icon.Width / 4,                   // Width
                 Icon.Height / 4));                // Height

            pe.Graphics.DrawString(TextLabel, skin.SmallFont, skin.PrimaryFontColor, 4 * Margin.Left, Offset.Height + 1.5f * Margin.Top, drawFormat);
            pe.Graphics.DrawString(TextValue, skin.SmallFont, skin.SecondaryFontColor, 
                Size.Width - TextRenderer.MeasureText(TextValue, skin.SecondaryFont).Width - Margin.Left, Offset.Height + 1.5f * Margin.Top, drawFormat);

            drawFormat.Dispose();
        }
    }
}
