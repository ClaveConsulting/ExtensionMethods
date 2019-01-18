using System;
using System.Collections.Generic;
using System.Linq;

namespace Clave.ExtensionMethods
{
    public static class DictionaryExtensions
    {
        public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(
            this Dictionary<TKey, TValue> dictionary)
            => dictionary;
    }
}