using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insertion_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] list = {32, 15, 2, 9, 73, -1};
            for (int i = 0; i < list.Length - 1; i++)
            {
                int count = i;
                while (count >= 0 && list[count] > list[count + 1])
                {
                    int temp = list[count + 1];
                    list[count + 1] = list[count];
                    list[count] = temp;
                    count--;
                }
            }
            foreach (int element in list) Console.WriteLine(element);
            Console.ReadKey();
        }
    }
}
