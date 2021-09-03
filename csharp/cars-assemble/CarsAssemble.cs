using System;

static class AssemblyLine
{
    public static double ProductionRatePerHour(int speed)
        => speed switch
        {
            5 or 6 or 7 or 8 => speed * 221 * 0.9,
            9 => speed * 221 * 0.8,
            10 => speed * 221 * 0.77,
            _ => speed * 221,
        };


    public static int WorkingItemsPerMinute(int speed)
        => (int)ProductionRatePerHour(speed) / 60;
}
