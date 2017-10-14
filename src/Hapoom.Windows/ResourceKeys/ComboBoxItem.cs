using System.Drawing;
using System.Windows;

namespace Hapoom.Windows
{
    public static partial class ResourceKeys
    {
        public static ResourceKey ComboBoxItemForegroundKey { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(ComboBoxItemForegroundKey));

        public static ResourceKey ComboBoxItemForegroundMouseOverKey { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(ComboBoxItemForegroundMouseOverKey));

        public static ResourceKey ComboBoxItemForegroundSelectedKey { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(ComboBoxItemForegroundSelectedKey));

        public static ResourceKey ComboBoxItemBackgroundKey { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(ComboBoxItemBackgroundKey));

        public static ResourceKey ComboBoxItemBackgroundMouseOverKey { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(ComboBoxItemBackgroundMouseOverKey));

        public static ResourceKey ComboBoxItemBackgroundSelectedKey { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(ComboBoxItemBackgroundSelectedKey));
    }
}
