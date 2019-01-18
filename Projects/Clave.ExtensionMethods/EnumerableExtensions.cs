using System;
using System.Collections.Generic;
using System.Linq;

namespace Clave.ExtensionMethods
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Returns an enumerable containing only a single item
        /// </summary>
        public static IEnumerable<T> Only<T>(this T item)
        {
            yield return item;
        }

        /// <summary>
        /// Returns an enumerable of the initial item and other items
        /// </summary>
        public static IEnumerable<T> And<T>(this T initial, params T[] items)
        {
            yield return initial;
            foreach (var item in items)
            {
                yield return item;
            }
        }

        /// <summary>
        /// Returns true if the enumerable is empty
        /// </summary>
        public static bool NotAny<T>(this IEnumerable<T> source)
            => !source.Any();

        /// <summary>
        /// Returns true if the predicate does not return true for any of the items in the enumerable
        /// </summary>
        public static bool NotAny<T>(this IEnumerable<T> source, Func<T, bool> predicate)
            => !source.Any(predicate);

        /// <summary>
        /// Returns an enumerable containing only the items of the source that don't match the predicate
        /// </summary>
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> source, Func<T, bool> predicate)
            => source.Where(x => !predicate(x));

        /// <summary>
        /// Returns an enumerable containing only non-null items
        /// </summary>
        public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T> source)
            where T : class
            => source.WhereNot(x => x is null);

        /// <summary>
        /// Returns an enumerable containing only items where the map function returns a non-null value
        /// </summary>
        public static IEnumerable<T> WhereNotNull<T, TKey>(this IEnumerable<T> source, Func<T, TKey> map)
            where TKey : class
            => source.WhereNot(x => map(x) is null);

        /// <summary>
        /// Converts the enumerable to a ReadOnlyCollection
        /// </summary>
        public static IReadOnlyCollection<T> ToReadOnlyCollection<T>(this IEnumerable<T> source)
            => source is IReadOnlyCollection<T> collection ? collection : source.ToList();

        /// <summary>
        /// Converts the enumerable to a ReadOnlyList
        /// </summary>
        public static IReadOnlyList<T> ToReadOnlyList<T>(this IEnumerable<T> source)
            => source is IReadOnlyList<T> list ? list : source.ToList();

        /// <summary>
        /// Returns only the items that have distinct values returned by the keySelector
        /// </summary>
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
            => source.Distinct(new GeneralPropertyComparer<T,TKey>(keySelector));

        private class GeneralPropertyComparer<T, TKey> : IEqualityComparer<T>
        {
            private readonly Func<T, TKey> _expr;

            public GeneralPropertyComparer(Func<T, TKey> expr) => _expr = expr;

            public bool Equals(T x, T y) => EqualityComparer<TKey>.Default.Equals(_expr(x), _expr(y));

            public int GetHashCode(T obj) => EqualityComparer<TKey>.Default.GetHashCode(_expr(obj));
        }
    }
}