using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morse_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] acceptedCharacters = 
            {
                'a', 'b', 'c', 'd', 'e',
                'f', 'g', 'h', 'i', 'j',
                'k', 'l', 'm', 'n', 'o',
                'p', 'q', 'r', 's', 't',
                'u', 'v', 'w', 'x', 'y',
                'z', '0', '1', '2', '3',
                '4', '5', '6', '7', '8',
                '9'
            };

            string[] morseCharacters =
            {
                "._", "_...", "_._.", "_..", ".",
                ".._.", "__.", "....", "..", ".___",
                "_._", "._..", "__", "_.", "___",
                ".__.", "__._", "._.", "...", "_",
                ".._", "..._", ".__", "_.._", "_.__",
                "__..", ".____", "..___", "...__", "...._",
                ".....", "_....", "__...", "___..", "____.",
                "_____"
            };

            Console.WriteLine("Please input a message to be translated into morse code:");
            string originalMessage = Console.ReadLine();
            string morseMessage = "";
            string[] arrayMessage = originalMessage.Split(' ');

            for (int i = 0; i <= arrayMessage.Length - 1; i++)
            {
                for (int j = 0; j <= arrayMessage[i].Length - 1; j++)
                {
                    for (int k = 0; k <= acceptedCharacters.Length - 1; k++)
                    {
                        if (arrayMessage[i][j] == acceptedCharacters[k])
                        {
                            morseMessage += morseCharacters[k];
                            break;
                        }
                    }
                    if (j != arrayMessage[i].Length - 1) morseMessage += "   ";
                }
                if (i != arrayMessage.Length - 1) morseMessage += "   |   ";
            }
            Console.WriteLine(morseMessage);
            Console.ReadKey();
        }
    }
}
