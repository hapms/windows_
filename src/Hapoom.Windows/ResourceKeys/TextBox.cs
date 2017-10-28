using System.Drawing;
using System.Windows;

namespace Hapoom.Windows
{
    public static partial class ResourceKeys
    {
        public static ResourceKey TextBoxForegroundKey     { get; } = CreateKey<Brush>();
        public static ResourceKey TextBoxBackgroundKey     { get; } = CreateKey<Brush>();
        public static ResourceKey TextBoxBorderBrushKey    { get; } = CreateKey<Brush>();
        public static ResourceKey TextBoxCaretBrushKey     { get; } = CreateKey<Brush>();
        public static ResourceKey TextBoxSelectionBrushKey { get; } = CreateKey<Brush>();
    }
}
