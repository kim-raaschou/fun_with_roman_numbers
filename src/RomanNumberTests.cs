namespace fun_with_roman_numbers;

public class RomanNumberTests
{
    [Theory]
    [InlineData(1, "I")]
    [InlineData(4, "IV")]
    [InlineData(5, "V")]
    [InlineData(9, "IX")]
    [InlineData(10, "X")]
    [InlineData(40, "XL")]
    [InlineData(50, "L")]
    [InlineData(90, "XC")]
    [InlineData(100, "C")]
    [InlineData(400, "CD")]
    [InlineData(500, "D")]
    [InlineData(900, "CM")]
    [InlineData(1000, "M")]
    public void Should_parse_roman_number_to_string(int value, string expected) =>
        Assert.Equal(expected, new RomanNumber(value));

    [Theory]
    [InlineData("I", 1)]
    [InlineData("IV", 4)]
    [InlineData("V", 5)]
    [InlineData("IX", 9)]
    [InlineData("X", 10)]
    [InlineData("XL", 40)]
    [InlineData("L", 50)]
    [InlineData("XC", 90)]
    [InlineData("C", 100)]
    [InlineData("CD", 400)]
    [InlineData("D", 500)]
    [InlineData("CM", 900)]
    [InlineData("M", 1000)]
    public void Should_parse_roman_string_to_int(string value, int expected) =>
        Assert.Equal(expected, new RomanNumber(value));

}