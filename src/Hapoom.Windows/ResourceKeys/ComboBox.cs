using System.Drawing;
using System.Windows;

namespace Hapoom.Windows
{
    public static partial class ResourceKeys
    {
        public static ResourceKey ComboBoxForegroundKey        { get; } = CreateKey<Brush>();
        public static ResourceKey ComboBoxBackgroundKey        { get; } = CreateKey<Brush>();
        public static ResourceKey ComboBoxBorderBrushKey       { get; } = CreateKey<Brush>();
        public static ResourceKey ComboBoxPopupBorderBrushKey  { get; } = CreateKey<Brush>();
    }
}
