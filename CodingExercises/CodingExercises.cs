using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

// https://leetcode.com/danielbowen/
namespace CodingExercises
{
    public class CodingExercises
    {
        /// <summary>
        /// GenomicRangeQuery
        /// Find the Minimal nucleotide from a range of sequence DNA.
        /// 
        /// A DNA sequence can be represented as a string consisting of the letters A, C, G and T, 
        /// which correspond to the types of successive nucleotides in the sequence. Each nucleotide has an impact factor, 
        /// which is an integer. Nucleotides of types A, C, G and T have impact factors of 1, 2, 3 and 4, respectively. 
        /// You are going to answer several queries of the form: What is the minimal impact factor of nucleotides 
        /// contained in a particular part of the given DNA sequence?
        /// 
        /// For example, given the string S = CAGCCTA and arrays P, Q such that:
        /// P[0] = 2    Q[0] = 4
        /// P[1] = 5    Q[1] = 5
        /// P[2] = 0    Q[2] = 6 
        /// the function should return the values[2, 4, 1]
        /// 
        /// Lesson 5 Prefix Sums, GenomicRangeQuery: https://app.codility.com/demo/results/trainingAWGV3Y-F63/
        /// </summary>
        /// <param name="S">a non-empty string S consisting of N characters. Which represent nucleotide</param>
        /// <param name="P">non-empty array P</param>
        /// <param name="Q">non-empty arrays Q</param>
        /// <returns>an array consisting of M integers specifying the consecutive answers to all queries</returns>
        public static int[] GenomicRangeQuery(string S, int[] P, int[] Q)
        {
            S = S.ToUpper();
            var M = P.Length;
            var minimalImpactFactors = new int[M];

            for (int K = 0; K < M; K++)
            {
                //var sSubstring = (P[K] == Q[K]) ? S.Substring(P[K], 1) : S.Substring(P[K], Q[K] - 1);
                var sSubstring = S.Substring(P[K], Q[K] - P[K] + 1);
                var substringImpactFactors = new int[sSubstring.Length];

                for (int nucleotidePosition = 0; nucleotidePosition < sSubstring.Length; nucleotidePosition++)
                {
                    var nucleotide = sSubstring[nucleotidePosition];
                    switch (nucleotide)
                    {
                        case 'A':
                            substringImpactFactors[nucleotidePosition] = 1;
                            break;
                        case 'C':
                            substringImpactFactors[nucleotidePosition] = 2;
                            break;
                        case 'G':
                            substringImpactFactors[nucleotidePosition] = 3;
                            break;
                        case 'T':
                            substringImpactFactors[nucleotidePosition] = 4;
                            break;
                        default:
                            break;
                    }
                }

                minimalImpactFactors[K] = substringImpactFactors.Min();
            }

            return minimalImpactFactors;
        }

