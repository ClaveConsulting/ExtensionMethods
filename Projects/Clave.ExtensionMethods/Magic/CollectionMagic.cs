using System.Collections;
using System.Collections.Generic;

namespace Clave.ExtensionMethods.Magic
{
    public static class CollectionMagic
    {
        public static void Add<T>(this ICollection<T> list, IEnumerable<T> items)
        {
            if(items == null)
                return;

            foreach(var item in items)
            {
                list.Add(item);
            }
        }
        
        public static void Add(this IList list, IEnumerable items)
        {
            if(items == null)
                return;

            foreach(var item in items)
            {
                list.Add(item);
            }
        }

        public static void Add<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IEnumerable<KeyValuePair<TKey, TValue>> items)
        {
            if(items == null)
                return;

            foreach (var item in items)
            {
                dictionary[item.Key] = item.Value;
            }
        }
    }
}
