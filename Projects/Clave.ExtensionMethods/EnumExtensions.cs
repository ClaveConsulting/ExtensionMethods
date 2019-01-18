using System;

namespace Clave.ExtensionMethods
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Converts a string to an enum
        /// </summary>
        /// <exception cref="ArgumentException">Throws if the string can't be converted to the enum</exception>
        public static T ToEnum<T>(this string value)
            where T : struct => (T)Enum.Parse(typeof(T), value);

        /// <summary>
        /// Converts a string to an enum, and uses the fallback value if the string doesn't match any enum values
        /// </summary>
        public static T ToEnumOrDefault<T>(this string value, T fallback)
            where T : struct => Enum.TryParse<T>(value, out var result) ? result : fallback;
    }
}