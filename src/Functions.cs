namespace Statki
{
    static class Cons
    {
        public static void WriteWithColor(string text, ConsoleColor color)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = previousColor;
        }
    }
}