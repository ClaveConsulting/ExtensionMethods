using System;
using System.Collections;
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
        public static IEnumerable<T> And<T>(this T initial, T item)
        {
            yield return initial;
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
        /// Returns an enumerable of the initial item and other items
        /// </summary>
        public static IEnumerable<T> And<T>(this T initial, IEnumerable<T> items)
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
        /// Returns an enumerable containing only non-null items
        /// </summary>
        public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> source)
            where T : struct
            => source.WhereNot(x => x is null) as IEnumerable<T>;

        /// <summary>
        /// Returns an enumerable containing only items where the map function returns a non-null value
        /// </summary>
        public static IEnumerable<T> WhereNotNull<T, TKey>(this IEnumerable<T> source, Func<T, TKey> map)
            where TKey : class
            => source.WhereNot(x => map(x) is null);

        /// <summary>
        /// Returns an enumerable containing only items where the map function returns a non-null value
        /// </summary>
        public static IEnumerable<T> WhereNotNull<T, TKey>(this IEnumerable<T> source, Func<T, TKey?> map)
            where TKey : struct
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
        /// Zips together two lists returning a tuple of their values
        /// </summary>
        public static IEnumerable<(T1, T2)> Zip<T1, T2>(this IEnumerable<T1> left, IEnumerable<T2> right)
            => left.Zip(right, ValueTuple.Create);

        /// <summary>
        /// Joins together two lists returning a tuple of their values using the key selectors
        /// </summary>
        public static IEnumerable<(T1, T2)> Join<T1, T2, TKey>(this IEnumerable<T1> left, IEnumerable<T2> right, Func<T1, TKey> leftKey, Func<T2, TKey> rightKey)
            => left.Join(right, leftKey, rightKey, ValueTuple.Create);

        /// <summary>
        /// Returns only the items that have distinct values returned by the keySelector
        /// </summary>
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
            => source.Distinct(CompareBy.Property(keySelector));

        /// <summary>
        /// Groups by a property in the key
        /// </summary>
        public static IEnumerable<IGrouping<TKey, T>> GroupByProp<T, TKey, TProp>(this IEnumerable<T> source, Func<T, TKey> keySelector, Func<TKey, TProp> propSelector)
            => source.GroupBy(keySelector, CompareBy.Property(propSelector));

        /// <summary>
        /// Projects each tuple pair of a sequence into a new form
        /// </summary>
        public static IEnumerable<TResult> Select<TA, TB, TResult>(this IEnumerable<(TA A, TB B)> source, Func<TA, TB, TResult> selector)
            => source.Select(x => selector(x.A, x.B));

        /// <summary>
        /// Add an item to a list
        /// </summary>
        public static void AddTo<T>(this T item, IList<T> list)
            => list.Add(item);

    }
}
