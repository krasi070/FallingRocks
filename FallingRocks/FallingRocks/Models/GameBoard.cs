namespace FallingRocks.Models
{
    using System;
    using Interfaces;

    public class GameBoard : IGameBoard
    {
        public void Print()
        {
            Console.SetCursorPosition(0, 4);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(new string('-', Console.WindowWidth));

            Console.SetCursorPosition(Console.WindowWidth / 3 - 13, 2);
            Console.Write("Level: 1");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 4, 2);
            Console.Write("Speed: 0");
            Console.SetCursorPosition(Console.WindowWidth - 15, 2);
            Console.Write("Score: 0");
        }

        public void Update(int level, int speed, int score)
        {
            Console.SetCursorPosition(Console.WindowWidth / 3 - 6, 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(level);

            Console.SetCursorPosition(Console.WindowWidth / 2 + 3, 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(speed);

            Console.SetCursorPosition(Console.WindowWidth - 8, 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(score);
        }

        public void UpdateWholeBoard(int level, int speed, int score)
        {
            Console.SetCursorPosition(0, 4);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(new string('-', Console.WindowWidth));

            Console.SetCursorPosition(Console.WindowWidth / 3 - 13, 2);
            Console.Write("Level: {0}", level);
            Console.SetCursorPosition(Console.WindowWidth / 2 - 4, 2);
            Console.Write("Speed: {0}", speed);
            Console.SetCursorPosition(Console.WindowWidth - 15, 2);
            Console.Write("Score: {0}", score);
        }
    }
}
