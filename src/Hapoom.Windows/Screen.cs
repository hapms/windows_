using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Forms = System.Windows.Forms;

namespace Hapoom.Windows
{
    public class Screen
    {
        private Screen(Forms.Screen screen)
        {
            IsPrimary   = screen.Primary;
            Name        = screen.DeviceName;
            Bounds      = screen.Bounds.ToRect();
            WorkingArea = screen.WorkingArea.ToRect();
        }

        public static IEnumerable<Screen> AllScreens
        {
            get
            {
                return Forms.Screen
                            .AllScreens
                            .Select(x => new Screen(x))
                            .ToArray();
            }
        }

        public static Screen GetScreen(Window window)
        {
            var windowWidth = window.ActualWidth;
            var windowLeft  = window.Left;
            var windowRight = window.Left + windowWidth;
            foreach (var screen in AllScreens)
            {
                var area  = screen.WorkingArea;
                var right = Math.Min(windowRight, area.Right);
                var left  = Math.Max(windowLeft , area.Left);

                var measured = (right - left) - (windowWidth / 2);
                if (measured > 0)
                    return screen;

                if (measured == 0 && screen.IsPrimary)
                    return screen;
            }
            return AllScreens.Where(x => x.IsPrimary).Single();
        }

        public string Name        { get; private set; }
        public bool   IsPrimary   { get; private set; }
        public Rect   Bounds      { get; private set; }
        public Rect   WorkingArea { get; private set; }
    }
}
