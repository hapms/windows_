using System.Drawing;
using System.Windows;

namespace Hapoom.Windows
{
    public static partial class ResourceKeys
    {
        public static ResourceKey WindowDropShadowColorKey         { get; } = CreateKey<Color>();
        public static ResourceKey WindowDropShadowInActiveColorKey { get; } = CreateKey<Color>();
        public static ResourceKey WindowLogoBackgroundKey          { get; } = CreateKey<Brush>();
        public static ResourceKey WindowBackgroundKey              { get; } = CreateKey<Brush>();
        public static ResourceKey WindowBorderKey                  { get; } = CreateKey<Brush>();
        public static ResourceKey WindowBorderInActiveKey          { get; } = CreateKey<Brush>();
        public static ResourceKey WindowTitleBorderKey             { get; } = CreateKey<Brush>();
        public static ResourceKey WindowTitleForegroundKey         { get; } = CreateKey<Brush>();
        public static ResourceKey WindowTitleBackgroundKey         { get; } = CreateKey<Brush>();
    }
}
