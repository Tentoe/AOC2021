class Day17
{
    private Point velocity;
    private Point position = new Point(0, 0);
    public struct Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public override string ToString() => $"({X}, {Y})";

        public override bool Equals(object? obj)
        {
            if (!(obj is Point objt)) 
                return false;
                
            return this.X == objt.X && this.Y == objt.Y;
        }
    }

    public void main()
    {
        //var line = File.ReadAllLines("day17.input")[0];
        velocity = new Point(6, 9);

        var test = (from x in Enumerable.Range(20, 10)
                    from y in Enumerable.Range(-10, 5)
                    select new Point(x, y)).ToList<Point>();

        //Step();
        foreach (var item in test)
        {
            System.Console.WriteLine(item);
        }
        System.Console.WriteLine(new Point(0, 0).Equals(new Point(0, 0)));
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