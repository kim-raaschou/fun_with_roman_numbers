using static System.String;

namespace fun_with_roman_numbers;

readonly record struct RomanNumber
{
    private readonly int intValue;
    private readonly string stringValue;
    public RomanNumber(int value)
    {
        intValue = value;
        stringValue = value switch
        {
            >= 1000 => "M" + new RomanNumber(value - 1000),
            >= 900 => "CM" + new RomanNumber(value - 900),
            >= 500 => "D" + new RomanNumber(value - 500),
            >= 400 => "CD" + new RomanNumber(value - 400),
            >= 100 => "C" + new RomanNumber(value - 100),
            >= 90 => "XC" + new RomanNumber(value - 90),
            >= 50 => "L" + new RomanNumber(value - 50),
            >= 40 => "XL" + new RomanNumber(value - 40),
            >= 10 => "X" + new RomanNumber(value - 10),
            >= 9 => "IX" + new RomanNumber(value - 9),
            >= 5 => "V" + new RomanNumber(value - 5),
            >= 4 => "IV" + new RomanNumber(value - 4),
            >= 1 => "I" + new RomanNumber(value - 1),
            _ => Empty
        };
    }

    public RomanNumber(string value)
    {
        stringValue = value;
        intValue = value switch
        {
        ['M', .. var rest] => 1000 + new RomanNumber(rest),
        ['C', 'M', .. var rest] => 900 + new RomanNumber(rest),
        ['D', .. var rest] => 500 + new RomanNumber(rest),
        ['C', 'D', .. var rest] => 400 + new RomanNumber(rest),
        ['C', .. var rest] => 100 + new RomanNumber(rest),
        ['X', 'C', .. var rest] => 90 + new RomanNumber(rest),
        ['L', .. var rest] => 50 + new RomanNumber(rest),
        ['X', 'L', .. var rest] => 40 + new RomanNumber(rest),
        ['X', .. var rest] => 10 + new RomanNumber(rest),
        ['I', 'X', .. var rest] => 9 + new RomanNumber(rest),
        ['V', .. var rest] => 5 + new RomanNumber(rest),
        ['I', 'V', .. var rest] => 4 + new RomanNumber(rest),
        ['I', .. var rest] => 1 + new RomanNumber(rest),
            _ => 0
        };
    }

    public static implicit operator int(RomanNumber romanNumber)
        => romanNumber.intValue;

    public static implicit operator string(RomanNumber romanNumber) 
        => romanNumber.stringValue;
}