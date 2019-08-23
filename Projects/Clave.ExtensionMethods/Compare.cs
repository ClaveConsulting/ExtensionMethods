using System;
using System.Collections.Generic;

namespace Clave.ExtensionMethods
{
    public static class Compare<T>
    {
        public static GeneralPropertyComparer<TProp> Using<TProp>(Func<T, TProp> selector)
            => new GeneralPropertyComparer<TProp>(selector);

        public class GeneralPropertyComparer<TKey> : IEqualityComparer<T>
        {
            private readonly Func<T, TKey> _expr;

            public GeneralPropertyComparer(Func<T, TKey> expr) => _expr = expr;

            public bool Equals(T x, T y) => EqualityComparer<TKey>.Default.Equals(_expr(x), _expr(y));

            public int GetHashCode(T obj) => EqualityComparer<TKey>.Default.GetHashCode(_expr(obj));
        }
    }
}
