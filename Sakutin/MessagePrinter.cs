using System;

namespace Sakutin
{
    public class MessagePrinter
    {
        private MessagePrinter()
        {
            
        }

        public static void Print(string message, ConsoleColor color = default)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
        }
    }
}