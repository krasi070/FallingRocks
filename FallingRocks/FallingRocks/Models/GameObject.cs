namespace FallingRocks
{
    using System;
    using Interfaces;

    public abstract class GameObject : IGameObject
    {
        private const ConsoleColor DefaultColor = ConsoleColor.White;

        private int x;
        private int y;
        private string sprite;

        public GameObject(int x, int y, string sprite, ConsoleColor color = DefaultColor)
        {
            this.X = x;
            this.Y = y;
            this.Sprite = sprite;
            this.Color = color;
        }

        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("X", "X coordinate cannot be negative.");
                }

                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Y", "Y coordinate cannot be negative.");
                }

                this.y = value;
            }
        }

        public string Sprite
        {
            get
            {
                return this.sprite;
            }

            private set
            {
                if (value.Length < 1 || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Sprite", "Sprite must be at least one character long.");
                }

                this.sprite = value;
            }
        }

        public ConsoleColor Color { get; private set; }

        public void Print()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.ForegroundColor = this.Color;
            Console.Write(this.Sprite);
        }

        public void Clear()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.ForegroundColor = this.Color;
            Console.Write(new string(' ', this.Sprite.Length));
        }
    }
}
