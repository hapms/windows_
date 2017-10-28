using System.Drawing;
using System.Windows;

namespace Hapoom.Windows
{
    public static partial class ResourceKeys
    {
        public static ResourceKey ControlBoxForegroundKey                { get; } = CreateKey<Brush>();
        public static ResourceKey ControlBoxForegroundMouseOverKey       { get; } = CreateKey<Brush>();
        public static ResourceKey ControlBoxForegroundPressedKey         { get; } = CreateKey<Brush>();
        public static ResourceKey ControlBoxBackgroundKey                { get; } = CreateKey<Brush>();
        public static ResourceKey ControlBoxBackgroundMouseOverKey       { get; } = CreateKey<Brush>();
        public static ResourceKey ControlBoxBackgroundPressedKey         { get; } = CreateKey<Brush>();
        public static ResourceKey ControlBoxForegroundMouseOverCloseKey  { get; } = CreateKey<Brush>();
        public static ResourceKey ControlBoxForegroundPressedCloseKey    { get; } = CreateKey<Brush>();
        public static ResourceKey ControlBoxBackgroundMouseOverCloseKey  { get; } = CreateKey<Brush>();
        public static ResourceKey ControlBoxBackgroundPressedCloseKey    { get; } = CreateKey<Brush>();
    }
}
