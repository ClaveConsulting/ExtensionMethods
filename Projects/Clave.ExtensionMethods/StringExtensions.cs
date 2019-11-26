using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Clave.ExtensionMethods
{
    public static class StringExtensions
    {
        /// <summary>
        /// Joins a list of strings with a separator
        /// </summary>
        public static string Join<T>(this IEnumerable<T> values, string separator)
            => string.Join(separator, values);

        /// <summary>
        /// Joins a list of strings, except null or empty values, with a single space
        /// </summary>
        public static string JoinWithSpace(this IEnumerable<string> values)
            => values
                .WhereNot(string.IsNullOrWhiteSpace)
                .Select(s => s.Trim())
                .Join(" ");

        /// <summary>
        /// Joins a list of strings, except null or empty values, with ", "
        /// </summary>
        public static string JoinWithComma(this IEnumerable<string> values)
            => values
                .WhereNot(string.IsNullOrWhiteSpace)
                .Select(s => s.Trim())
                .Join(", ");

        /// <summary>
        /// Joins a list of strings, except null or empty values, with a single space
        /// </summary>
        public static string ConcatWithSpace(this string initial, params string[] values)
            => initial
                .And(values)
                .JoinWithSpace();

        /// <summary>
        /// Joins a list of strings, except null or empty values, with ", "
        /// </summary>
        public static string ConcatWithComma(this string initial, params string[] values)
            => initial
                .And(values)
                .JoinWithComma();

        /// <summary>
        /// Returns null if the string is an empty string
        /// </summary>
        public static string ToNullIfEmpty(this string value)
            => string.IsNullOrEmpty(value) ? null : value;

        /// <summary>
        /// Returns null if the string is empty or white space
        /// </summary>
        public static string ToNullIfWhiteSpace(this string value)
            => string.IsNullOrWhiteSpace(value) ? null : value;

        /// <summary>
        /// Returns the substring after the prefix, if the string starts with the prefix
        /// </summary>
        public static string SkipPrefix(this string value, string prefix)
            => value.StartsWith(prefix) ? value.Substring(prefix.Length) : value;

        /// <summary>
        /// Converts a string to an int, and returns the fallback value if the conversion fails
        /// </summary>
        public static int ToInt(this string value, int fallback = 0)
            => int.TryParse(value, out var result) ? result : fallback;

        /// <summary>
        /// Converts a string to a decimal, and returns the fallback value if the conversion fails.
        /// Uses the invariant culture for parsing
        /// </summary>
        public static decimal ToDecimal(this string value, decimal fallback = 0)
            => decimal.TryParse(value, NumberStyles.Number, NumberFormatInfo.InvariantInfo, out var result) ? result : fallback;
    }
}
