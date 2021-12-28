
class Day18
{
    abstract class Element
    {
        static public string cutEnd(string str)
        {
            var open = 1;
            var i = 1;
            while (open > 0)
            {
                if (str[i] == '[')
                    open++;
                if (str[i] == ']')
                    open--;
                i++;
            }
            return str.Substring(0, i);
        }
        static public Element parse(string str)
        {
            if (str[0] != '[') throw new Exception("First char not [");

            Element left;
            Element right;
            int startRight;
            if (Char.IsDigit(str[1]))
            {
                left = new Number(Convert.ToInt32(str[1].ToString()));
                startRight = 3;
            }
            else
            {
                var sub = cutEnd(str.Substring(1));
                left = Element.parse(sub);
                startRight = 3 + sub.Length - 1;
            }

            if (Char.IsDigit(str[startRight]))
                right = new Number(Convert.ToInt32(str[startRight].ToString()));
            else
                right = Element.parse(cutEnd(str.Substring(startRight)));
            return new Pair(left, right);
            throw new Exception("First char not [");
        }



    }
    class Number : Element
    {
        public Number(int value)
        {
            Value = value;
        }

        public int Value { get; set; }


        public override string? ToString()
        {
            return Value.ToString();
        }
    }
    class Pair : Element
    {
        public Pair(Element left, Element right)
        {
            Left = left;
            Right = right;
        }

        public Element Left { get; set; }
        public Element Right { get; set; }

        public override string? ToString()
        {
            return $"[{Left.ToString()},{Right.ToString()}]";
        }
        static public bool CanExplode(Pair e)
        {

            return CanExplode(e, 0);
        }
        static bool CanExplode(Pair e, int depth)
        {
            if (e.Left is Number && e.Right is Number)
            {
                if (depth >= 4)
                    return true;
                return false;
            }
            bool lval = false;
            if (e.Left is Pair left)
                lval = CanExplode(left, depth + 1);
            bool rval = false;
            if (e.Right is Pair right)
                rval = CanExplode(right, depth + 1);

            return rval || lval;
        }
    }
    public static void main()
    {
        var read = new List<string>(File.ReadAllLines("day18.input"));

        foreach (var item in read)
        {
            var test = Element.parse(item);
            if (test is Pair t)
                System.Console.WriteLine(Pair.CanExplode(t));
        }


    }
}