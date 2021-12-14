using System.Text.RegularExpressions;
class Day14
{
    public static void main()
    {
        var read = new List<string>(File.ReadAllLines("day14.input"));

        var template = read[0];


        read.RemoveRange(0, 2);
        var changes = new Dictionary<string, (string, string)>();
        foreach (var item in read)
        {
            var sp = item.Split(" -> ", StringSplitOptions.None);
            changes[sp[0]] = (sp[0][0] + sp[1], sp[1] + sp[0][1]);
        }
        var occurences = new Dictionary<string, long>();

        foreach ((var x, var y) in changes)
        {
            occurences[x] = 0;
        }

        for (int i = 0; i < template.Length - 1; i++)
        {
            var pair = template[i].ToString() + template[i + 1].ToString();
            occurences[pair]++;
        }

        for (int i = 0; i < 40; i++)
        {
            System.Console.WriteLine(i);
            var nextocc = new Dictionary<string, long>(occurences);
            foreach (var item in occurences.Keys)
            {
                nextocc[item] -= occurences[item];
                (var first, var second) = changes[item];
                nextocc[first] += occurences[item];
                nextocc[second] += occurences[item];
            }
            occurences = nextocc;
        }
        var counts = new Dictionary<char, long>();
        foreach (var item in occurences.Keys)
        {
            //System.Console.WriteLine(item.ToString() + " " + occurences[item]);
            if (counts.ContainsKey(item[0]))
                counts[item[0]] += occurences[item];
            else
                counts[item[0]] = occurences[item];
        }
        counts[template.Last()]++;
        foreach (var item in counts)
        {
            System.Console.WriteLine(item.Key.ToString() + " : " + item.Value.ToString());
        }

        System.Console.WriteLine(counts.Values.Max() - counts.Values.Min());
    }
}