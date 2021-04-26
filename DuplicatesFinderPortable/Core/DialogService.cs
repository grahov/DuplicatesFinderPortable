using DuplicatesFinderPortable.Core.Services;
using System;

namespace DuplicatesFinderPortable.Core
{
    public class DialogService : IDialogService
    {
        public void Ask(string message)
        {
            SetTypeOfMessage("?");
            Console.Write(message);
        }

        public void Info(string message)
        {
            SetTypeOfMessage("I");
            Console.Write(message);
        }

        public void Warn(string message)
        {
            SetTypeOfMessage("!");
            Console.Write(message);
        }

        private void SetTypeOfMessage(string typeChar)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write($"[{typeChar}] ");
            Console.ResetColor();
        }
    }
}
