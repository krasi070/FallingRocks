namespace FallingRocks
{
    using System;
    using Interfaces;

    public class Dwarf : GameObject, IMovable
    {
        private const string DwarfSprite = "(0)";

        public Dwarf(int x, int y)
            : base(x, y, DwarfSprite)
        {
 
        }

        public void Move(ConsoleKey direction)
        {
            this.Clear();

            switch (direction)
            {
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    if (this.X < Console.WindowWidth - 4)
                    {
                        this.X++;
                    }

                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    if (this.X > 0)
                    {
                        this.X--;
                    }

                    break;
            }

            this.Print();
        }
    }
}
