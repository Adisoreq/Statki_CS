using System.Collections.Generic;

namespace Statki
{
    class AI
    {
        private Random rnd = new Random();

        private readonly Board _board;

        private Queue<Vector2> _PotentialSmartHits = new Queue<Vector2>();
        private List<Vector2> _Hits = new List<Vector2>();

        public AI(ref Board playerBoard)
        {
            this._board = playerBoard;
        }

        public Vector2? TryHit()
        {
            if (_PotentialSmartHits.Count == 0)
            {
                return TryRandomHit();
            }
            else
            {
                return TrySmartHit();
            }
        }

        public bool hit(Vector2 position) {
            return _board.TryHit(position.x, position.y);
        }

        public Vector2? TryRandomHit()
        {
            int x = rnd.Next(0, _board.Width - 1);
            int y = rnd.Next(0, _board.Height - 1);

            Vector2 position = new Vector2(x, y);
            if (!_Hits.Contains(position) && _board.isInBounds(x, y))
            {
                if (hit(new Vector2(x, y)))
                {
                    _PotentialSmartHits.Enqueue(new Vector2(x - 1, y));
                    _PotentialSmartHits.Enqueue(new Vector2(x + 1, y));
                    _PotentialSmartHits.Enqueue(new Vector2(x, y - 1));
                    _PotentialSmartHits.Enqueue(new Vector2(x, y + 1));
                }
                        
                _Hits.Add(position);
                return position;
            }
            return null;
        }
        public Vector2? TrySmartHit()
        {
            Vector2 pos = _PotentialSmartHits.Peek();
            _Hits.Add(pos);
            hit(_PotentialSmartHits.Dequeue());
            return pos;
        }
    }
}