using System;
using System.Collections.Generic;
using System.Linq;

public static class CryptoSquare
{
    public static IEnumerable<char> NormalizedPlaintext(string plaintext)
    => plaintext
        .Where(c => char.IsLetterOrDigit(c))
        .Select(c => char.ToLower(c));

    public static IEnumerable<string> PlaintextSegments(IEnumerable<char> plaintext)
    {
        var l = plaintext.Count();
        var c = (int)Math.Ceiling(Math.Sqrt(plaintext.Count()));

        var x = plaintext
          .Concat(Enumerable.Repeat(' ',
              l % c == 0 ? 0 : c - l % c));
        return
          x.SplitEvery(c);
    }

    public static string Ciphertext(string plaintext)
        => (plaintext.Length == 0)
            ? string.Empty
            : string.Join(" ", PlaintextSegments(NormalizedPlaintext(plaintext))
                .SelectMany(row => row.Select(
                    (c, i) => new { c, i }))
                .GroupBy(a => a.i)
                .Select(g => string.Concat(g.Select(a => a.c))));


    public static IEnumerable<string> SplitEvery(this IEnumerable<char> s, int n)
    {
        int index = 0;
        return s.GroupBy(_ => index++ / n)
                .Select(g => new string(g.ToArray()));
    }
}