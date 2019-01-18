using NUnit.Framework;

namespace Clave.ExtensionMethods.Tests
{
    [TestFixture]
    public class EnumExtensionsTests
    {
        [TestCase("One", ExpectedResult = Foo.One)]
        [TestCase("Two", ExpectedResult = Foo.Two)]
        [TestCase("Three", ExpectedResult = Foo.Three)]
        public Foo TestToEnum(string key)
            => key.ToEnum<Foo>();

        [TestCase("One", ExpectedResult = Foo.One)]
        [TestCase("Two", ExpectedResult = Foo.Two)]
        [TestCase("Three", ExpectedResult = Foo.Three)]
        [TestCase("blabla", ExpectedResult = Foo.Unknown)]
        public Foo TestToEnumOrDefault(string key)
            => key.ToEnumOrDefault(Foo.Unknown);

        public enum Foo
        {
            Unknown,
            One,
            Two,
            Three
        }
    }
}