using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;

namespace DAL
{
    public static class CacheExtensions
    {
        private static object _myLock = new object();

        public static T GetOrSet<T>(this Cache cache, string key, Item item)
        {
            object value;

            if ((value = cache.Get(key)) == null)
            {
                lock (_myLock)
                {
                    if ((value = cache.Get(key)) == null)
                    {
                        value = item;
                        cache.Insert(key, value, null,
                         DateTime.Now.AddHours(3), Cache.NoSlidingExpiration,
                         CacheItemPriority.Normal, null);
                    }
                }
            }
            return (T)value;
        }
        public static void Invalidate(this Cache cache, params string[] tags)
        {
            long version = DateTime.UtcNow.Ticks;
            for (int i = 0; i < tags.Length; ++i)
            {
                cache.Insert("_tag:" + tags[i], version, null,
                  DateTime.MaxValue, Cache.NoSlidingExpiration,
                  CacheItemPriority.NotRemovable, null);
            }
        }
    }
}
