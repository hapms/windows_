using System.Drawing;
using System.Windows;

namespace Hapoom.Windows
{
    public static partial class ResourceKeys
    {
        public static ResourceKey ComboBoxForegroundKey { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(ComboBoxForegroundKey));

        public static ResourceKey ComboBoxBackgroundKey { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(ComboBoxBackgroundKey));

        public static ResourceKey ComboBoxBorderBrushKey { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(ComboBoxBorderBrushKey));

        public static ResourceKey ComboBoxPopupBorderBrushKey { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(ComboBoxPopupBorderBrushKey));
    }
}
