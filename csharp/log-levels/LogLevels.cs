using System;
using System.Linq;

static class LogLine
{
    private static char[] _trimChars = { '\t', '\n', '\r' };
    public static string Message(string logLine)
        => string.Concat(
            logLine
                .SkipWhile(c => c != ':').Skip(2)
                .Where(c => !_trimChars.Any(tC => tC == c))).Trim();

    public static string LogLevel(string logLine)
        => string.Concat(logLine
            .Skip(1)
            .TakeWhile(c => c != ']'))
                .ToLower();

    public static string Reformat(string logLine)
        => $"{Message(logLine)} ({LogLevel(logLine)})";
}
