class Day17
{
    private Point velocity;
    private Point position = new Point(0, 0);
    public struct Point
    {
        public Point(long x, long y)
        {
            X = x;
            Y = y;
        }
        public long X { get; set; }
        public long Y { get; set; }

        public override string ToString() => $"({X},{Y})";

        public override bool Equals(object? obj)
        {
            if (!(obj is Point objt))
                return false;

            return this.X == objt.X && this.Y == objt.Y;
        }

        public double Distance(Point p)
        {
            return Math.Sqrt(Math.Abs((X - p.X) * 2 + (Y - p.Y) * 2));
        }
    }

    public void main()
    {
        //var line = File.ReadAllLines("day17.input")[0];


        //var xtarget = (20, 30);
        var xtarget = (94, 151);
        //var ytarget = (-10, -5);
        var ytarget = (-156, -103);
        var test = (from x in Enumerable.Range(xtarget.Item1, xtarget.Item2 - xtarget.Item1 + 1)
                    from y in Enumerable.Range(ytarget.Item1, ytarget.Item2 - ytarget.Item1 + 1)
                    select new Point(x, y)).ToList<Point>();

        var xvel = 1;
        while (true)
        {
            var vel = (xvel * (xvel + 1)) / 2;
            var vel2 = ((xvel + 1) * (xvel + 2)) / 2;
            if (vel > xtarget.Item1 && vel < xtarget.Item2 && vel2 > xtarget.Item2)
                break;
            xvel++;
        }
        velocity = new Point(xvel, Math.Abs(ytarget.Item1) - 1);

        //Step();
        // foreach (var item in test)
        // {
        //     System.Console.WriteLine(item);
        // }

        var xval = Math.Max(xtarget.Item2, velocity.X);
        var testen = (from x in Enumerable.Range(0, (int)xval + 1)
                      from y in Enumerable.Range((int)-(velocity.Y + 1), (int)((velocity.Y + 1) * 2 + 1))
                      select new Point(x, y)).ToList<Point>();
        var solution = new List<Point>();
        System.Console.WriteLine(test.Contains(new Point(27, -5)));
        var count = 0;
        foreach (var item in testen)
        {
            System.Console.WriteLine($"{testen.Count} {count}");
            count++;
            position = new Point(0, 0);

            velocity = new Point(item.X, item.Y);

            if (new Point(30, -10).Equals(item))
            {

            }
            long maxx = 0;
            while (true)
            {
                Step();
                if (position.Y > maxx)
                    maxx = position.Y;
                if (test.Contains(position))
                {
                    solution.Add(item);
                    break;
                }
                if (position.X > xtarget.Item2 || position.Y < ytarget.Item1)
                {
                    break;
                }

            }
        }
        foreach (var item in solution)
        {
            System.Console.WriteLine(item);
        }

    }

    private void Step()
    {
        position.X += velocity.X;
        position.Y += velocity.Y;

        if (velocity.X < 0) velocity.X++;
        else if (velocity.X > 0) velocity.X--;
        velocity.Y--;

    }
}