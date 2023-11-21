namespace fun_with_roman_numbers;

public class RomanNumberCombinatorialTests
{
    [Theory]
    [MemberData(nameof(RomanNumbers_from_1_to_3999))]
    public void Should_parse_all_roman_numbers(int romanNumber, string romanString) =>
        Assert.Multiple(
            () => Assert.Equal(romanString, new RomanNumber(romanNumber)),
            () => Assert.Equal(romanNumber, new RomanNumber(romanString))
        );

    public static IEnumerable<object[]> RomanNumbers_from_1_to_3999() => File
        .ReadAllLines("oeis_a006968.txt")
        .Skip(14)
        .Where(line => line.Trim().Length > 0)
        .Select(static line => line.Split('=') switch
        {
        [var key, var value] => [int.Parse(key.Trim()), value.Trim()],
            _ => Array.Empty<object>()
        });
}

