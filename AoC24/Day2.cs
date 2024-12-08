namespace AoC24;

public class Day2
{
    private readonly string _path = Path.Combine(Environment.CurrentDirectory, "Resources", "Day2.txt");
    public void Run()
    {
        var lines = File.ReadAllLines(_path).ToList();
        CheckReports(lines);
    }

    private static void CheckReports(List<string> lines)
    {
        var safeReports = lines.Count;
        var unsafeReports = new List<string>();
        lines.ForEach(line =>
        {
            var splits = line.Split(' ');
            var numbers = new List<int>();
            splits.ToList().ForEach(n => numbers.Add(int.Parse(n)));

            if (CheckSafeLine(numbers)) return;
            safeReports--;
            unsafeReports.Add(line);
        });
        Console.WriteLine($"Amount of safe reports: {safeReports}");
        CheckTolerantReports(unsafeReports, safeReports);
    }
    
    private static void CheckTolerantReports(List<string> lines, int safeReports)
    {
        var tolerantReports = lines.Count;
        lines.ForEach(line =>
        {
            var splits = line.Split(' ');
            var numbers = new List<int>();
            splits.ToList().ForEach(n => numbers.Add(int.Parse(n)));
            if (!CheckTolerance(numbers))
            {
                tolerantReports--;
            }
        });
        Console.WriteLine($"Amount of safe reports with tolerance: {safeReports + tolerantReports}");
    }

    private static bool CheckSafeNumber(int current, int next, bool isIncreasing)
    {
        if (isIncreasing) return current < next && next - current <= 3;
        return current > next && current - next <= 3;
    }

    private static bool CheckSafeLine(List<int> numbers)
    {
        var increasing = numbers[0] < numbers[1];
        for (var i = 0; i < numbers.Count - 1; i++)
        {
            var current = numbers[i];
            var next = numbers[i + 1];
            if (!CheckSafeNumber(current, next, increasing)) return false;
        }
        return true;
    }
    
    private static bool CheckTolerance(List<int> numbers)
    {
        for (var i = 0; i < numbers.Count; i++)
        {
            var newLine = new List<int>(numbers);
            newLine.RemoveAt(i);
            if (CheckSafeLine(newLine)) return true;
        }
        return false;
    }
}