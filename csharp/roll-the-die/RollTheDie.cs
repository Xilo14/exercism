using System;

public class Player
{
    private Random _rnd = new();
    public int RollDie() => _rnd.Next(1, 19);
    public double GenerateSpellStrength() => _rnd.NextDouble() * 100;
}
