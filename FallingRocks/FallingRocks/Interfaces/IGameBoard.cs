namespace FallingRocks.Interfaces
{
    public interface IGameBoard : IPrintable
    {
        void Update(int level, int speed, int score);

        void UpdateWholeBoard(int level, int speed, int score);
    }
}
