using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Statki
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello, World!");

            int[,] b1 =
            {
                { 0, 1, 1, 0, 0 },
                { 1, 0, 0, 0, 0 },
                { 1, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 1 },
                { 0, 0, 0, 0, 0 }
            };

            int[,] b2 =
            {
                { 2, 0, 0, 0, 0 },
                { 0, 2, 0, 0, 0 },
                { 0, 0, 2, 0, 0 },
                { 0, 0, 0, 2, 0 },
                { 0, 0, 0, 0, 2 }
            };

            Board board1 = new Board(b1, 1);
            Board board2 = new Board(b2, 2);

            AI bot = new AI(ref board1);

            List<Vector2> hits = [];

            while (true)
            {
                int x = 0, y = 0;
                DisplayBoards(board1, board2);

                Cons.WriteWithColor("\n\nWprowadz X: ", ConsoleColor.White);
                bool successX = int.TryParse(Console.ReadLine(), out x);
                if (!successX)
                {
                    Cons.WriteWithColor("Niepoprawna wartosc", ConsoleColor.Red);
                    continue;
                }

                Cons.WriteWithColor("Wprowadz Y: ", ConsoleColor.White);
                bool successY = int.TryParse(Console.ReadLine(), out y);
                if (!successY)
                {
                    Cons.WriteWithColor("Niepoprawna wartosc", ConsoleColor.Red);
                    continue;
                }

                Vector2 playerPos = new Vector2(x - 1, y - 1);

                if (hits.Contains(playerPos))
                {
                    Cons.WriteWithColor("\n\nJuz tam strzelales\n", ConsoleColor.Red);
                    continue;
                }
                else if (!board2.isInBounds(playerPos.x, playerPos.y)) {
                    Cons.WriteWithColor("\n\nPunkt poza plansza\n", ConsoleColor.Red);
                    continue;
                }
                else
                {
                    board2.TryHit(x - 1, y - 1);
                    hits.Add(playerPos);
                    Cons.WriteWithColor($"\n\nStrzelasz w [{x},{y}]\n", ConsoleColor.Green);
                }

                DisplayBoards(board1, board2);

                Vector2 bot_pos = bot.TryHit();
                
                if (bot_pos != null)
                {
                    Cons.WriteWithColor($"\n\nAI strzela w [{bot_pos.x + 1},{bot_pos.y + 1}]\n", ConsoleColor.Red);
                    bool hit = board1.TryHit(bot_pos.x, bot_pos.y);
                }
                else
                {
                    Cons.WriteWithColor($"\n\nAI nie moze strzelic\n", ConsoleColor.DarkRed);
                }

                Cons.WriteWithColor("\n[Kontynuuj]", ConsoleColor.Cyan);
                Console.ReadKey();
            }
        }

        static void DisplayBoards(Board board1, Board board2)
        {
            Console.Clear();

            Cons.WriteWithColor(" --- Player --- \n\n", ConsoleColor.DarkGreen);

            board1.Display();

            Cons.WriteWithColor("\n\n ---   AI   --- \n\n", ConsoleColor.DarkRed);

            board2.Display(1);
        }
    }
}
