# Clave.ExtensionMethods

This is a collection of small and useful extension methods for C#. 

To use it just add `using Clave.ExtensionMethods;` at the top of the file

## String extensions

### Join

Join an enumerable of strings

```cs
var strings = new[] {"a", "b", "c"};
strings.Join(" "); // "a b c"
```

### ConcatWithSpace / JoinWithSpace

Concatenate strings using space, triming away extra spaces

```cs
"a".ConcatWithSpace("b", "c"); // "a b c"
"a".ConcatWithSpace(" b ", " ", "c"); // "a b c"
// it also works on enumerables
new[]{"a", "b", "c"}.JoinWithSpace()
```

### ConcatWithComma / JoinWithComma 

Concatenate strings using space, triming away extra spaces

```cs
"a".ConcatWithComma("b", "c"); // "a, b, c"
"a".ConcatWithComma(" b ", " ", "c"); // "a, b, c"
// it also works on enumerables
new[]{"a", "b", "c"}.JoinWithComma()
```

### ToNullIfEmpty

Converts a string to null if it is empty, useful together with the `??` operator

```cs
someString.ToNullIfEmpty() ?? "defaultValue";
```

### ToNullIfWhiteSpace

Converts a string to null if it is empty or only contains white space characters, useful together with the `??` operator

```cs
someString.ToNullIfWhiteSpace() ?? "defaultValue";
```

### SkipPrefix

Removes a prefix of a string if it is present

```cs
"something".SkipPrefix("some"); // "thing"
```

### ToInt

Converts a string to an int. If it fails it returns the fallback value, which defaults to 0.

```cs
"123".ToInt(); // 123
"foo".ToInt(); // 0
"foo".ToInt(-1); // -1
```

### ToDecimal

Converts a string to an decimal. If it fails it returns the fallback value, which defaults to 0.

```cs
"123.45".ToDecimal(); // 123.45
"foo".ToDecimal(); // 0
"foo".ToDecimal(-1); // -1
```

## Enumerable extensions

### Only

Creates an enumerable with only one value

```cs
var enumerable = "something".Only();
```

### And

Creates an enumerable of one or more values

```cs
var enumerable = "some".And("thing", "else");
```

### NotAny

Returns true if the list is empty, or if nothing matches the predicate

```cs
new string[0].NotAny(); // true
new []{"a", "b", "c"}.NotAny(string.IsNullOrEmpty); // true
```

### WhereNot

Returns only the items that don't match the predicate

```cs
new []{"a", "", "c"}.WhereNot(string.IsNullOrEmpty); // "a", "c"
```

### WhereNotNull

Returns only the items that are not null

```cs
new []{"a", null, "c"}.WhereNotNull(); // "a", "c"

// this also works with a predicate

new []{new Foo("a"), new Foo(null), new Foo("c")}.WhereNotNull(f => f.Value); // "a", "c"
```

### ToReadOnlyCollection

Returns an IReadOnlyCollection, does nothing if the type is already an IReadOnlyCollection

```cs
"a".And("b", "c").ToReadOnlyCollection();
new []{"a", "b", "c"}.ToReadOnlyCollection();
```

### ToReadOnlyList

Returns an IReadOnlyList, does nothing if the type is already an IReadOnlyList

```cs
"a".And("b", "c").ToReadOnlyList();
new []{"a", "b", "c"}.ToReadOnlyList();
```

### DistinctBy

Returns only the entries with a distinct key

```cs
new []{new Foo("a"), new Foo("a"), new Foo("c")}.DistinctBy(f => f.Value); // "a", "c"
```

### Zip

Zip together two enumerables and return a tuple of the entries

```cs
foreach(var (a, b) in listA.Zip(listB))
{
	// ...
}
```

### Join

Join together two enumerables using two key selectors and return a tuple of the entries

```cs
foreach(var (a, b) in listA.Join(listB, a => a.Id, b => b.Id))
{
	// ...
}
```

## Empty

This is a useful way to get empty immutable objects. Since they are immutable the same empty instance can be reused every time.

### ReadOnlyCollection

Returns an empty IReadOnlyCollection

```cs
Empty.ReadOnlyCollection<string>();
```

### ReadOnlyList

Returns an empty IReadOnlyList

```cs
Empty.ReadOnlyList<string>();
```

### Array

Returns an empty Array

```cs
Empty.Array<string>();
```

## Enum

### ToEnum

Converts a string to an enum, throws exception if it is an unknown string

```cs
"Monday".ToEnum<Weekday>(); // Weekday.Monday
```

### ToEnumOrDefault

Converts a string to an enum, uses the default value if it is an unknown string

```cs
"Monday".ToEnumOrDefault(Weekday.Unknown); // Weekday.Monday
"BlaBla".ToEnumOrDefault(Weekday.Unknown); // Weekday.Unknown
```

## Magic

These are magical extension methods that allow you to do useful magic.

To use it just add `using Clave.ExtensionMethods.Magic;` at the top of the file

### Add list to list

This will add all the items in a list to another list

```cs
var list = new List<string>
{
	"some",
	GetStringList(),
	"thing"
}
```

### Await many things

This lets you await several tasks without using `Task.WhenAll`

```cs
await DoSomethingAsync().And(DoSomethingElseAsync(), AtTheSameTimeAsync());
```

## License

The MIT license