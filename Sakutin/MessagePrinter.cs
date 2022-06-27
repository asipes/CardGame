using System;

namespace Sakutin
{
    public class MessagePrinter
    {
        public static void Print(string message, ConsoleColor color = default, bool isNewLine = true)
        {
            Console.ForegroundColor = color;
            if (isNewLine)
            {
                message += "\n";
            }
            Console.Write(message);
        }
    }
}