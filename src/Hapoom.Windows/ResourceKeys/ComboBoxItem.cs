using System.Drawing;
using System.Windows;

namespace Hapoom.Windows
{
    public static partial class ResourceKeys
    {
        public static ResourceKey ComboBoxItemForegroundKey          { get; } = CreateKey<Brush>();
        public static ResourceKey ComboBoxItemForegroundMouseOverKey { get; } = CreateKey<Brush>();
        public static ResourceKey ComboBoxItemForegroundSelectedKey  { get; } = CreateKey<Brush>();
        public static ResourceKey ComboBoxItemBackgroundKey          { get; } = CreateKey<Brush>();
        public static ResourceKey ComboBoxItemBackgroundMouseOverKey { get; } = CreateKey<Brush>();
        public static ResourceKey ComboBoxItemBackgroundSelectedKey  { get; } = CreateKey<Brush>();
    }
}
