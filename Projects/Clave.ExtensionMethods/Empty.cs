using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Clave.ExtensionMethods
{
    public static class Empty
    {
        /**
         * Get an empty ReadOnlyCollection. The same instance is returned each time, per type T
         */
        public static IReadOnlyCollection<T> ReadOnlyCollection<T>() => Singleton<T>.Instance;

        /**
         * Get an empty ReadOnlyList. The same instance is returned each time, per type T
         */
        public static IReadOnlyList<T> ReadOnlyList<T>() => Singleton<T>.Instance;

        /**
         * Get an empty array. The same instance is returned each time, per type T
         */
        public static T[] Array<T>() => Singleton<T>.Instance;

        /**
         * Get an empty ReadOnlyDictionary. The same instance is returned each time, per type TKey and TValue
         */
        public static IReadOnlyDictionary<TKey, TValue> ReadOnlyDictionary<TKey, TValue>() => Singleton<TKey, TValue>.Instance;

        /**
         * Get an empty string
         */
        public static string String => string.Empty;

        /**
         * Get an empty enumerable
         */
        public static IEnumerable<T> Enumerable<T>() => System.Linq.Enumerable.Empty<T>();

        private static class Singleton<T>
        {
            public static T[] Instance { get; } = new T[0];
        }
        private static class Singleton<TKey, TValue>
        {
            public static IReadOnlyDictionary<TKey, TValue> Instance { get; } = new Dictionary<TKey, TValue>();
        }
    }
}