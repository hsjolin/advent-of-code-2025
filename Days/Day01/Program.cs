
namespace AdventOfCode2025;

class Program
{
    static int dial = 50;
    static int result = 0;

    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code 2025 - Day 01");
        Console.WriteLine("=============================\n");

        // Read input
        string input = File.ReadAllText("input.txt");

        // Part 1
        var part1Result = SolvePart1(input);
        Console.WriteLine($"Part 1: {part1Result}");
        Console.WriteLine();

        result = 0;
        dial = 50;

        // Part 2
        var part2Result = SolvePart2(input);
        Console.WriteLine($"Part 2: {part2Result}");
    }

    static void Rotate1(char d, int steps)
    {
        var direction = d == 'R'
            ? 1
            : -1;

        while (steps-- > 0)
        {
            dial += direction;

            if (dial < 0)
            {
                dial += 100;
            }
            else if (dial > 99)
            {
                dial -= 100;
            }
        }

        if (dial == 0)
        {
            result++;
        }
    }

    static void Rotate2(char d, int steps)
    {
        var direction = d == 'R'
            ? 1
            : -1;

        while (steps-- > 0)
        {
            dial += direction;
            
            if (dial < 0)
            {
                dial += 100;
            }
            else if (dial > 99)
            {
                dial -= 100;
            }

            if (dial == 0)
            {
                result++;
            }
        }
    }

    static object SolvePart1(string file)
    {
        var lines = Parse(file);
        foreach (var line in lines)
        {
            Rotate1(line[0], int.Parse(line[1..]));
            Console.WriteLine($"{line}: {dial}");
        }

        return result;
    }

    private static IEnumerable<string> Parse(string input)
    {
        var lines = input.Split('\n');

        foreach (var line in lines)
        {
            yield return line;
        }
    }

    static object SolvePart2(string file)
    {
        var lines = Parse(file);
        foreach (var line in lines)
        {
            Rotate2(line[0], int.Parse(line[1..]));
            Console.WriteLine($"{line}: {dial}");
        }

        return result;
    }
}
