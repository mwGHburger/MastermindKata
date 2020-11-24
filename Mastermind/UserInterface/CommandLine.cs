using System;

namespace Mastermind
{
    public class CommandLine : IUserInterface
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }

        public void Print(string input)
        {
            Console.WriteLine(input);
        }
    }
}