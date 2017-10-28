using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Hapoom.Windows
{
    public static partial class ResourceKeys
    {
        static IEnumerable<ResourceKey> _all;
        public static IEnumerable<ResourceKey> All
        {
            get
            {
                if (_all == null)
                    _all = typeof(ResourceKeys)
                                .GetProperties()
                                .Where (x => x.PropertyType == typeof(ResourceKey))
                                .Select(x => x.GetValue(null, null) as ResourceKey);
                return _all;
            }
        }

        private static ComponentResourceKey CreateKey<T>([CallerMemberName] string propertyName = null)
            => new ComponentResourceKey(typeof(T), propertyName);
    }
}
