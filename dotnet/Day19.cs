class Day19
{
    public static void main()
    {
        var read = new List<string>(File.ReadAllLines("day19.input"));

        var scanners = new List<List<(int, int, int)>>();
        var current = new List<(int, int, int)>(); ;
        foreach (var item in read)
        {
            if (String.IsNullOrWhiteSpace(item))
                continue;
            if (item.StartsWith("---"))
            {
                current = new List<(int, int, int)>();
                scanners.Add(current);
            }
            else
            {
                var split = item.Split(',');
                current.Add((Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2])));
            }
        }

        var zero = scanners[0];
        scanners.RemoveAt(0);

        foreach (var scanner in scanners)
        {
            var list = new List<(int, int)>();
            foreach (var (zx, zy, zz) in zero)
            {
                foreach (var (sx, sy, sz) in scanner)
                {
                    var t = (zx - sx, zy - sy);
                    list.Add(t);
                    // var zeroed = new List<(int, int)>(scanner.Select(s => (s.Item1 + tx, s.Item2 + ty)));

                    // var test = zeroed.Where(s => zero.Contains(s)).Count();
                    // System.Console.WriteLine($"{test} {(tx, ty)} {(zx, zy)} {(sx, sy)} ");
                }
            }
            var most = (from i in list
                        group i by i into grp
                        orderby grp.Count() descending
                        select grp.Key).First();
            System.Console.WriteLine(most);

        }

    }


}