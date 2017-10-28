using System.Drawing;
using System.Windows;

namespace Hapoom.Windows
{
    public static partial class ResourceKeys
    {
        public static ResourceKey CheckBoxBackgroundKey { get; } = CreateKey<Brush>();
        public static ResourceKey CheckBoxForegroundKey  { get; } = CreateKey<Brush>();
        public static ResourceKey CheckBoxBorderBrushKey { get; } = CreateKey<Brush>();

        public static ResourceKey CheckMarkForegroundKey { get; } = CreateKey<Brush>();
        public static ResourceKey CheckMarkBackgroundKey { get; } = CreateKey<Brush>();
        public static ResourceKey CheckMarkUnCheckedForegroundKey { get; } = CreateKey<Brush>();
        public static ResourceKey CheckMarkUnCheckedBackgroundKey { get; } = CreateKey<Brush>();
        public static ResourceKey CheckMarkBorderBrushKey { get; } = CreateKey<Brush>();
        public static ResourceKey CheckMarkBorderBrushMouseOverKey { get; } = CreateKey<Brush>();
        public static ResourceKey CheckMarkBorderBrushCheckedKey { get; } = CreateKey<Brush>();
    }
}
