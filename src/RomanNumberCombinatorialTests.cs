namespace fun_with_roman_numbers;

public class RomanNumberCombinatorialTests
{
    [Theory]
    [MemberData(nameof(CombinatorialTestFactory.RomanNumbersAndStrings), MemberType = typeof(CombinatorialTestFactory))]
    public void Should_parse_all_roman_number_to_string(int value, string expected) =>
        Assert.Equal(expected, new RomanNumber(value));

    [Theory]
    [MemberData(nameof(CombinatorialTestFactory.RomanStringAndNumbers), MemberType = typeof(CombinatorialTestFactory))]
    public void Should_parse_all_roman_string_to_int(string value, int expected) =>
        Assert.Equal(expected, new RomanNumber(value));
}

file class CombinatorialTestFactory
{
    private static readonly Dictionary<int, string> Instance = File
        .ReadAllLines("oeis_a006968.txt")
        .Skip(14)
        .Where(line => line?.Trim().Length > 0)
        .Select(static line =>
        {
            var match = line.Split('=');
            return (Key: int.Parse(match[0].Trim()), Value: match[1].Trim());
        })
        .ToDictionary(x => x.Key, x => x.Value);

    public static IEnumerable<object[]> RomanNumbersAndStrings() =>
        Instance.Select(kv => new object[] { kv.Key, kv.Value });

    public static IEnumerable<object[]> RomanStringAndNumbers() =>
        Instance.Select(kv => new object[] { kv.Value, kv.Key });
}

