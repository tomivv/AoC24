namespace AoC24;

public class DayOne
{
    private readonly string _path = Path.Combine(Environment.CurrentDirectory, "Resources", "Day1.txt");

    public void Run()
    {
        var leftNumbers = new List<int>();
        var rightNumbers = new List<int>();
        
        using (var sr = new StreamReader(_path))
        {
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                
                if (line is null || line.Length == 0) continue;
                // 21544   29737
                var numbers = line.Split("   ");
                
                if (int.TryParse(numbers[0], out var left))
                {
                    leftNumbers.Add(left);
                }

                if (int.TryParse(numbers[1], out var right))
                {
                    rightNumbers.Add(right);
                }
            }
        }

        leftNumbers.Sort();
        rightNumbers.Sort();

        var distance = leftNumbers.Select((t, i) => Math.Abs(t - rightNumbers[i])).Sum();

        SecondHalf(leftNumbers, rightNumbers);
        Console.WriteLine(distance);
    }

    private static void SecondHalf(List<int> leftNumbers, List<int> rightNumbers)
    {
        var uniqueNumbers = leftNumbers.Distinct().ToList();
        var distance = (from number in uniqueNumbers let instances = rightNumbers.Where(x => x == number).ToList() select number * instances.Count).Sum();
        Console.WriteLine(distance);
    }
}