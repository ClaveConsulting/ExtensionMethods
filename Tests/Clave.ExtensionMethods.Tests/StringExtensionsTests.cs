using NUnit.Framework;
using Shouldly;

namespace Clave.ExtensionMethods.Tests
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        public void TestJoin()
        {
            new[] { "a", "b", "c" }.Join(" ").ShouldBe("a b c");
        }

        [Test]
        public void TestJoinInts()
        {
            new[] { 1, 2, 3 }.Join(" ").ShouldBe("1 2 3");
        }

        [Test]
        public void TestConcatWithSpace()
        {
            "a".ConcatWithSpace("b", "c").ShouldBe("a b c");
        }

        [Test]
        public void TestConcatWithSpaceWithSpacyStrings()
        {
            "a ".ConcatWithSpace("  b  ", "  ", " c").ShouldBe("a b c");
        }

        [Test]
        public void TestCommaSeparate()
        {
            "a".ConcatWithComma("b", "c").ShouldBe("a, b, c");
        }

        [Test]
        public void TestCommaSeparateWithSpacyStrings()
        {
            "a ".ConcatWithComma("  b  ", "  ", " c").ShouldBe("a, b, c");
        }

        [TestCase(null, ExpectedResult = null)]
        [TestCase("", ExpectedResult = null)]
        [TestCase("a", ExpectedResult = "a")]
        public string TestToNullIfEmpty(string input)
            => input.ToNullIfEmpty();

        [TestCase(null, ExpectedResult = null)]
        [TestCase("", ExpectedResult = null)]
        [TestCase(" ", ExpectedResult = null)]
        [TestCase("\n", ExpectedResult = null)]
        [TestCase("\t", ExpectedResult = null)]
        [TestCase("a", ExpectedResult = "a")]
        public string TestToNullIfWhiteSpace(string input)
            => input.ToNullIfWhiteSpace();

        [TestCase("something", "some", ExpectedResult = "thing")]
        [TestCase("something", "any", ExpectedResult = "something")]
        public string TestSkipPrefix(string value, string prefix)
            => value.SkipPrefix(prefix);

        [TestCase("123", ExpectedResult = 123)]
        [TestCase("blabla", ExpectedResult = 0)]
        public int TestToInt(string value)
            => value.ToInt();

        [TestCase("123", 75, ExpectedResult = 123)]
        [TestCase("blabla", 75, ExpectedResult = 75)]
        public int TestToIntWithFallback(string value, int fallback)
            => value.ToInt(fallback);

        [TestCase("123", ExpectedResult = 123)]
        [TestCase("blabla", ExpectedResult = 0)]
        public decimal TestToDecimal(string value)
            => value.ToDecimal();

        [TestCase("123", 75, ExpectedResult = 123)]
        [TestCase("blabla", 75, ExpectedResult = 75)]
        public decimal TestToDecimalWithFallback(string value, decimal fallback)
            => value.ToDecimal(fallback);
    }
}