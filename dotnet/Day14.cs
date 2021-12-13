class Day14
{
    public static void main()
    {
        var test = File.ReadAllLines("day14.input");
        var numbers = test.Select(x => Convert.ToInt32(x)).ToArray();
        var cities = new Dictionary<string, string>() {
            {"UK", "London, Manchester, Birmingham"},
            {"USA", "Chicago, New York, Washington"},
            {"India", "Mumbai, New Delhi, Pune"}
        };
        (int, int)[] test2 = { (1, 2) };

        foreach ((var x, var y) in test2)
        {
            System.Console.WriteLine(x.ToString() + " " + y.ToString());
        }

    }
}