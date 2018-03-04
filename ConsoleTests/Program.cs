using System;
using static CodingExercises.CodingExercises;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
        }

        public static void Old()
        {
            var buzzFizzWords = OneToHundredBuzzFizz();

            foreach (var word in buzzFizzWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
