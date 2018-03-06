using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace ConsoleTests
{
    class Program
    {
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/anonymous-functions
        delegate string BuzzFizz0(int index);

        static void Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();

            var oneToHundred = Enumerable.Range(1, 100).ToList();
            //CodingExercises.CodingExercises.BuzzFizz(100).ToList().ForEach(Console.WriteLine);

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

            Console.WriteLine(stopwatch.Elapsed.TotalSeconds.ToString(NumberFormatInfo.InvariantInfo));

            Console.ReadLine();
        }

        public static void Old()
        {
            CodingExercises.CodingExercises.BuzzFizz(100).ToList().ForEach(Console.WriteLine);
        }
    }
}
