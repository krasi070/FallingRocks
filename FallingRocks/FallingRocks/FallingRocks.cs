namespace FallingRocks
{
    using System;
    using Interfaces;
    using Models;
    using Engine;

    public class FallingRocks
    {
        public static void Main()
        {
            ResetBuffer();
            Console.CursorVisible = false;

            Dwarf dwarf = new Dwarf(Console.WindowWidth / 2 - 2, Console.WindowHeight - 1);
            GameBoard board = new GameBoard();
            IEngine engine = new FallingRocksEngine(dwarf, board);

            engine.Run();
        }

        private static void ResetBuffer()
        {
            Console.BufferHeight = Console.WindowHeight = 30;
            Console.BufferWidth = Console.WindowWidth = 60;
        }
    }
}
