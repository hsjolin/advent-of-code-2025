namespace AdventOfCode2025;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code 2025 - Day 02");
        Console.WriteLine("=============================\n");

        // Read input
        string input = File.ReadAllText("input.txt");

        // Part 1
        var part1Result = SolvePart1(input);
        Console.WriteLine($"Part 1: {part1Result}");

        // Part 2
        var part2Result = SolvePart2(input);
        Console.WriteLine($"Part 2: {part2Result}");
    }
    private static IEnumerable<string> Parse(string input)
    {
        var parts = input.Split(',');

        foreach (var part in parts)
        {
            yield return part;
        }
    }

    static object SolvePart1(string input)
    {
        var ranges = Parse(input);
        var result = 0d;
        foreach (var range in ranges)
        {
            var startString = range.Split('-')[0];
            var endString = range.Split('-')[1];
            Console.WriteLine($"{startString}-{endString}");
            var interval = (Start: long.Parse(startString), End: long.Parse(endString));

            var str = startString.Remove(startString.Length / 2);
            var strStr = str + str;
            strStr = strStr.Length == 0 ? "00" : strStr;
            var longStrStr = long.Parse(strStr);

            while (true)
            {
                if (longStrStr >= interval.Start
                    && longStrStr <= interval.End)
                {
                    Console.WriteLine($"**{strStr}**");
                    result += longStrStr;
                }
                else if (longStrStr > interval.End)
                {
                    break;
                }

                str = $"{long.Parse(strStr.Remove(strStr.Length / 2)) + 1}";
                strStr = str + str;
                strStr = strStr.Length == 0 ? "00" : strStr;
                longStrStr = long.Parse(strStr);
            }
        }

        return result;
    }

    static object SolvePart2(string input)
    {
        var ranges = Parse(input);
        var result = 0d;
        foreach (var range in ranges)
        {
            var startString = range.Split('-')[0];
            var endString = range.Split('-')[1];
            Console.WriteLine($"{startString}-{endString}");
            var interval = (Start: long.Parse(startString), End: long.Parse(endString));

            var str = startString.Remove(1);
            var strStr = str + str;
            strStr = strStr.Length == 0 ? "00" : strStr;
            var longStrStr = long.Parse(strStr);
            for (var strLen = 1; strLen <= endString.Length / 2; strLen++)
            {
                while (true)
                {
                    if (longStrStr >= interval.Start
                        && longStrStr <= interval.End)
                    {
                        Console.WriteLine($"**{strStr}**");
                        result += longStrStr;
                    }
                    else if (longStrStr > interval.End)
                    {
                        break;
                    }

                    str = $"{long.Parse(strStr.Remove(strLen)) + 1}";
                    strStr = str + str;
                    strStr = strStr.Length == 0 ? "00" : strStr;
                    longStrStr = long.Parse(strStr);
                }
            }
        }

        return result;
    }
}
