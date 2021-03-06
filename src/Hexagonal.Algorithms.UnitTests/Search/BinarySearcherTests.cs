﻿using Hexagonal.Algorithms.Search;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Linq;

namespace Hexagonal.Algorithms.UnitTests.Search
{
    /*The name of your test should consist of three parts:
       1.The name of the method being tested.
       2.The scenario under which it's being tested.
       3.The expected behavior when the scenario is invoked.
    Write the less correct cases
    Write more test cases on negative sceniors and expections cases
     */

    /// <summary>
    /// TODO : Need to different data types to test the algorithm
    /// </summary>
    public static class BinarySearcherTests
    {
        [Test]
        public static void FindIndex_CorrectItemInList_CorrectIndex([Random(1, 1_000, 100)] int maxLimit)
        {
            //Arrange
            var searcher = new BinarySearcher<int>();
            var randomizer = Randomizer.CreateRandomizer();
            var inputArray = Enumerable.Range(0, maxLimit).Select(t => randomizer.Next(0, 1_000)).OrderBy(t => t).ToArray();
            var selectedIndex = randomizer.Next(0, maxLimit);

            //Act
            var actualIndex = searcher.FindIndex(inputArray, inputArray[selectedIndex]);

            //Assert
            Assert.AreEqual(inputArray[selectedIndex], inputArray[actualIndex]);
        }

        [Test]
        public static void FindIndex_MissingItem_MinusOneRetured([Random(0, 1000, 100)] int maxLimit, [Random(-100, 1100, 10)] int missingItem)
        {
            // Arrange
            var searcher = new BinarySearcher<int>();
            var random = Randomizer.CreateRandomizer();
            var inputArray = Enumerable.Range(0, maxLimit).Select(x => random.Next(0, 1000)).Where(x => x != missingItem).OrderBy(x => x).ToArray();

            // Act
            var actualIndex = searcher.FindIndex(inputArray, missingItem);

            // Assert
            Assert.AreEqual(-1, actualIndex);
        }

        [Test]
        public static void FindIndex_ArrayEmpty_MinusOneReturned([Random(100)] int itemToSearch)
        {
            // Arrange
            var searcher = new BinarySearcher<int>();
            var inputArray = new int[0];

            // Act
            var actualIndex = searcher.FindIndex(inputArray, itemToSearch);

            // Assert
            Assert.AreEqual(-1, actualIndex);
        }

        [Test]
        public static void FindIndex_NullArray_MinusOneReturned([Random(100)] int itemToSearch)
        {
            //Arrange
            var searcher = new BinarySearcher<int>();
            var randomizer = Randomizer.CreateRandomizer();
            int[] inputArray = null;

            //Act
            var actualIndex = searcher.FindIndex(inputArray, itemToSearch);

            //Assert
            Assert.AreEqual(-1, actualIndex);
        }
    }
}
