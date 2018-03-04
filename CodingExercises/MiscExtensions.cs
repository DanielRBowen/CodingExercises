using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingExercises
{
    /// <summary>
    /// See https://stackoverflow.com/questions/3453274/using-linq-to-get-the-last-n-elements-of-a-collection
    /// </summary>
    public static class MiscExtensions
    {
        // Ex: collection.TakeLast(5);
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int N)
        {
            return source.Skip(Math.Max(0, source.Count() - N));
        }
    }
}
