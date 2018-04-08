namespace P01.Database.Tests
{
    using System;
    using NUnit.Framework;
    using Models;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase()]
        [TestCase(1, 2, 3, 4)]
        public void ConstructorShouldInitCorrect(params int[] numbers)
        {
            var database = new Database<int>(numbers);
            Assert.Pass();
        }

        [TestCase()]
        [TestCase(1, 2, 3, 4)]
        public void DatabaseShouldHaveCpacity16(params int[] numbers)
        {
            var database = new Database<int>(numbers);
            var data = database.Fetch();
            Assert.That(data.Length, Is.EqualTo(numbers.Length));
        }

        [Test]
        public void ConstructorWithMoreThan16ElementsShouldThrowInvalidOperationException()
        {
            var bigArray = new int[17];
            Assert.Throws<InvalidOperationException>(() => new Database<int>(bigArray));
        }

        [TestCase()]
        [TestCase(1, 2, 3, 4)]
        public void AddShouldAddValuesCorrectly(params int[] numbers)
        {
            var database = new Database<int>();
            var result = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                database.Add(numbers[i]);
                result[i] = numbers[i];
            }

            var data = database.Fetch();
            Assert.That(data, Is.EqualTo(result));
        }

        [Test]
        public void AddWhenAddingMoreThan16ShoultThrowException()
        {
            var database = new Database<int>();
            var bigArray = new int[16];

            foreach (int number in bigArray)
            {
                database.Add(number);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(1));
        }

        [TestCase(1, 2, 3, 4)]
        public void RemoveShouldRemoveLast(params int[] numbers)
        {
            var database = new Database<int>();
            var result = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                database.Add(numbers[i]);
                result[i] = numbers[i];
            }

            var data = database.Fetch();
            Assert.That(data, Is.EqualTo(result));
            database.Remove();
            data = database.Fetch();
            Assert.That(data, Is.Not.EqualTo(result));
        }

        [Test]
        public void RemoveFromEmptyCollectionShouldThrowInvalidOperationException()
        {
            var database = new Database<int>();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [TestCase()]
        [TestCase(1, 2, 3, 4)]
        public void FetchShouldReturnCorrectValues(params int[] numbers)
        {
            var database = new Database<int>(numbers);
            var data = database.Fetch();
            Assert.That(data, Is.EqualTo(numbers));
        }
    }
}
