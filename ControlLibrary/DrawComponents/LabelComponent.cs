using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlLibrary.DrawComponents
{
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
}
