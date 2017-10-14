using System.Drawing;
using System.Windows;

namespace Hapoom.Windows
{
    public static partial class ResourceKeys
    {
        public static ResourceKey ScrollBarThumbBackgroundKey { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(ScrollBarThumbBackgroundKey));
    }
}
