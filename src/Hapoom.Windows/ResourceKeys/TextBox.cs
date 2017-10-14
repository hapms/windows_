using System.Drawing;
using System.Windows;

namespace Hapoom.Windows
{
    public static partial class ResourceKeys
    {
        public static ResourceKey TextBoxForegroundKey { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(TextBoxForegroundKey));

        public static ResourceKey TextBoxBackgroundKey { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(TextBoxBackgroundKey));

        public static ResourceKey TextBoxBorderBrushKey { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(TextBoxBorderBrushKey));

        public static ResourceKey TextBoxCaretBrushKey { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(TextBoxCaretBrushKey));

        public static ResourceKey TextBoxSelectionBrushKey { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(TextBoxSelectionBrushKey));
    }
}
