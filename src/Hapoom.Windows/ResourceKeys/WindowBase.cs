using System.Drawing;
using System.Windows;

namespace Hapoom.Windows
{
    public static partial class ResourceKeys
    {
        public static ResourceKey WindowDropShadowColorKey { get; set; }
            = new ComponentResourceKey(typeof(Color), nameof(WindowDropShadowColorKey));

        public static ResourceKey WindowDropShadowInActiveColorKey { get; set; }
            = new ComponentResourceKey(typeof(Color), nameof(WindowDropShadowInActiveColorKey));

        public static ResourceKey WindowLogoBackgroundKey { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(WindowLogoBackgroundKey));

        public static ResourceKey WindowBackgroundKey { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(WindowBackgroundKey));

        public static ResourceKey WindowBorderKey { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(WindowBorderKey));

        public static ResourceKey WindowBorderInActiveKey { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(WindowBorderInActiveKey));

        public static ResourceKey WindowTitleBorder { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(WindowTitleBorder));

        public static ResourceKey WindowTitleForeground { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(WindowTitleForeground));

        public static ResourceKey WindowTitleBackground { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(WindowTitleBackground));
    }
}
