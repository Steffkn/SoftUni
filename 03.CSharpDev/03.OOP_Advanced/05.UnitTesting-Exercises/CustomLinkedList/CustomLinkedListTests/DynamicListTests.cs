namespace CustomLinkedListTests
{
    using NUnit.Framework;
    using CustomLinkedList;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    [TestFixture]
    public class DynamicListTests
    {
        private const string InvalidCountMessage = "The count of elements does not match!";
        private const string InvalidListElement = "The list contains more values than it should!";

        public static IEnumerable TestValues
        {
            get
            {
                yield return new TestCaseData(
                    new List<int>() { 10, 20, 30 }, 0, 10);
                yield return new TestCaseData(
                    new List<int>() { 10, 20, 30 }, 1, 20);
                yield return new TestCaseData(
                    new List<int>() { 10, 20, 30 }, 2, 30);
            }
        }
        [Test]
        public void Constructor_InitilTest()
        {
            var list = new DynamicList<int>();
            Assert.That(list.Count, Is.EqualTo(0), InvalidCountMessage);
        }

        [TestCase(-1)]
        [TestCase(1000)]
        public void IndexatorSet_WithInvalidIndex_ShouldThrow(int index)
        {
            var list = new DynamicList<int>();
            Assert.Throws<ArgumentOutOfRangeException>(() => list[index] = 0, $"Invalid index: {index}");
        }

        [TestCase(-1)]
        [TestCase(1000)]
        public void IndexatorGet_WithInvalidIndex_ShouldThrow(int index)
        {
            var list = new DynamicList<int>();
            int getter = 0;
            Assert.Throws<ArgumentOutOfRangeException>(() => getter = list[index], $"Invalid index: {index}");
        }

        [TestCaseSource(nameof(TestValues))]
        public void IndexatorSet_WithValidIndex_ShouldReturnCorrectValue(List<int> values, int index, int expected)
        {
            var list = new DynamicList<int>();

            for (int i = 0; i < values.Count; i++)
            {
                list.Add(0);
                list[i] = values[i];
                Assert.That(list[i], Is.EqualTo(values[i]), InvalidListElement);
            }

            Assert.That(list[index], Is.EqualTo(expected), InvalidListElement);
        }

        [TestCaseSource(nameof(TestValues))]
        public void IndexatorGet_WithValidIndex_ShouldReturnCorrectValue(List<int> values, int index, int expected)
        {
            var list = new DynamicList<int>();

            foreach (var value in values)
            {
                list.Add(value);
            }

            Assert.That(list[index], Is.EqualTo(expected), InvalidListElement);
        }

        [TestCaseSource(nameof(TestValues))]
        public void Add_ShouldAddCorrectly(List<int> values, int index, int expected)
        {
            var list = new DynamicList<int>();
            int count = 0;

            foreach (var value in values)
            {
                list.Add(value);
                count += 1;
                Assert.That(list.Count, Is.EqualTo(count));
            }

            for (int i = 0; i < values.Count; i++)
            {
                Assert.That(list[i], Is.EqualTo(values[i]), InvalidListElement);
            }
        }

        [TestCase(-1)]
        [TestCase(1000)]
        public void RemoveAt_WithInvalidIndexes_ShouldThrow(int index)
        {
            var list = new DynamicList<int>();
            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(index), $"Invalid index: {index}");
        }

        [TestCaseSource(nameof(TestValues))]
        public void RemoveAt_WithValidIndexes_ShouldRemoveAndReturnCorrectly(List<int> values, int index, int expected)
        {
            var list = new DynamicList<int>();
            int count = 0;
            foreach (var value in values)
            {
                list.Add(value);
                count += 1;
            }

            for (int i = values.Count - 1; i >= 0; i--)
            {
                var listItem = list[i];
                var returnedItem = list.RemoveAt(i);
                count -= 1;
                Assert.That(listItem, Is.EqualTo(returnedItem), "RomoveAt doesnt remove the right value!");
                Assert.That(list.Count, Is.EqualTo(count), InvalidCountMessage);
            }

            Assert.Pass();
        }

        [Test]
        public void Remove_WithValidValue_ShouldRemoveAndReturnCorrectly()
        {
            var list = new DynamicList<int>();
            int count = 0;
            var values = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (var value in values)
            {
                list.Add(value);
                count += 1;
            }

            for (int i = 0; i < values.Count; i++)
            {
                count -= 1;
                Assert.That(list.Remove(values[i]), Is.EqualTo(0), InvalidListElement);
                Assert.That(list.Count, Is.EqualTo(count), InvalidCountMessage);
            }

            Assert.Pass();
        }

        [Test]
        public void Remove_WithInalidValue_ShouldReturnMinusOne()
        {
            var list = new DynamicList<int>();
            int count = 0;
            var values = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (var value in values)
            {
                list.Add(value);
                count += 1;
            }

            Assert.That(list.Remove(666), Is.EqualTo(-1), InvalidListElement);
            Assert.That(list.Count, Is.EqualTo(count), InvalidCountMessage);
        }


        [Test]
        public void IndexOf_WithValidValue_ShouldReturnCorrectIndex()
        {
            var list = new DynamicList<int>();
            var values = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int count = 0;
            foreach (var value in values)
            {
                list.Add(value);
                count += 1;
            }

            for (int i = 0; i < values.Count; i++)
            {
                Assert.That(list.IndexOf(values[i]), Is.EqualTo(i), $"The element at {i} does not match!");
            }

            Assert.That(list.Count, Is.EqualTo(count), InvalidCountMessage);
        }

        [Test]
        public void IndexOf_WithInalidValue_ShouldReturnMinusOne()
        {
            var list = new DynamicList<int>();
            int count = 0;
            var values = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (var value in values)
            {
                list.Add(value);
                count += 1;
            }

            Assert.That(list.Remove(666), Is.EqualTo(-1), InvalidListElement);
            Assert.That(list.Count, Is.EqualTo(count), InvalidCountMessage);
        }

        [Test]
        public void Contains_WithInvalidValue_ShouldReturnFalse()
        {
            var list = new DynamicList<int>();
            int count = 0;
            var values = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (var value in values)
            {
                list.Add(value);
                count += 1;
            }

            Assert.That(list.Contains(666), Is.EqualTo(false), InvalidListElement);
            Assert.That(list.Count, Is.EqualTo(count), InvalidCountMessage);
        }

        [Test]
        public void Contains_WithValidValue_ShouldReturnTrue()
        {
            var list = new DynamicList<int>();
            int count = 0;
            var values = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (var value in values)
            {
                list.Add(value);
                count += 1;
            }

            foreach (var value in values)
            {
                Assert.That(list.Contains(value), Is.EqualTo(true), $"The list does not contain {value}");
            }

            Assert.That(list.Count, Is.EqualTo(count), InvalidCountMessage);
        }
    }
}
