using System.Collections.Generic;

namespace Mastermind
{
    public interface IUserInterface
    {
        void Print(string input);
        string GetInput();
    }
}