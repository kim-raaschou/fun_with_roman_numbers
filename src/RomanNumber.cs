using static System.String;

namespace fun_with_roman_numbers;

readonly partial record struct RomanNumber
{
    public readonly int intValue;
    private readonly string stringValue;

    private RomanNumber(int intValue, string stringValue)
     => (this.intValue, this.stringValue) = (intValue, stringValue);

    public RomanNumber(int value)
    {
        intValue = value;
        stringValue = value switch
        {
            >= 1000 => Roman.Thousand + new RomanNumber(value - 1000),
            >= 900 => Roman.NineHundred + new RomanNumber(value - 900),
            >= 500 => Roman.FiveHundred + new RomanNumber(value - 500),
            >= 400 => Roman.FourHundred + new RomanNumber(value - 400),
            >= 100 => Roman.Hundred + new RomanNumber(value - 100),
            >= 90 => Roman.Ninety + new RomanNumber(value - 90),
            >= 50 => Roman.Fifty + new RomanNumber(value - 50),
            >= 40 => Roman.Forty + new RomanNumber(value - 40),
            >= 10 => Roman.Ten + new RomanNumber(value - 10),
            >= 9 => Roman.Nine + new RomanNumber(value - 9),
            >= 5 => Roman.Five + new RomanNumber(value - 5),
            >= 4 => Roman.Four + new RomanNumber(value - 4),
            >= 1 => Roman.One + new RomanNumber(value - 1),
            _ => Empty
        };
    }

    public RomanNumber(string value)
    {
        stringValue = value;
        intValue = value switch
        {
        ['M', .. var rest] => Roman.Thousand + new RomanNumber(rest),
        ['C', 'M', .. var rest] => Roman.NineHundred + new RomanNumber(rest),
        ['D', .. var rest] => Roman.FiveHundred + new RomanNumber(rest),
        ['C', 'D', .. var rest] => Roman.FourHundred + new RomanNumber(rest),
        ['C', .. var rest] => Roman.Hundred + new RomanNumber(rest),
        ['X', 'C', .. var rest] => Roman.Ninety + new RomanNumber(rest),
        ['L', .. var rest] => Roman.Fifty + new RomanNumber(rest),
        ['X', 'L', .. var rest] => Roman.Forty + new RomanNumber(rest),
        ['X', .. var rest] => Roman.Ten + new RomanNumber(rest),
        ['I', 'X', .. var rest] => Roman.Nine + new RomanNumber(rest),
        ['V', .. var rest] => Roman.Five + new RomanNumber(rest),
        ['I', 'V', .. var rest] => Roman.Four + new RomanNumber(rest),
        ['I', .. var rest] => Roman.One + new RomanNumber(rest),
            _ => 0
        };
    }

    public static RomanNumber operator +(RomanNumber left, RomanNumber right)
        => new(
            intValue: left.intValue + right.intValue,
            stringValue: left.stringValue + right.stringValue
        );

    public static implicit operator int(RomanNumber romanNumber)
        => romanNumber.intValue;

    public static implicit operator string(RomanNumber romanNumber)
        => romanNumber.stringValue;
    private static class Roman
    {
        internal static RomanNumber Thousand => new(1000, "M");
        internal static RomanNumber NineHundred => new(900, "CM");
        internal static RomanNumber FiveHundred => new(500, "D");
        internal static RomanNumber FourHundred => new(400, "CD");
        internal static RomanNumber Hundred => new(100, "C");
        internal static RomanNumber Ninety => new(90, "XC");
        internal static RomanNumber Fifty => new(50, "L");
        internal static RomanNumber Forty => new(40, "XL");
        internal static RomanNumber Ten => new(10, "X");
        internal static RomanNumber Nine => new(9, "IX");
        internal static RomanNumber Five => new(5, "V");
        internal static RomanNumber Four => new(4, "IV");
        internal static RomanNumber One => new(1, "I");
    }
}