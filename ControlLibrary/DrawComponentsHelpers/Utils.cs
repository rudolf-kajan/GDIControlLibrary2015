using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlLibrary.DrawComponents
{
    static class Utils
    {
        public static bool IsInputStartInBounds(DrawComponent drawComponent, MouseEventArgs mouseEventArgs)
        {
            return ((mouseEventArgs.X >= drawComponent.Offset.Width && mouseEventArgs.X <= drawComponent.Offset.Width + drawComponent.Size.Width)
                && (mouseEventArgs.Y >= drawComponent.Offset.Height && mouseEventArgs.Y <= drawComponent.Offset.Height + drawComponent.Size.Height));
        }
    }
}
