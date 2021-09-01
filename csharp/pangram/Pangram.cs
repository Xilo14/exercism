using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

public static class Pangram
{
    private static List<char> Alphabet = new List<char>()
    {
        'q','w','e','r','t','y','u','i','o','p',
        'a','s','d','f','g','h','j','k','l',
        'z','x','c','v','b','n','m',
    };
    public static bool IsPangram(string input)
    {
        var tmpAlphabet = Alphabet.ToList();

        foreach (var c in input.ToLower())
            if (tmpAlphabet.Contains(c))
                tmpAlphabet.Remove(c);

        return tmpAlphabet.Count == 0;
    }
}
