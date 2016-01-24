namespace FallingRocks.Interfaces
{
    public interface IFallable
    {
        bool ReachedBottom { get; }

        void Fall();
    }
}
