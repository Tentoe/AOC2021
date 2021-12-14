class Day14
{
    public static void main()
    {
        var read = new List<string>(File.ReadAllLines("day14.input"));
        var template = read[0];
        read.RemoveRange(0, 2);
        var insert = read.Select(x =>
        {
            var sp = x.Split(" -> ", StringSplitOptions.None);
            return ((sp[0], sp[1]));
        }).ToArray();
        // var cities = new Dictionary<string, string>() {
        //     {"UK", "London, Manchester, Birmingham"},
        //     {"USA", "Chicago, New York, Washington"},
        //     {"India", "Mumbai, New Delhi, Pune"}
        // };
        // (int, int)[] test2 = { (1, 2) };
        var changes = new List<(string, string)>();

        foreach (var change in insert)
        {
            if (template.Contains(change.Item1))
                changes.Add(change);
        }
        foreach ((var x, var y) in changes.OrderBy(x => template.IndexOf(x.Item1)))
        {
            template = template.Replace(x, x[0].ToString() + y + x[1].ToString());
            System.Console.WriteLine(x + " " + y);

            System.Console.WriteLine(template);
        }
        System.Console.WriteLine(template);


    }
}