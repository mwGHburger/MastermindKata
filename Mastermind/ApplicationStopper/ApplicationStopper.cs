namespace Mastermind
{
    public sealed class ApplicationStopper : IApplicationStopper
    {
        public bool StopApplication { get; set; } = false;
        private static readonly ApplicationStopper instance = new ApplicationStopper();  
        public static ApplicationStopper Instance  
        {  
            get  
            {  
                return instance;  
            }  
        }  
    }
}