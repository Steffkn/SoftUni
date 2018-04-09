namespace P04.BubbleSortTest
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using NUnit.Framework;
    using P04.BubbleSort;

    [TestFixture]
    public class BubbleTest
    {
        public static IEnumerable TestListsOfInts
        {
            get
            {
                yield return new TestCaseData(
                    new List<IComparable>() { },
                     new List<IComparable>() { }
                     );
                yield return new TestCaseData(
                    new List<int>() { 1, 2, 3, 4, 5, 8, 7, 6 },
                     new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 }
                     );
                yield return new TestCaseData(
                    new List<int>() { 9, 8, 7, 6, 5, 4, 3, 2, 1 },
                     new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
                     );
                yield return new TestCaseData(
                    new List<char>() { '9', '8', '7', '6', '5', '4', '3', '2', '1' },
                     new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' }
                     );
                yield return new TestCaseData(
                    new List<char>() { 'z', 'y', 'x', 'w', 'v', 'u', 't', 's', 'r', 'q', 'p', 'o', 'n', 'm', 'l', 'k', 'j', 'i', 'h', 'g', 'f', 'e', 'd', 'c', 'b', 'a' },
                     new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' }
                     );
                yield return new TestCaseData(
                    new List<string>() { "9", "18", "7", "16", "5", "14", "3", "12", "1" },
                     new List<string>() { "1", "12", "14", "16", "18", "3", "5", "7", "9" }
                     );
                yield return new TestCaseData(
                    new List<string>() { "z", "y", "x", "w", "v", "u", "t", "s", "r", "q", "p", "o", "n", "m", "l", "k", "j", "i", "h", "g", "f", "e", "d", "c", "b", "a" },
                     new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" }
                     );
            }
        }

        [Test]
        [TestCaseSource(nameof(TestListsOfInts))]
        public void BubbleSort_SortingCorrectly<T>(List<T> items, List<T> expected)
            where T : IComparable
        {
            Bubble<T>.Sort(items.ToArray());
            Assert.That(items, Is.EquivalentTo(expected));
        }
    }
}