        /// <summary>
        /// A Tic-Tac-Toe board is given as a string array board. 
        /// Return True if and only if it is possible to reach this board 
        /// position during the course of a valid tic-tac-toe game.
        /// 
        /// The board is a 3 x 3 array, and consists of characters " ", "X", and "O".  The " " character represents an empty square.
        /// 
        /// Rules:
        /// Players take turns placing characters into empty squares (" ").
        /// The first player always places "X" characters, while the second player always places "O" characters.
        /// "X" and "O" characters are always placed into empty squares, never filled ones.
        /// The game ends when there are 3 of the same (non-empty) character filling any row, column, or diagonal.
        /// The game also ends if all squares are non-empty.
        /// No more moves can be played if the game is over.
        /// 
        /// Taken from leet code exercise 794. Valid Tic-Tac-Toe. On March 3rd, 2018 contest 74.
        /// https://leetcode.com/contest/weekly-contest-74/problems/valid-tic-tac-toe-state/
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static bool ValidTicTacToe(string[] board)
        {
            var boardStringBuilder = new StringBuilder();

            foreach (var row in board)
            {
                boardStringBuilder.Append(row);
            }

            var boardString = boardStringBuilder.ToString();
            var oTokenCount = boardString.Count(position => position == 'O');
            var xTokenCount = boardString.Count(position => position == 'X');
            var totalTokens = oTokenCount + xTokenCount;
            var row1 = board[0];
            var row2 = board[1];
            var row3 = board[2];
            var allORow = "OOO";
            var allXRow = "XXX";

            if (row1 == allXRow && row3 == allORow)
            {
                return false;
            }

            // If the first turn isn't X
            if (totalTokens == 1 && boardString.Any(position => position == 'O'))
            {
                return false;
            }

            // The player moves more turns than possible
            if (oTokenCount > xTokenCount + 1 || xTokenCount > oTokenCount + 1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Count the number of passing cars on the road.
        /// 
        /// The consecutive elements of array A represent consecutive cars on a road.
        /// Array A contains only 0s and/or 1s: 0 represents a car traveling east, 1 represents a car traveling west.
        /// The goal is to count passing cars
        /// 
        /// Example: A = { 0, 1, 0, 1, 1 }
        /// We have five pairs of passing cars: (0, 1), (0, 3), (0, 4), (2, 3), (2, 4).
        /// 
        /// Lesson 5 Prefix Sums, PassingCars: https://app.codility.com/demo/results/trainingQFH3G3-EWV/
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int PassingCars(int[] cars)
        {
            var passingCarsCount = 0;
            var carsLength = cars.Length;

            for (int index = 0; index < carsLength; index++)
            {
                if (cars[index] == 0)
                {
                    passingCarsCount += cars
                        .TakeLast(carsLength - index)
                        .Count(car0 => car0 == 1);
                }
            }

            return passingCarsCount;
        }

        /// <summary>
        /// Compute number of integers divisible by k in range[a..b].
        /// { i : A ≤ i ≤ B, i mod K = 0 }
        /// 
        /// For A = 6, B = 11 and K = 2, your function should return 3, because there are three
        /// numbers divisible by 2 within the range [6..11], namely 6, 8 and 10.
        /// 
        /// Lesson 5 Prefix Sums, CountDiv: https://app.codility.com/demo/results/trainingNR4JZN-MA5/
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="K">Given three integers A, B and K, returns the number of integers within the range [A..B] that are divisible by K</param>
        /// <returns></returns>
        public static int CountDiv(int A, int B, int K)
        {
            var divisibleByKCounts = 0;

            while (A <= B)
            {
                if (A % K == 0)
                {
                    divisibleByKCounts++;
                }

                A++;
            }

            return divisibleByKCounts;
        }

        /// <summary>
        /// Calculate the values of counters after applying all alternating operations: increase counter by 1; set value of all counters to current maximum. 
        /// 
        /// You are given N counters, initially set to 0, and you have two possible operations on them:
        /// increase(X) − counter X is increased by 1,
        /// max counter − all counters are set to the maximum value of any counter.
        /// 
        /// A non-empty zero-indexed array A of M integers is given. This array represents consecutive operations:
        /// if A[K] = X, such that 1 ≤ X ≤ N, then operation K is increase(X),
        /// if A[K] = N + 1 then operation K is max counter.
        /// 
        /// Example: N = 5, A =  { 3, 4, 4, 6, 1, 4, 4 }
        /// The values of the counters after each consecutive operation will be:
        /// (0, 0, 1, 0, 0)
        /// (0, 0, 1, 1, 0)
        /// (0, 0, 1, 2, 0)
        /// (2, 2, 2, 2, 2)
        /// (3, 2, 2, 2, 2)
        /// (3, 2, 2, 3, 2)
        /// (3, 2, 2, 4, 2)
        /// 
        /// Lesson 4 Counting Elements, MaxCounters: https://app.codility.com/demo/results/training9UXW39-KJ7/
        /// </summary>
        /// <param name="N"></param>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int[] MaxCounters(int N, int[] A)
        {
            int[] counters = new int[N];

            for (int index = 0; index < N; index++)
            {
                counters[index] = 0;
            }

            foreach (var counterIndex in A)
            {
                if (counterIndex == N + 1)
                {
                    counters = SetAllMaxCounter(counters);
                }
                else
                {
                    counters = IncreaseCounter(counters, counterIndex);
                }
            }

            return counters;
        }

        public static int[] SetAllMaxCounter(int[] counters)
        {
            var currentMaxCounter = counters.Max();

            for (int index = 0; index < counters.Length; index++)
            {
                counters[index] = currentMaxCounter;
            }

            return counters;
        }

        public static int[] IncreaseCounter(int[] counters, int counterIndex)
        {
            counters[counterIndex - 1] += 1;
            return counters;
        }

        /// <summary>
        /// Given a treenode root, Returns the minimum difference in a Binary Search Tree
        /// Note that root is a TreeNode object, not an array.
        /// The given tree [4,2,6,1,3,null,null] is represented by the following diagram:
        ///      4
        ///    /   \
        ///  2      6
        /// / \    
        ///1   3  
        /// root = [4,2,6,1,3,null,null] returns 1
        /// While the minimum difference in this tree is 1, it occurs between node 1 and node 2, also between node 3 and node 2.
        /// 
        /// The size of the BST will be between 2 and 100.
        /// The BST is always valid, each node's value is an integer, and each node's value is different.
        /// 
        /// https://leetcode.com/problems/minimum-distance-between-bst-nodes/description/
        /// </summary>
        /// <param name="root">The root of the BST</param>
        /// <returns>Returns the minimum difference in a Binary Search Tree</returns>
        public static int MinDiffInBST(TreeNode root)
        {
            return MinimumDifferenceFromChildrenInBST(root);
        }

        public static int MinimumDifferenceFromChildrenInBST(TreeNode parent, int minimum = int.MaxValue)
        {
            int parentValue = parent.val;
            int? diff1 = null;
            int? diff2 = null;

            if (parent.left == null && parent.right == null)
            {
                return minimum;
            }

            if (parent.left != null)
            {
                diff1 = Math.Abs(parent.left.val - parentValue);
            }

            if (parent.right != null)
            {
                diff2 = Math.Abs(parent.right.val - parentValue);
            }

            int leftMinimum = int.MaxValue;
            int rightMinimum = int.MaxValue;

            if (diff1.HasValue && diff2.HasValue)
            {
                int currentMinimum = Math.Min(diff1.Value, diff2.Value);
                minimum = Math.Min(currentMinimum, minimum);
                leftMinimum = MinimumDifferenceFromChildrenInBST(parent.left, minimum);
                rightMinimum = MinimumDifferenceFromChildrenInBST(parent.right, minimum);
            }
            else if (diff1.HasValue && !diff2.HasValue)
            {
                minimum = Math.Min(diff1.Value, minimum);
                leftMinimum = MinimumDifferenceFromChildrenInBST(parent.left, minimum);
            }
            else if (!diff1.HasValue && diff2.HasValue)
            {
                minimum = Math.Min(diff2.Value, minimum);
                rightMinimum = MinimumDifferenceFromChildrenInBST(parent.right, minimum);
            }

            return Math.Min(leftMinimum, rightMinimum);
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int x) { val = x; }
        }

        /// <summary>
        /// Find the earliest time when a frog can jump to the other side of a river.
        /// 
        /// Example: X = 5 and A = { 1, 3, 1, 4, 2, 3, 5, 4 } will return 6.
        /// 
        /// Assume that:
        /// N and X are integers within the range [1..100,000];
        /// Each element of array A is an integer within the range[1..X].
        /// 
        /// Lesson 4 Counting Elements, FrogRiverOne: https://app.codility.com/demo/results/training4EMYDU-2WD/
        /// </summary>
        /// <param name="X">The opposite bank (position X+1) of the starting frog at postion 0.</param>
        /// <param name="A">A zero-indexed array A consisting of N integers representing the falling leaves.
        /// A[K] represents the position where one leaf falls at time K, measured in seconds.</param>
        /// <returns>The time that the frog has to jump to get across the river at X</returns>
        public static int FrogRiverOne(int X, int[] A)
        {
            if (A.FirstOrDefault(index => index == X) != 0)
            {
                return A.ToList().FindIndex(index => index == X);
            }

            return -1;
        }

        /// <summary>
        /// If Key is both in x and y: Add value x from key y
        /// If Key is in x but not in y: Set value for Key x to 0
        /// If Key is in y but not in x: Value for Key y to x ???
        /// 
        /// From the Clearview written test taken and remembered on 2/1/2018
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void ModifyDictionary(Dictionary<string, int> x, Dictionary<string, int> y)
        {
            foreach (var pairX in x)
            {
                if (y.ContainsKey(pairX.Key))
                {
                    x.Remove(pairX.Key);
                    x.Add(pairX.Key, y.GetValueOrDefault(pairX.Key) + pairX.Value);
                }
                else
                {
                    x.Remove(pairX.Key);
                    x.Add(pairX.Key, 0);
                }

                foreach (var pairY in y)
                {
                    if (!x.ContainsKey(pairY.Key))
                    {
                        y.Remove(pairY.Key);
                        y.Add(pairY.Key, pairX.Value);
                    }
                }
            }
        }

        /// <summary>
        /// Returns a list of strings which contains numbers one to one hundred
        /// However, if the number divides by 3 then it will be "Buzz"
        /// If the number divides by 5 then it will be "Fizz"
        /// If the number divides by 3 and 5 it will be "BuzzFizz"
        /// 
        /// From the Clearview written test taken and remembered on 2/1/2018
        /// Also on FFS Connect Interview on 3/5/2018
        /// I modified this common question in response to this video: https://www.youtube.com/watch?v=QPZ0pIK_wsc&index=19&t=281s&list=PLym3GYqheKWCfxX-XYWjaxc7hs2Dc64S5
        /// </summary>
        /// <returns>List one to hundred with weird words put in numbers divisible by 3 or/and 5</returns>
        public static IEnumerable<string> BuzzFizz(int maxValue)
        {
            var output = new StringBuilder();

            for (int index = 1; index < maxValue + 1; index++)
            {
                output.Clear();

                if (index % 3 == 0)
                {
                    output.Append("Buzz");
                }

                if (index % 5 == 0)
                {
                    output.Append("Fizz");
                }

                if (output.ToString() == string.Empty)
                {
                    output.Append($"{index}");
                }

                yield return output.ToString();
            }
        }

        /// <summary>
        /// Returns the fibanacci sequence for the given length.
        /// 
        /// From the Clearview written test taken and remembered on 2/1/2018
        /// </summary>
        /// <param name="length">The length of the returning array</param>
        /// <returns>An array of fibonacci numbers</returns>
        public static int[] Fibonacci(int length)
        {
            int[] fibonacciArray = new int[length];

            if (length == 0)
            {
                return new int[0];
            }

            if (length >= 1)
            {
                fibonacciArray[0] = 0;
            }

            if (length >= 2)
            {
                fibonacciArray[1] = 1;
            }

            if (length >= 3)
            {
                for (int index = 2; index < length; index++)
                {
                    fibonacciArray[index] = fibonacciArray[index - 2] + fibonacciArray[index - 1];
                }
            }

            return fibonacciArray;
        }

        /// <summary>
        /// Returns the square root of a number which must divide evenly
        /// 
        /// From the Clearview written test taken and remembered on 2/1/2018
        /// </summary>
        /// <param name="number">A number that must divide evenly</param>
        /// <returns>The Square root of the input number or zero if can't divide evenly.</returns>
        public static int SquareRoot(int number)
        {
            for (int index = 0; index < number; index++)
            {
                if (index * index == number)
                {
                    return index;
                }
            }

            return 0;
        }

        /// <summary>
        /// A permutation is a sequence containing each element from 1 to N once, and only once.
        /// The goal is to check whether array A is a permutation.
        /// 
        /// A = { 4, 1, 3, 2} returns 1
        /// A = { 4, 1, 3 } returns 0
        /// 
        /// Lesson 4 Counting Elements, PermCheck: https://app.codility.com/demo/results/training3ZBQZE-85C/
        /// </summary>
        /// <param name="A">A zero-indexed array A</param>
        /// <returns>Returns 1 if array A is a permutation and 0 if it is not.</returns>
        public static int PermutationCheck(int[] A)
        {
            Array.Sort(A);

            for (int index = 1; index < A.Length + 1; index++)
            {
                if (index != A[index - 1])
                {
                    return 0;
                }
            }

            return 1;
        }

        /// <summary>
        /// Returns the Leftmost position at which A Occurs in B
        /// Returns -1 if cannot find A or is not within range.
        /// 
        /// Given A = 53 and B = 1953786 The function returns 2 
        /// 
        /// NICE inContact Codility test - Task 1, Taken 1/15/18
        /// </summary>
        /// <param name="A">A non-negative integer that might occur in B</param>
        /// <param name="B">A non-negative integer.</param>
        /// <returns>The Leftmost position at which A Occurs in B</returns>
        public static int LeftmostPositonAInB(int A, int B)
        {
            if (A < 0 || B < 0 || A > 999999999 || B > 999999999)
            {
                return -1;
            }

            var aSubstring = Convert.ToString(A, 10);
            var bSubstring = Convert.ToString(B, 10);

            if (bSubstring.Contains(aSubstring))
            {
                return bSubstring.IndexOf(aSubstring);
            }

            return -1;
        }

        /// <summary>
        /// Returns an array which represents number X+1 where X is the input array represented as a decimal number.
        /// 
        /// Given A = { 1, 4, 3, 9, 9 } which is 14399 in decimal
        /// Returns { 1, 4, 4, 0, 0 } or 14400 in decimal which is 14399 + 1
        /// 
        /// NICE inContact Codility test - Task 2, Taken 1/15/18
        /// </summary>
        /// <param name="A">Array of N digits. Number represented by this array is a number
        /// which is concatanation of consecutive digits in the array called X</param>
        /// <returns>An array which represents number X+1</returns>
        public static int[] ArrayAsDecimalPlusOne(int[] A)
        {
            // If A has leading zeros the function should return empty array.
            if (A.FirstOrDefault() == 0)
            {
                return new int[0];
            }

            var stringBuilder = new StringBuilder();

            foreach (var value in A)
            {
                stringBuilder = stringBuilder.Append(value.ToString());
            }

            var decimalString = stringBuilder.ToString();

            // If the array will contain any number exept 0 to 9 the fuction should return an empty array;
            if (Regex.IsMatch(decimalString, @"\D"))
            {
                return new int[0];
            }

            int X;
            int.TryParse(decimalString, out X);

            var xPlus1 = X + 1;
            var xPlus1String = Convert.ToString(xPlus1, 10);
            int[] xPlus1Array = new int[xPlus1String.Length];

            for (int index = 0; index < xPlus1String.Length; index++)
            {
                int xPlus1ArrayValue = 0;
                int.TryParse(xPlus1String[index].ToString(), out xPlus1ArrayValue);

                xPlus1Array[index] = xPlus1ArrayValue;
            }

            return xPlus1Array;
        }

        /// <summary>
        /// Returns a new string from the string S consisting only of the letters "A", "B", and "C" by replacing 
        /// the initial letters by following rules.
        /// 
        /// Rules:
        /// 1. substitute one occurrence of "AB" with "AA",
        /// 2. substitute one occurrence of "BA" with "AA",
        /// 3. substitute one occurrence of "CB" with "CC",
        /// 4. substitute one occurrence of "BC" with "CC",
        /// 5. substitute one occurrence of "AA" with "A",
        /// 6. substitute one occurrence of "CC" with "C",
        /// 
        /// If there is at leas one useful rule, one of the useful rules is picked at random and the string is transformed according
        /// to that rule (exactly one occurrence should be substituted). As long as there are useful rules, the above process should
        /// be repeated.
        /// 
        /// Given S = "ABBCC" the function may return "AC" because this is one of the possible sequences of tranformations.
        /// 
        /// NICE inContact Codility test - Task 3, Taken 1/15/18
        /// </summary>
        /// <param name="S">A string consisiting only of the letters "A", "B", and "C"</param>
        /// <returns>Any string that can result from a sequence of transformations described in the rules.</returns>
        public static string ReplaceStringUsingRules(string S)
        {
            while (StringRuleCheck(S))
            {
                S = StringReplaceUsingRules(S);
            }

            return S;
        }

        /// <summary>
        /// Replaces the string with new characters by using rules once for each rule.
        /// </summary>
        /// <param name="S">A string consisiting only of the letters "A", "B", and "C"<</param>
        /// <returns>A new string by using each of the rules on string S</returns>
        public static string StringReplaceUsingRules(string S)
        {
            if (S.Contains("AB"))
            {
                S = S.Replace("AB", "AA");
            }

            if (S.Contains("BA"))
            {
                S = S.Replace("BA", "AA");
            }

            if (S.Contains("CB"))
            {
                S = S.Replace("CB", "CC");
            }

            if (S.Contains("BC"))
            {
                S = S.Replace("BC", "CC");
            }

            if (S.Contains("AA"))
            {
                S = S.Replace("AA", "A");
            }

            if (S.Contains("CC"))
            {
                S = S.Replace("CC", "C");
            }

            return S;
        }

        /// <summary>
        /// Returns true if a rule can be applied to the string S
        /// </summary>
        /// <param name="S">A string consisiting only of the letters "A", "B", and "C"<</param>
        /// <returns>True if a rule can be applied to the string else it returns false</returns>
        public static bool StringRuleCheck(string S)
        {
            if (S.Contains("AB") || S.Contains("BA") || S.Contains("CB") || S.Contains("BC") || S.Contains("AA") || S.Contains("CC"))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Minimize the value |(A[0] + ... + A[P-1]) - (A[P] + ... + A[N-1])|.
        /// 
        /// Given A = { 3, 1, 2, 4, 3 } Gives A.length = 4 splits
        /// P = 1, difference = |3 − 10| = 7 
        /// P = 2, difference = |4 − 9| = 5 
        /// P = 3, difference = |6 − 7| = 1 
        /// P = 4, difference = |10 − 3| = 7 
        /// Will return 1 because that is minimal split.
        /// 
        /// Lesson 3 Time Complexity, TapeEquilibrium: https://app.codility.com/demo/results/trainingCYFX2E-YT3/
        /// </summary>
        /// <param name="A">A non-empty zero-indexed array A consisting of N integers
        ///  Array A represents numbers on a tape.</param>
        /// <returns>The minimal difference that can be achieved</returns>
        public static int TapeEquilibrium(int[] A)
        {
            var N = A.Length;
            var splits = N - 1;
            var differences = new int[splits];

            for (int P = 1; P < N; P++)
            {
                var firstPart = 0;

                for (int index = 0; index <= P - 1; index++)
                {
                    firstPart += A[index];
                }

                var secondPart = 0;

                for (int index = P; index <= N - 1; index++)
                {
                    secondPart += A[index];
                }

                var difference = firstPart - secondPart;
                differences[P - 1] = Math.Abs(difference);
            }

            return differences.Min();
        }

        /// <summary>
        /// Find the missing element in a given permutation.
        /// 
        /// Given A = { 2, 3, 1, 5 } Should return 4 because it is the missing element.
        /// A zero-indexed array A consisting of N different integers is given. 
        /// The array contains integers in the range [1..(N + 1)], which means that exactly one element is missing.
        /// 
        /// Lesson 3 Time Complexity, PermMissingElem: https://app.codility.com/demo/results/trainingEHW7KU-JQG/
        /// </summary>
        /// <param name="A">A zero-indexed array A</param>
        /// <returns>The value of the missing element.</returns>
        public static int PermutationMissingElement(int[] A)
        {
            for (int index = 1; index < A.Length + 1; index++)
            {
                if (!A.Contains(index))
                {
                    return index;
                }
            }

            return 0;
        }

        /// <summary>
        /// Count minimal number of jumps from position X to Y. 
        /// 
        /// Given X = 10, Y = 85, and D = 30. Function returns 3. Three jumps to get over Y which is 85.
        /// 
        /// Lesson 3 Time Complexity, FrogJmp: https://app.codility.com/demo/results/trainingJSF847-PR7/
        /// </summary>
        /// <param name="X">The frog starts at this position</param>
        /// <param name="Y">The frog ends equal to or greater than this Position</param>
        /// <param name="D">The Fixed Distance which the frog jumps</param>
        /// <returns> The minimal number of jumps from position X to a position equal to or greater than Y.</returns>
        public static int FrogJump(int X, int Y, int D)
        {
            var frogPosition = X;
            var minimumJumps = 0;

            while (frogPosition < Y)
            {
                frogPosition += D;
                minimumJumps++;
            }

            return minimumJumps;
        }

        /// <summary>
        /// Rotate an array to the right by a given number of steps.
        /// 
        /// Given A = {3, 8, 9, 7, 6} and K = 3
        ///   [3, 8, 9, 7, 6] -> [6, 3, 8, 9, 7]
        ///   [6, 3, 8, 9, 7] -> [7, 6, 3, 8, 9]
        ///   [7, 6, 3, 8, 9] -> [9, 7, 6, 3, 8]
        ///   Returns { 9, 7, 6, 3, 8 }
        ///   
        /// Lesson 2 Arrays, Cyclic Rotation: https://app.codility.com/demo/results/trainingTDDA2S-F3D/
        /// </summary>
        /// <param name="A">A zero-indexed array A consisting of N integers</param>
        /// <param name="K">Number of times to rotate Array</param>
        /// <returns></returns>
        public static int[] CyclicRotation(int[] A, int K)
        {
            if (K == 0)
            {
                return A;
            }

            int[] cycledArray = new int[A.Length];

            for (int index = 0; index < A.Length; index++)
            {
                if (index == 0)
                {
                    cycledArray[index] = A[A.Length - 1];
                }
                else
                {
                    cycledArray[index] = A[index - 1];
                }
            }

            K--;

            while (K > 0)
            {
                var cycledArrayLength = cycledArray.Length;
                var newArray = new int[cycledArrayLength];

                for (int index = 0; index < cycledArrayLength; index++)
                {
                    if (index == 0)
                    {
                        newArray[index] = cycledArray[A.Length - 1];
                    }
                    else
                    {
                        newArray[index] = cycledArray[index - 1];
                    }
                }

                cycledArray = newArray;
                K--;
            }

            return cycledArray;
        }

        /// <summary>
        /// Find the value that occurs in odd number of elements
        /// 
        /// Given A = { 9,  3, 9, 3, 9, 7, 9 } Returns 7 which is unpaired.
        /// 
        /// Lesson 2 Arrays, Odd Occurrences In Array: https://app.codility.com/demo/results/training2FZP6F-45M/
        /// </summary>
        /// <param name="A">A non-empty zero-indexed array A consisting of N integers is given. 
        /// The array contains an odd number of elements, and each element of the array can be paired with 
        /// another element that has the same value, except for one element that is left unpaired.</param>
        /// <returns>The value that is unpaired.</returns>
        public static int OddOccurrencesInArray(int[] A)
        {
            List<int> unpairedValues = new List<int>();
            List<int> pairedValues = new List<int>();

            for (int index = 0; index < A.Length; index++)
            {
                var currentValue = A[index];

                if (unpairedValues.Count > 0)
                {
                    if (unpairedValues.Contains(currentValue))
                    {
                        pairedValues.Add(currentValue);
                        unpairedValues.Remove(currentValue);
                    }
                    else
                    {
                        unpairedValues.Add(currentValue);
                    }
                }
                else
                {
                    unpairedValues.Add(currentValue);
                }

            }

            if (unpairedValues.Count == 1)
            {
                return unpairedValues.FirstOrDefault();
            }

            return 0;
        }

        /// <summary>
        /// Returns the length integer N's longest binary gap.
        /// 
        /// Given N = 1041 the function should return 5,
        /// Because N has binary representation 10000010001 and so its longest binary gap is of length 5.
        /// The function should return 0 if N doesn't contain a binary gap.
        /// 
        /// Lesson 1 Iterations, Binary Gap: https://app.codility.com/demo/results/trainingN6BKS2-DZJ/
        /// </summary>
        /// <param name="N">A positive integer</param>
        /// <returns>The length of its longest binary gap</returns>
        public static int LongestBinaryGap(int N)
        {
            if (N < 5)
            {
                return 0;
            }

            string binaryString = Convert.ToString(N, 2);

            if (!binaryString.Contains("0"))
            {
                return 0;
            }

            List<int> binaryGaps = new List<int>();

            for (int index = 0; index <= binaryString.Length; index++)
            {
                if (binaryString[index] == '1')
                {
                    var restOfString = binaryString.Substring(index + 1);

                    if (!restOfString.Contains("0"))
                    {
                        break;
                    }

                    char nextDigit = restOfString.ToCharArray()[0];

                    if (nextDigit == '1')
                    {
                        continue;
                    }
                    else
                    {
                        var binaryGap = 0;

                        for (int gapIndex = 0; gapIndex < restOfString.Length; gapIndex++)
                        {
                            if (restOfString[index: gapIndex] == '0')
                            {
                                binaryGap += 1;
                            }
                            else
                            {
                                binaryGaps.Add(binaryGap);
                                index += binaryGap;
                                break;
                            }
                        }
                    }
                }
            }

            var largestBinaryGap = -1;

            if (binaryGaps.Count > 0)
            {
                largestBinaryGap = binaryGaps.Max();
            }

            return largestBinaryGap;
        }

        /// <summary>
        /// Returns the smallest positive integer that doesn't occur in A.
        /// 
        /// Given A = [1, 3, 6, 4, 1, 2], the function should return 5.
        /// Given A = [1, 2, 3], the function should return 4.
        /// 
        /// Demo, Largest Sequential Integer: https://app.codility.com/demo/results/demoN4EV73-VCB/
        /// Also, Lesson 4, Missing Integer: https://app.codility.com/demo/results/trainingN638Q5-2Q4/
        /// </summary>
        /// <param name="A">Array A of N integers</param>
        /// <returns>The smallest positive integer (greater than 0) that does not occur in A.</returns>
        public static int LargestSequentialInteger(int[] A)
        {
            var minimum = A.Min();

            if (minimum > 1)
            {
                return 1;
            }

            if (minimum <= 0)
            {
                return 1;
            }

            Array.Sort(A);
            var previousInteger = 1;

            for (int index = 0; index < A.Length; index++)
            {
                var currentInteger = A[index];

                if (currentInteger == previousInteger)
                {
                    continue;
                }
                else if (currentInteger == previousInteger + 1)
                {
                    previousInteger = currentInteger;
                }
                else if (currentInteger > previousInteger + 1)
                {
                    break;
                }
            }

            return previousInteger + 1;
        }

        /// <summary>
        /// Makes an integer array of random numbers for testing.
        /// 
        /// </summary>
        /// <param name="length">The length of the array</param>
        /// <param name="minimumValue">The minimum value of the integers in the array</param>
        /// <param name="maximumValue">The maximum value of the integers within the array. Exclusive</param>
        /// <returns></returns>
        public static int[] RandomIntegerArray(int length, int minimumValue, int maximumValue)
        {
            var random = new Random();
            var integerArray = new int[length];

            for (int index = 0; index < length; index++)
            {
                integerArray[index] = random.Next(minimumValue, maximumValue);
            }

            return integerArray;
        }
    }
}
