using System;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            var application = ClassInstantiatorFactory.CreateMastermindApplication();
            application.Run();
        }
    }
}
