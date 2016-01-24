namespace FallingRocks.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Interfaces;
    using Models;

    public class FallingRocksEngine  :IEngine
    {
        private static int score = 0;
        private static double speed = 300;
        private static int fallingRocks = 1;
        private static Random random = new Random();

        private Dwarf dwarf;
        private List<Rock> rocks;
        private IGameBoard gameBoard;

        public FallingRocksEngine(Dwarf dwarf, IGameBoard gameBoard)
        {
            this.dwarf = dwarf;
            this.gameBoard = gameBoard;
            this.rocks = new List<Rock>();
        }

        public void Run()
        {
            this.gameBoard.Print();
            this.dwarf.Print();

            Thread newThread = new Thread(MoveDwarf);
            newThread.Start();

            while (true)
            {
                // This code will make the dwarf move at the speed of the rocks which feels a bit clunky.
                // However, with this code you won't get random text appear out of nowhere for a second.
                //if (Console.KeyAvailable)
                //{
                //    ConsoleKey pressedKey = Console.ReadKey(true).Key;
                //    if (pressedKey == ConsoleKey.Escape)
                //    {
                //        Console.Clear();
                //        Environment.Exit(0);
                //    }
                //
                //    dwarf.Move(pressedKey);
                //}

                for (int i = 0; i < fallingRocks; i++)
                {
                    string rockSprite = this.GetRandomRockSprite();
                    ConsoleColor color = this.GetRandomColor();
                    Rock newRock = new Rock(rockSprite, color);
                    this.rocks.Add(newRock);
                }

                foreach (var rock in this.rocks)
                {
                    rock.Fall();
                    if ((rock.X == this.dwarf.X && rock.Y == this.dwarf.Y) ||
                        (rock.X == this.dwarf.X + 1 && rock.Y == this.dwarf.Y) ||
                        (rock.X == this.dwarf.X + 2 && rock.Y == this.dwarf.Y))
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);
                        Console.Write("Game Over!");
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2 + 1);
                        Console.Write("Level: {0}", fallingRocks);
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2 + 2);
                        Console.Write("Score: {0}", score);
                        Console.SetCursorPosition(0, Console.WindowHeight - 1);
                        ConsoleKey pressedKey = Console.ReadKey().Key;
                        if (pressedKey == ConsoleKey.Enter)
                        {
                            Environment.Exit(0);
                        }
                    }
                    else if (rock.ReachedBottom)
                    {
                        score++;
                        if (speed > 50)
                        {
                            speed -= 0.5;
                        }
                        else
                        {
                            fallingRocks++;
                            speed = 250;
                        }
                    }
                }

                this.rocks.RemoveAll(r => r.ReachedBottom);

                Thread.Sleep((int)speed);
                Console.Clear();
                this.gameBoard.UpdateWholeBoard(fallingRocks, 300 - (int)speed, score);
                this.dwarf.Print();
            }
        }

        private void MoveDwarf()
        {
            ConsoleKey pressedKey = Console.ReadKey(true).Key;
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    pressedKey = Console.ReadKey(true).Key;
                    if (pressedKey == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Environment.Exit(0);
                    }
        
                    dwarf.Move(pressedKey);
                }
            }
        }

        private string GetRandomRockSprite()
        {
            List<string> rocks = new List<string>()
            {
                ".", "!", "?", ";", ":", "#", "@"
            };

            return rocks[random.Next(0, rocks.Count)];
        }

        private ConsoleColor GetRandomColor()
        {
            List<ConsoleColor> colors = new List<ConsoleColor>()
            {
                ConsoleColor.Red,
                ConsoleColor.Blue,
                ConsoleColor.Gray,
                ConsoleColor.Magenta,
                ConsoleColor.Yellow
            };

            return colors[random.Next(0, colors.Count)];
        }
    }
}
