class Day1
{
    public static void main()
    {
        var test = File.ReadAllLines("day1.input");
        var numbers = test.Select(x => Convert.ToInt32(x)).ToArray();

        int counter = 0;
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            if (numbers[i] < numbers[i + 1])
                counter++;
        }
        Console.WriteLine(counter);

        int counter2 = 0;

        for (int i = 0; i < numbers.Length - 3; i++)
        {
            var sum1 = numbers[i] + numbers[i + 1] + numbers[i + 2];
            var sum2 = numbers[i + 1] + numbers[i + 2] + numbers[i + 3];
            if (sum1 < sum2)
                counter2++;
        }
        Console.WriteLine(counter2);

    }
}