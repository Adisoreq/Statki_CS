namespace Statki
{
    internal class Board
    {
        private readonly int[] _Size; // [ X, Y ]
        private Tile[,] _Elements;
        private int _Player = 0;
        private bool[,] _Revealed;

        public int Width
        {
            get { return _Size[0]; }
            set { _Size[0] = value; }
        }
        public int Height
        {
            get { return _Size[1]; }
            set { _Size[1] = value; }
        }

        public Tile get(int x, int y)
        {
            return this._Elements[x, y];
        }

        public Board(int[,] elements, int player)
        {
            this._Size = new int[] { elements.GetLength(1), elements.GetLength(0) }; // [ X, Y ]
            this._Elements = new Tile[Width, Height];
            this._Revealed = new bool[Width, Height];

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    this._Elements[x, y] = new Tile((TileType)elements[y, x]);
                }
            }

            this._Player = player;
        }

        public bool isInBounds(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        public bool TryHit(int x, int y)
        {
            bool hit;
            TileType targetType;

            if (!isInBounds(x, y))
            {
                return false;
            }
            else
            {
                targetType = _Elements[x, y].Type;
            }

            if (targetType == TileType.Ship_P1 || targetType == TileType.Ship_P1)
            {
                _Elements[x, y].Type = TileType.Hit;
                hit = true;
            }
            else
            {
                _Elements[x, y].Type = TileType.Miss;
                hit = false;
            }

            _Revealed[x, y] = true;
            return hit;
        }

        public void Display(int PlayerID = 0)
        {
            for (int x = 0; x < Width; x++)
            {
                Console.Write("  " + (x + 1));
            }
            Console.WriteLine();

            for (int y = 0; y < Height; y++)
            {
                Console.Write(y + 1);
                for (int x = 0; x < Width; x++)
                {
                    if (PlayerID == 0 || PlayerID == this._Player || this._Revealed[x, y])
                        _Elements[x, y].Print();
                    else
                    {
                        Cons.WriteWithColor(" ? ", ConsoleColor.DarkGray);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}