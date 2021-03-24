using System;

namespace Clave.ExtensionMethods
{
    public static class FuncExtensions
    {
        /// <summary>
        /// Call the func with the argument, useful if the argument might be null
        /// </summary>
        /// <example>
        ///   value?.Pipe(SomeFunction)
        /// </example>
        public static TResult Pipe<TArg, TResult>(this TArg arg, Func<TArg, TResult> func) => func(arg);

        /// <summary>
        /// Call the func with the two arguments, useful if the first argument might be null
        /// </summary>
        /// <example>
        ///   value?.Pipe(SomeFunction, secondArgument)
        /// </example>
        public static TResult Pipe<TArg1, TArg2, TResult>(this TArg1 arg1, Func<TArg1, TArg2, TResult> func, TArg2 arg2) => func(arg1, arg2);

        /// <summary>
        /// Call the func with the three arguments, useful if the first argument might be null
        /// </summary>
        /// <example>
        ///   value?.Pipe(SomeFunction, secondArgument, thirdArgument)
        /// </example>
        public static TResult Pipe<TArg1, TArg2, TArg3, TResult>(this TArg1 arg1, Func<TArg1, TArg2, TArg3, TResult> func, TArg2 arg2, TArg3 arg3) => func(arg1, arg2, arg3);
    }
}