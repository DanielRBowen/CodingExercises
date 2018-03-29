using Microsoft.VisualStudio.TestTools.UnitTesting;
using static CodingExercises.CodingExercises;

namespace CodingExercisesTests
{
    [TestClass]
    public class CodingExercisesMSTests
    {
        [TestMethod]
        public void TestPrototype()
        {
        }

        [TestMethod]
        public void TestValidTicTacToe()
        {
            //The first player always plays "X".
            string[] board1 = { "O  ", "   ", "   " };
            Assert.AreEqual(false, ValidTicTacToe(board1));

            //Players take turns making moves.
            string[] board2 = { "XOX", " X ", "   " };
            Assert.AreEqual(false, ValidTicTacToe(board2));

            string[] board3 = { "XXX", "   ", "OOO" };
            Assert.AreEqual(false, ValidTicTacToe(board3));

            string[] board4 = { "XOX", "O O", "XOX" };
            Assert.AreEqual(true, ValidTicTacToe(board4));

            // X won and went first, yet there is an extra O
            string[] board5 = { "XXX", "XOO", "OO " };
            Assert.AreEqual(false, ValidTicTacToe(board5));
        }

        [TestMethod]
        public void TestPassingCars()
        {
            Assert.AreEqual(5, PassingCars(new int[] { 0, 1, 0, 1, 1 }));
        }

        [TestMethod]
        public void TestCountDiv()
        {
            Assert.AreEqual(3, CountDiv(6, 11, 2));
        }

        [TestMethod]
        public void TestMaxCounters()
        {
            int[] expected1 = { 3, 2, 2, 4, 2 };
            int[] actual1 = MaxCounters(5, new int[] { 3, 4, 4, 6, 1, 4, 4 });
            CollectionAssert.AreEqual(expected1, actual1);
        }

        [TestMethod]
        public void TestMinDiffInBST()
        {
            //root = [4,2,6,1,3,null,null] returns 1
            TreeNode node0 = new TreeNode(4);
            TreeNode node1 = new TreeNode(2);
            TreeNode node2 = new TreeNode(6);
            TreeNode node3 = new TreeNode(1);
            TreeNode node4 = new TreeNode(3);
            node0.left = node1;
            node0.right = node2;
            node1.left = node3;
            node1.right = node4;
            node2.left = null;
            node2.right = null;

            Assert.AreEqual(1, MinDiffInBST(node0));

            // Fails [27,null,34,null,58,50,null,44,null,null,null]

            // [90,69,null,49,89,null,52,null,null,null,null], Output: 3, Expected: 1
        }

        [TestMethod]
        public void TestFrogRiverOne()
        {
            int[] array1 = { 1, 3, 1, 4, 2, 3, 5, 4 };
            Assert.AreEqual(6, FrogRiverOne(5, array1));
        }

        [TestMethod]
        public void TestFibonacci()
        {
            int[] array1 = { 1, 4, 3, 9, 9 };
            var resultArray1 = Fibonacci(6);
            int[] expectedArray1 = { 0, 1, 1, 2, 3, 5 };
            CollectionAssert.AreEqual(expectedArray1, resultArray1);
        }

        [TestMethod]
        public void TestSquareRoot()
        {
            Assert.AreEqual(3, SquareRoot(9));
        }

        [TestMethod]
        public void TestPermutationCheck()
        {
            int[] array1 = { 4, 1, 3, 2 };
            var result1 = PermutationCheck(array1);
            Assert.AreEqual(1, result1);

            int[] array2 = { 4, 1, 3 };
            var result2 = PermutationCheck(array2);
            Assert.AreEqual(0, result2);
        }

        [TestMethod]
        public void TestLeftmostPositonAInB()
        {
            Assert.AreEqual(2, LeftmostPositonAInB(53, 1953786));
        }

        [TestMethod]
        public void TestArrayAsDecimalPlusOne()
        {
            int[] array1 = { 1, 4, 3, 9, 9 };
            var resultArray1 = ArrayAsDecimalPlusOne(array1);
            int[] expectedArray1 = { 1, 4, 4, 0, 0 };
            CollectionAssert.AreEqual(expectedArray1, resultArray1);
        }

        [TestMethod]
        public void TestReplaceStringUsingRules()
        {
            Assert.AreEqual("AC", ReplaceStringUsingRules("ABBCC"));
        }

        [TestMethod]
        public void TestTapeEquilibrium()
        {
            int[] array1 = { 3, 1, 2, 4, 3 };
            var result1 = TapeEquilibrium(array1);
            Assert.AreEqual(1, result1);

            int[] array2 = { 3, -5 }; // 3 - ( -5 ) = 8
            var result2 = TapeEquilibrium(array2);
            Assert.AreEqual(8, result2);
        }

        [TestMethod]
        public void TestPermutationMissingElement()
        {
            int[] array1 = { 2, 3, 1, 5 };
            Assert.AreEqual(4, PermutationMissingElement(array1));
        }

        [TestMethod]
        public void TestFrogJump()
        {
            Assert.AreEqual(3, FrogJump(10, 85, 30));
        }

        [TestMethod]
        public void TestCyclicRotation()
        {
            int[] array1 = { 3, 8, 9, 7, 6 };
            var resultArray1 = CyclicRotation(array1, 3);
            int[] expectedArray1 = { 9, 7, 6, 3, 8 };
            CollectionAssert.AreEqual(expectedArray1, resultArray1);
        }

        [TestMethod]
        public void TestOddOccurrencesInArray()
        {
            int[] array1 = { 9, 3, 9, 3, 9, 7, 9 };
            Assert.AreEqual(7, OddOccurrencesInArray(array1));
        }

        [TestMethod]
        public void TestLargestBinaryGap()
        {
            Assert.AreEqual(5, LongestBinaryGap(1041));
            Assert.AreEqual(0, LongestBinaryGap(15));
        }

        [TestMethod]
        public void TestLargestSequentialInteger()
        {
            int[] array1 = { 1, 3, 6, 4, 1, 2 };
            var result1 = LargestSequentialInteger(array1);
            Assert.AreEqual(5, result1);

            int[] array2 = { 1, 2, 3, };
            var result2 = LargestSequentialInteger(array2);
            Assert.AreEqual(4, result2);
        }
    }
}
