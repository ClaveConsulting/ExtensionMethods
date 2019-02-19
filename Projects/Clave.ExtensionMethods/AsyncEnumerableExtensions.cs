using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clave.ExtensionMethods
{
    public static class AsyncEnumerableExtensions
    {
        /// <summary>
        /// Converts the enumerable to a ReadOnlyCollection
        /// </summary>
        public static async Task<IReadOnlyCollection<T>> ToReadOnlyCollection<T>(this Task<IEnumerable<T>> sourceTask)
        {
            var source = await sourceTask;
            return source is IReadOnlyCollection<T> collection ? collection : source.ToList();
        }

        /// <summary>
        /// Converts the enumerable to a ReadOnlyList
        /// </summary>
        public static async Task<IReadOnlyList<T>> ToReadOnlyList<T>(this Task<IEnumerable<T>> sourceTask)
        {
            var source = await sourceTask;
            return source is IReadOnlyList<T> list ? list : source.ToList();
        }
        
        /// <summary>
        /// Returns an enumerable containing only the items of the source that match the predicate
        /// </summary>
        public static async Task<IEnumerable<T>> Where<T>(this Task<IEnumerable<T>> sourceTask, Func<T, bool> predicate)
        {
            var source = await sourceTask;
            return source.Where(predicate);
        }
        
        /// <summary>
        /// Returns an enumerable containing only the items of the source that don't match the predicate
        /// </summary>
        public static async Task<IEnumerable<T>> WhereNot<T>(this Task<IEnumerable<T>> sourceTask, Func<T, bool> predicate)
        {
            var source = await sourceTask;
            return source.WhereNot(predicate);
        }
        
        /// <summary>
        /// Projects each element of a sequence into a new form
        /// </summary>
        public static async Task<IEnumerable<TResult>> Select<TIn, TResult>(this Task<IEnumerable<TIn>> sourceTask, Func<TIn, TResult> selector)
        {
            var source = await sourceTask;
            return source.Select(selector);
        }
    }
}