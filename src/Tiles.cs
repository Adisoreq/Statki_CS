namespace Statki
{
    enum TileType
    {
        Empty = 0,
        Ship_P1 = 1,
        Ship_P2 = 2,
        Hit = 3,
        Miss = 4
    }

    class Tile
    {
        public TileType Type { get; set; }

        public Tile(TileType type = TileType.Empty)
        {
            Type = type;
        }

        public void Print()
        {
            switch (Type)
            {
                case TileType.Empty:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(" . ");
                    break;
                case TileType.Ship_P1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" # ");
                    break;
                case TileType.Ship_P2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" # ");
                    break;
                case TileType.Hit:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" O ");
                    break;
                case TileType.Miss:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(" X ");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}