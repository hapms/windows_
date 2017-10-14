using System.Drawing;
using System.Windows;

namespace Hapoom.Windows
{
    public static partial class ResourceKeys
    {
        public static ResourceKey BusyIndicatorForegroundKey { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(BusyIndicatorForegroundKey));
    }
}
