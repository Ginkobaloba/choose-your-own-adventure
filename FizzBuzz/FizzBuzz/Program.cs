using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int index = 0; index < 101; index++)
            {
                if (index % 3 == 0 && index % 5 == 0)
                    {
                    Console.WriteLine("FizzBuzz");
                     }
                else if (index % 3 == 0)
                    {
                    Console.WriteLine("buzz");
                    }
                else if (index % 5 == 0)
                    {
                    Console.WriteLine("fizz");
                    }
                else
                    {
                    Console.WriteLine(index);
                    }
            }
            Console.ReadLine();
        }
    }
}
