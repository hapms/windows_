using System.Drawing;
using System.Windows;

namespace Hapoom.Windows
{
    public static partial class ResourceKeys
    {
        public static ResourceKey RadioButtonBackgroundKey { get; } = CreateKey<Brush>();
        public static ResourceKey RadioButtonForegroundKey  { get; } = CreateKey<Brush>();
        public static ResourceKey RadioButtonBorderBrushKey { get; } = CreateKey<Brush>();
    }
}
