namespace Mastermind
{
    public class ApplicationStopper : IApplicationStopper
    {
        public bool StopApplication { get; set; } = false;
    }
}