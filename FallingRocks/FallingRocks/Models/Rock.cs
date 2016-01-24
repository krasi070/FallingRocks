namespace FallingRocks.Models
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class Rock : GameObject, IFallable
    {
        private static Random random = new Random();

        public Rock(string sprite, ConsoleColor color)
            : base(random.Next(0, Console.WindowWidth), 5, sprite, color)
        {
            this.ReachedBottom = false;
        }

        public bool ReachedBottom { get; private set; }
 
        public void Fall()
        {
            this.Clear();
            if (this.Y < Console.WindowHeight - 1)
            {
                this.Y++;
                this.Print();
            }
            else
            {
                this.ReachedBottom = true;
            }
        }
    }
}
