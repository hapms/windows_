using System.Drawing;
using System.Windows;

namespace Hapoom.Windows
{
    public static partial class ResourceKeys
    {
        public static ResourceKey ControlBoxForeground { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(ControlBoxForeground));

        public static ResourceKey ControlBoxForegroundMouseOver { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(ControlBoxForegroundMouseOver));

        public static ResourceKey ControlBoxForegroundPressed { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(ControlBoxForegroundPressed));

        public static ResourceKey ControlBoxBackground { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(ControlBoxBackground));

        public static ResourceKey ControlBoxBackgroundMouseOver { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(ControlBoxBackgroundMouseOver));

        public static ResourceKey ControlBoxBackgroundPressed { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(ControlBoxBackgroundPressed));

        public static ResourceKey ControlBoxForegroundMouseOverClose { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(ControlBoxForegroundMouseOverClose));

        public static ResourceKey ControlBoxForegroundPressedClose { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(ControlBoxForegroundPressedClose));

        public static ResourceKey ControlBoxBackgroundMouseOverClose { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(ControlBoxBackgroundMouseOverClose));

        public static ResourceKey ControlBoxBackgroundPressedClose { get; set; }
            = new ComponentResourceKey(typeof(Brush), nameof(ControlBoxBackgroundPressedClose));
    }
}
