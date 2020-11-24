namespace Mastermind
{
    public class GuessCounter : ICounter
    {
        public int CurrentCount { get; private set; } = 0;

        public void IncrementCount()
        {
            CurrentCount++;
        }
    }
}