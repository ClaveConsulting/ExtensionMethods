using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Clave.ExtensionMethods.Magic
{
    public static class AsyncMagic
    {
        public static TaskAwaiter<T[]> GetAwaiter<T>(this IEnumerable<Task<T>> manyTasks)
            => Task.WhenAll(manyTasks).GetAwaiter();
    }
}