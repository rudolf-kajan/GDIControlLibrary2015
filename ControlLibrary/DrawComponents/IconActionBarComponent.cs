using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlLibrary.DrawComponents
{
    class IconActionBarComponent : DrawComponent, IInputEnabled
    {
        public List<Image> Icons;
        public List<Action> Actions;

        public IconActionBarComponent()
        {
            Size = new Size(Size.Width, 48);
        }

        public override void OnPaint(PaintEventArgs pe, ISkinProvider skin)
        {
            pe.Graphics.FillRectangle(skin.AccentColor, new Rectangle(0, Offset.Y, pe.ClipRectangle.Width, Offset.Y + Size.Height));

            for (int i = 0; i < Icons.Count; i++)
            {
                Image image = Icons[i];
                pe.Graphics.DrawImage(image, new Rectangle(
                        (10 + i * 72),         // X
                        Offset.Y + 10,         // Y
                        32,                         // Width
                        32));                       // Height
            }
        }

        public InputResult OnInput(InputType inputType, MouseEventArgs beginArgs, MouseEventArgs endArgs, object args)
        {
            if(inputType != InputType.Click)
                return InputResult.Bubble;

            for (int i = 0; i < Icons.Count; i++)
            {

                if (beginArgs.X >= 10 + i*72 && beginArgs.X < 10 + (i + 1)*72)
                {
                    Actions[i].Invoke();
                    return InputResult.Consumed;
                }
            }

            return InputResult.Bubble;
        }
    }
}
