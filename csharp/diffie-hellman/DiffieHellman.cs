using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;

public static class DiffieHellman
{
    private static readonly Random _rnd = new();
    private static readonly List<BigInteger> _wasUsedList = new();
    public static BigInteger PrivateKey(BigInteger primeP)
        => PrimitiveRootModulo(primeP);

    public static BigInteger PublicKey(BigInteger primeP, BigInteger primeG, BigInteger privateKey)
        => BigInteger.ModPow(primeG, privateKey, primeP);

    public static BigInteger Secret(BigInteger primeP, BigInteger publicKey, BigInteger privateKey)
        => BigInteger.ModPow(publicKey, privateKey, primeP);
    private static BigInteger PrimitiveRootModulo(BigInteger p)
    {
        List<BigInteger> fact = new();
        var phi = p - 1;
        var n = phi;
        for (BigInteger i = 2; i * i <= n; ++i)
            if (n % i == 0)
            {
                fact.Add(i);
                while (n % i == 0)
                    n /= i;
            }
        if (n > 1)
            fact.Add(n);

        for (BigInteger res = 2; res <= p; ++res)
        {
            bool ok = true;
            var f = fact.OrderBy(v => _rnd.Next());

            for (var i = 0; i < f.Count() && ok; ++i)
                ok &= BigInteger.ModPow(res, phi / f.ElementAt(i), p) != 1;
            if (ok && !_wasUsedList.Contains(res))
            {
                _wasUsedList.Add(res);
                return res;
            }
        }
        var r = _wasUsedList.OrderBy(v => _rnd.Next()).First();
        _wasUsedList.Clear();
        return r;
    }
}