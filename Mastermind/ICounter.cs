namespace Mastermind
{
    public interface ICounter
    {
        int CurrentCount { get; }
        void IncrementCount();
    }
}