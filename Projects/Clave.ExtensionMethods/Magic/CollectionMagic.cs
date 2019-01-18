using System.Collections.Generic;

namespace Clave.ExtensionMethods.Magic
{
    public static class CollectionMagic
    {
        public static void Add<T>(this List<T> list, IEnumerable<T> items)
            => list.AddRange(items);

        public static void Add<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IEnumerable<KeyValuePair<TKey, TValue>> items)
        {
            foreach (var item in items)
            {
                dictionary[item.Key] = item.Value;
            }
        }
    }
}