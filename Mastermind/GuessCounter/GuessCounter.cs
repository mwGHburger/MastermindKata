namespace Mastermind
{
    public sealed class GuessCounter : ICounter
    {
        private static readonly GuessCounter instance = new GuessCounter();  
        public int CurrentCount { get; private set; } = 0;

        public static GuessCounter Instance  
        {  
            get  
            {  
                return instance;  
            }  
        }
        public void IncrementCount()
        {
            CurrentCount++;
        }  

    }
}