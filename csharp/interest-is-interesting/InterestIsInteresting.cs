using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

static class SavingsAccount
{
    public static float InterestRate(decimal balance)
        => balance switch
        {
            < 0 => -3.213f,
            >= 0 and < 1000 => 0.5f,
            >= 1000 and < 5000 => 1.621f,
            >= 5000 => 2.475f
        };

    public static decimal AnnualBalanceUpdate(decimal balance)
        => balance + balance * Math.Abs((decimal)InterestRate(balance)) / 100m;

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
        => Enumerable.Repeat(balance, 1)
        .Select(b => new { ind = 0, val = b })
        .Progression((prev) => new { ind = prev.ind + 1, val = AnnualBalanceUpdate(prev.val) })
        .First((e) => e.val >= targetBalance).ind;

}
public static class Ext
{
    public static IEnumerable<T> Progression<T>
        (this IEnumerable<T> source,
         Func<T, T> progression)
    {
        using var iterator = source.GetEnumerator();
        if (!iterator.MoveNext())
        {
            yield break;
        }
        T newEl = iterator.Current;
        while (true)
            yield return newEl = progression(newEl);
    }
}