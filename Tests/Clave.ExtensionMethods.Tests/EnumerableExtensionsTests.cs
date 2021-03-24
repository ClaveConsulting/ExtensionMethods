using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;

namespace Clave.ExtensionMethods.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class EnumerableExtensionsTests
    {
        [Test]
        public void TestOnly()
        {
            "something".Only().ShouldContain("something");
        }

        [Test]
        public void TestAnd()
        {
            var list = "some".And("thing");

            list.ShouldContain("some");
            list.ShouldContain("thing");
        }

        [Test]
        public void TestAndMany()
        {
            var list = "some".And("thing", "else");

            list.ShouldContain("some");
            list.ShouldContain("thing");
            list.ShouldContain("else");
        }

        [Test]
        public void TestNotAny()
        {
            Empty.Array<string>().NotAny().ShouldBeTrue();
            "something".Only().NotAny().ShouldBeFalse();
        }

        [Test]
        public void TestNotAnyPredicate()
        {
            Empty.Array<string>().NotAny(string.IsNullOrEmpty).ShouldBeTrue();
            "something".Only().NotAny(string.IsNullOrEmpty).ShouldBeTrue();
            "something".And("").NotAny(string.IsNullOrEmpty).ShouldBeFalse();
        }

        [Test]
        public void TestWhereNot()
        {
            var result = 1.And(2, 3, 4).WhereNot(n => n % 2 == 0).ToReadOnlyCollection();

            result.Count().ShouldBe(2);
            result.ShouldContain(1);
            result.ShouldContain(3);
        }

        [Test]
        public void TestWhereNotNull()
        {
            var result = "a".And(null, "b", null).WhereNotNull().ToReadOnlyList();

            result.Count().ShouldBe(2);
            result.ShouldContain("a");
            result.ShouldContain("b");
        }

        [Test]
        public void TestWhereNotNullKeySelector()
        {
            var result = new Foo("1").And(new Foo(null), new Foo("b"), new Foo(null)).WhereNotNull(s => s.Prop);

            result.Count().ShouldBe(2);
            result.ShouldContain(s => s.Prop == "1");
            result.ShouldContain(s => s.Prop == "b");
        }

        [Test]
        public void TestDistinctBy()
        {
            var result = new Foo("1").And(new Foo("1"), new Foo("b"), new Foo("b")).DistinctBy(s => s.Prop);
            result.Count().ShouldBe(2);
            result.ShouldContain(s => s.Prop == "1");
            result.ShouldContain(s => s.Prop == "b");
        }

        [Test]
        public void TestGroupByProp()
        {
            var result = new Foo("12").And(new Foo("13"), new Foo("22"), new Foo("21")).GroupByProp(s => s.Prop, s => s[0]);

            result.Count().ShouldBe(2);
            result.First().Key.ShouldBe("12");
            result.Last().Key.ShouldBe("22");
        }

        [Test]
        public void TestExceptBy()
        {
            var second = new Foo("13").Only();
            var result = new Foo("12").And(new Foo("13"), new Foo("22"), new Foo("21")).ExceptBy(second, s => s.Prop);

            result.Count().ShouldBe(3);
            result.First().Prop.ShouldBe("12");
            result.Last().Prop.ShouldBe("21");
        }

        [Test]
        public void TestSelectTuple()
        {
            var result = ("A", 1).And(("B", 2)).Select(Map).Join(",");

            result.ShouldBe("A1,B2");
        }

        [Test]
        public void TestCompare()
        {
            var yearComparer = Compare<DateTime>.Using(date => date.Year);

            yearComparer.Equals(DateTime.Parse("2019-02-03"), DateTime.Parse("2019-08-19")).ShouldBeTrue();

            var dictionary = new Dictionary<DateTime, string>(yearComparer)
            {
                [DateTime.Parse("2019-02-06")] = "year 1",
                [DateTime.Parse("2020-08-12")] = "year 2",
            };

            dictionary[DateTime.Parse("2019-06-13")].ShouldBe("year 1");
        }

        private string Map(string a, int b) => a + b;

        public class Foo
        {
            public string Prop { get; }

            public Foo(string prop)
            {
                Prop = prop;
            }
        }
    }
}