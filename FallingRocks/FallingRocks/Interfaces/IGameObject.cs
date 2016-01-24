namespace FallingRocks.Interfaces
{
    using System;

    public interface IGameObject : IPrintable
    {
        int X { get; set; }

        int Y { get; set; }

        string Sprite { get; }

        ConsoleColor Color { get; }

        void Clear();
    }
}
