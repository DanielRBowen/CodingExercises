using System;
using System.Linq;

namespace ConsoleTests
{
    class Program
    {
        delegate string BuzzFizz0(int index);

        static void Main(string[] args)
        {
            var oneToHundred = Enumerable.Range(1, 100).ToList();

            foreach (var number in oneToHundred)
            {
                Console.WriteLine(((BuzzFizz0)((index) =>
                {
                    var output = string.Empty;
                    if (index % 3 == 0) output += "Buzz";
                    if (index % 5 == 0) output += "Fizz";
                    if (output == string.Empty) output = $"{index}";
                    return output;
                }))(number));
            }

            Console.ReadLine();
        }

        public static void Old()
        {
            CodingExercises.CodingExercises.BuzzFizz(100).ToList().ForEach(Console.WriteLine);
            var oneToHundred = Enumerable.Range(1, 100).ToList();
        }
    }
}
