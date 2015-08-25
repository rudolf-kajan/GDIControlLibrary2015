
using System.Drawing;
using System.Windows.Forms;

namespace ControlLibrary.DrawComponents
{
    static class Utils
    {
        public static bool IsInputStartInBounds(DrawComponent drawComponent, MouseEventArgs mouseEventArgs)
        {
            return ((mouseEventArgs.X >= drawComponent.Offset.X && mouseEventArgs.X <= drawComponent.Offset.X + drawComponent.Size.Width)
                && (mouseEventArgs.Y >= drawComponent.Offset.Y && mouseEventArgs.Y <= drawComponent.Offset.Y + drawComponent.Size.Height));
        }
    }
}
