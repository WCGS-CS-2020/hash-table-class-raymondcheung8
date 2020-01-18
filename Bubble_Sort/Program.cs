using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bubble_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a list to sort:");
            string message = Console.ReadLine();                     
            string[] arrayMessage = message.Split(',');

            for (int i = 0; i <= arrayMessage.Length - 2; i++)
            {
                for (int j = 0; j <= arrayMessage.Length - 2 - i; j++)
                {
                    if (Convert.ToInt64(arrayMessage[j]) > (Convert.ToInt64(arrayMessage[j + 1])))
                    {
                        string temp = arrayMessage[j + 1];
                        arrayMessage[j + 1] = arrayMessage[j];
                        arrayMessage[j] = temp;
                    }
                }
            }
            foreach (string items in arrayMessage) Console.WriteLine(items);
            Console.ReadKey();
        }
    }
}
