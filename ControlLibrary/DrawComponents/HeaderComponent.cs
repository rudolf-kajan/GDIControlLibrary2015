using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlLibrary.DrawComponents
{
    /// <summary>
    /// Simple header/footer
    /// </summary>
    class HeaderComponent : DrawComponent
    {
        public HeaderComponent()
        {
            Size = new Size(Size.Width, 12);
            Margin = Padding.Empty;
        }

        public override void OnPaint(PaintEventArgs pe, ISkinProvider skin)
        {
            pe.Graphics.FillRectangle(skin.AccentColor, new Rectangle(Offset.X, Offset.Y, Size.Width, Size.Height));
        }
    }
}
