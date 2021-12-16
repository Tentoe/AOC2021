class Day16
{
    private int versionSum = 0;
    public void main()
    {
        var line = File.ReadAllLines("day16.input")[0];

        var newline = "";

        foreach (var item in line)
        {
            var i = Convert.ToInt32(item.ToString(), 16);
            newline += Convert.ToString(i, 2).PadLeft(4, '0');

        }
        var type = GetPacketType(newline);
        var (value, length) = Packet(newline);
        System.Console.WriteLine($"type: {type} value:{value}");

        System.Console.WriteLine($"versionSum:{versionSum}");
    }
    private (List<long>, int) PacketOperator(string packets)
    {
        var lengthTypeID = Convert.ToInt32(packets.Substring(6, 1), 2);
        var length = 0;
        var values = new List<long>();
        if (lengthTypeID == 0) // Payload by length
        {
            var subPacketLength = Convert.ToInt32(packets.Substring(7, 15), 2);
            length = subPacketLength + 22;
            var subPackets = packets.Substring(22, subPacketLength);
            while (subPackets.Length > 0 && (subPackets.Length > 64 || Convert.ToInt64(subPackets, 2) != 0))
            {
                var (val, len) = Packet(subPackets);
                values.Add(val);
                subPackets = subPackets.Substring(len);
            }
        }
        else // Payload by pakage number
        {
            var subPackageNumber = Convert.ToInt32(packets.Substring(7, 11), 2);
            var subPackets = packets.Substring(18);
            length += 18;
            for (int i = 0; i < subPackageNumber; i++)
            {
                var (val, len) = Packet(subPackets);
                length += len;
                values.Add(val);
                subPackets = subPackets.Substring(len);
            }
        }
        return (values, length);
    }
    private (long, int) Packet(string subPackets)
    {
        versionSum += GetPacketVersion(subPackets);
        var type = GetPacketType(subPackets);
        if (type == Type.Literal)
            return PacketLiteral(subPackets);

        var (values, len) = PacketOperator(subPackets);
        switch (type)
        {
            case Type.Sum:
                return (values.Sum(), len);
            case Type.Product:
                return (values.Aggregate(1L, (acc, x) => acc * x), len);
            case Type.Minimum:
                return (values.Min(), len);
            case Type.Maximum:
                return (values.Max(), len);
            case Type.LessThan:
                return (values[0] < values[1] ? 1L : 0L, len);
            case Type.GreaterThan:
                return (values[0] > values[1] ? 1L : 0L, len);
            case Type.EqualTo:
                return (values[0] == values[1] ? 1L : 0L, len);
            default: 
                throw new Exception("Unkown Type");
        }

    }
    private (long, int) PacketLiteral(string packets)
    {
        var value = "";
        var lastByte = 1;
        var length = 6;
        while (lastByte > 0)
        {
            lastByte = Convert.ToInt32(packets.Substring(length, 1), 2);
            value += packets.Substring(length + 1, 4);
            length += 5;
        }
        return (Convert.ToInt64(value, 2), length);
    }

    private enum Type
    {
        Literal = 4,
        //Operators
        Sum = 0,
        Product = 1,
        Minimum = 2,
        Maximum = 3,
        GreaterThan = 5,
        LessThan = 6,
        EqualTo = 7

    }
    private static Type GetPacketType(string packets)
    {
        return (Type)Convert.ToInt32(packets.Substring(3, 3), 2);
    }

    private static int GetPacketVersion(string packets)
    {
        return Convert.ToInt32(packets.Substring(0, 3), 2);
    }
}