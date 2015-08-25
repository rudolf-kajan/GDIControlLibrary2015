using System.Drawing;
using System.Windows.Forms;

namespace ControlLibrary.DrawComponents
{
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
                (Size.Width - toggleImage.Width / 4 - Margin.Right, // X
                 Offset.Y + Margin.Top,                             // Y
                 toggleImage.Width / 4,                             // Width
                 toggleImage.Height / 4));                          // Height

            //if(IsFocused)
            //    pe.Graphics.FillRectangle(skin.AccentColor, 
            //        new Rectangle( Offset.X + Margin.Left, Offset.Y + Size.Height - 2, Size.Width - (Margin.Left + Margin.Right), 2));

            if (IsFocused)
                pe.Graphics.FillRectangle(skin.AccentColor,
                    new Rectangle(Offset.X + 2, Offset.Y + Margin.Top, 2, Size.Height - (Margin.Bottom + Margin.Top) ));

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

        public void ChangeFocus(bool isFocused)
        {
            IsFocused = isFocused;
        }
    }
}
