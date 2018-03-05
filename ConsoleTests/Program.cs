using System;
using System.Linq;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //BuzzFizz(100).ToList().ForEach(Console.WriteLine);

            string buzzFizz1(int index)
            {
                var output = string.Empty;
                if (index % 3 == 0) output += "Buzz";
                if (index % 5 == 0) output += "Fizz";
                if (output == string.Empty) output = $"{index}";
                return output;
            }

            var oneToHundred = Enumerable.Range(1, 100).ToList();

            foreach (var number in oneToHundred)
            {
                Console.WriteLine(buzzFizz1(number));
            }

            Console.ReadLine();
        }

        public static void Old()
        {
            var oneToHundred = Enumerable.Range(1, 100).ToList();
                    

        }
    }
}
