using static System.String;

namespace fun_with_roman_numbers;

record class RomanNumber
{
    private readonly int _intValue = 0;
    private readonly string _stringValue = "Nan";

    public RomanNumber(int value)
    {
        _intValue = value;
        _stringValue = _intValue is 0 ? "NaN" : Parse(_intValue);

        static string Parse(int number) => number switch
        {
            >= 1000 => "M" + Parse(number - 1000),
            >= 900 => "CM" + Parse(number - 900),
            >= 500 => "D" + Parse(number - 500),
            >= 400 => "CD" + Parse(number - 400),
            >= 100 => "C" + Parse(number - 100),
            >= 90 => "XC" + Parse(number - 90),
            >= 50 => "L" + Parse(number - 50),
            >= 40 => "XL" + Parse(number - 40),
            >= 10 => "X" + Parse(number - 10),
            >= 9 => "IX" + Parse(number - 9),
            >= 5 => "V" + Parse(number - 5),
            >= 4 => "IV" + Parse(number - 4),
            >= 1 => "I" + Parse(number - 1),
            _ => Empty
        };
    }

    public RomanNumber(string value)
    {
        _stringValue = value;
        _intValue = Parse(0, _stringValue);

        static int Parse(int sum, string str) => str switch
        {
        ['M', .. var rest] => Parse(sum + 1000, rest),
        ['C', 'M', .. var rest] => Parse(sum + 900, rest),
        ['D', .. var rest] => Parse(sum + 500, rest),
        ['C', 'D', .. var rest] => Parse(sum + 400, rest),
        ['C', .. var rest] => Parse(sum + 100, rest),
        ['X', 'C', .. var rest] => Parse(sum + 90, rest),
        ['L', .. var rest] => Parse(sum + 50, rest),
        ['X', 'L', .. var rest] => Parse(sum + 40, rest),
        ['X', .. var rest] => Parse(sum + 10, rest),
        ['I', 'X', .. var rest] => Parse(sum + 9, rest),
        ['V', .. var rest] => Parse(sum + 5, rest),
        ['I', 'V', .. var rest] => Parse(sum + 4, rest),
        ['I', .. var rest] => Parse(sum + 1, rest),
            _ => sum
        };
    }

    public static implicit operator int(RomanNumber romanNumber) => romanNumber._intValue;

    public static implicit operator string(RomanNumber romanNumber) => romanNumber._stringValue;
}