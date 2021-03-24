using NUnit.Framework;
using Shouldly;

namespace Clave.ExtensionMethods.Tests
{
    [TestFixture]
    public class FuncExtensionsTests
    {
        private static readonly string MightBeNull = null;

        [Test]
        public void TestPipe()
        {
            var result = "something".Pipe(Func);

            result.ShouldBe("result");
        }

        [Test]
        public void TestPipeWithNull()
        {
            var result = MightBeNull?.Pipe(Func);

            result.ShouldBeNull();
        }

        [Test]
        public void TestPipe2()
        {
            var result = "something".Pipe(Func, "arg2");

            result.ShouldBe("result2");
        }

        [Test]
        public void TestPipeLambda()
        {
            var result = "something".Pipe((s, s1) => $"{s} {s1}", "arg2");

            result.ShouldBe("something arg2");
        }

        public static string Func(string arg)
        {
            return "result";
        }

        public static string Func(string arg, string arg2)
        {
            return "result2";
        }
    }
}