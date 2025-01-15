namespace Statki
{
    class Vector2
    {
        public int x, y;

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class V2B
    {
        public Vector2 v;
        public bool b;
        public V2B(Vector2 v, bool b)
        {
            this.v = v;
            this.b = b;
        }
    }
}