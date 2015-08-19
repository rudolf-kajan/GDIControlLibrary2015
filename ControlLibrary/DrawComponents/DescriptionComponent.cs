using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlLibrary.DrawComponents
{
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
}
