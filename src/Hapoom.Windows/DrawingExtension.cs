using System.Windows;
using System.Drawing;

namespace Hapoom.Windows
{
    public static class DrawingExtension
    {
        public static Rect ToRect(this Rectangle r)
        {
            return new Rect(r.X, r.Y, r.Width, r.Height);
        }
    }
}
