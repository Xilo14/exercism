using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class RomanNumeralExtension
{
    private static readonly Dictionary<char, int> _romanSymbols = new()
    {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 },
    };
    private static readonly IEnumerable<Tuple<char, char, int>> _romanChunks =
        _romanSymbols.SelectMany(
                p => Enumerable.Empty<Tuple<char, char, int>>()
                .Append(_romanSymbols.Where(p2 => p2.Value < p.Value
                    && Math.Log10(p2.Value).IsInteger())
                    .Reverse().Select(p2 => Tuple.Create(p.Key, p2.Key, p.Value - p2.Value))
                    .FirstOrDefault())
                .Append(Tuple.Create(p.Key, default(char), p.Value))
                .Where(p => p != null));

    public static string ToRoman(this int value)
    {
        List<char> result = new();
        var remainder = value;

        while (remainder != 0)
        {
            var chunk = _romanChunks.LastOrDefault(c => remainder >= c.Item3);

            if (chunk.Item2 != default(char))
                result.Add(chunk.Item2);
            result.Add(chunk.Item1);

            remainder -= chunk.Item3;
        }
        return new string(result.ToArray());
    }
}
public static class Ext
{
    public static bool IsInteger(this double number) => Math.Floor(number) == number;
}