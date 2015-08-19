using System.Drawing;
using System.Windows.Forms;

namespace ControlLibrary.DrawComponents
{
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
