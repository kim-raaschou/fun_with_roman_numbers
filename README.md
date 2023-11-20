# Fun With Roman Numbers

Velkommen til "Fun With Roman Numbers" - en legende og humoristisk kode kata, hvor jeg udforsker den spændende verden af romertal i .NET 8 med C# 12!

## Opgaven

Med udgangspunkt i kata [Roman Numerals Kata](https://codingdojo.org/kata/RomanNumerals), har jeg skrevet en enkel implementering, der kan konvertere til og fra henholdsvis romertal som strenge og tal.
Tag en dyb indånding, og dyk ned i koden.

Implementeringen er valideret op i mod alle valide romertal, specificeret på [The On-Line Encyclopedia of Integer Sequences® (OEIS®)](https://oeis.org/A006968/a006968.txt)

## Kode Eksempeler

```csharp
Assert.Equals(42, new RomanNumber("CXXIII"))
Assert.Equals("CXXIII", new RomanNumber(42))
