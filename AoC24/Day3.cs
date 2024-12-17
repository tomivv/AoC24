using System.Text.RegularExpressions;

namespace AoC24;

public partial class Day3
{
    private readonly string _path = Path.Combine(Environment.CurrentDirectory, "Resources", "Day3.txt");
    public void Run()
    {
        var result = 0;
        var input = File.ReadAllText(_path);
        
        var matches = SecondRegex().Matches(input);
        var enabled = true;
        matches.ToList().ForEach(m =>
        {
            enabled = m.Value switch
            {
                "don't()" => false,
                "do()" => true,
                _ => enabled
            };
            if (m.Value.Equals("don't()") || m.Value.Equals("do()"))
            {
                return;
            }
            var test = 1;
            MyIntRegex().Matches(m.Value).ToList().ForEach(n =>
            {
                test *= int.Parse(n.Value);
            });
            if(enabled) result += test;
        });
        Console.WriteLine(result);
    }

    // [GeneratedRegex(@"(mul)\([0-9]{0,3},[0-9]{0,3}\)+")]
    // private static partial Regex MyRegex();
    
    [GeneratedRegex(@"[0-9]+")]
    private static partial Regex MyIntRegex();
    
    [GeneratedRegex(@"(mul)\([0-9]{0,3},[0-9]{0,3}\)|(don't\(\)|do\(\))")]
    private static partial Regex SecondRegex();
}