class Day14
{
    public static void main()
    {
        var test = File.ReadAllLines("day14.input");
        var numbers = test.Select(x => Convert.ToInt32(x)).ToArray();

        Console.WriteLine("day14");

    }
}