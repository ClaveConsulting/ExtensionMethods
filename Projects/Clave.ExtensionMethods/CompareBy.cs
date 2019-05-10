using System;
using System.Collections.Generic;

namespace Clave.ExtensionMethods
{
    public static class CompareBy
    {
        public static GeneralPropertyComparer<TKey, TProp> Property<TKey, TProp>(Func<TKey, TProp> selector)
            => new GeneralPropertyComparer<TKey, TProp>(selector);

        public class GeneralPropertyComparer<T, TKey> : IEqualityComparer<T>
        {
            private readonly Func<T, TKey> _expr;

            public GeneralPropertyComparer(Func<T, TKey> expr) => _expr = expr;

            public bool Equals(T x, T y) => EqualityComparer<TKey>.Default.Equals(_expr(x), _expr(y));

            public int GetHashCode(T obj) => EqualityComparer<TKey>.Default.GetHashCode(_expr(obj));
        }
    }
}
