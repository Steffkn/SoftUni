using System.Collections;
using System.Collections.Generic;
using System.Linq;
using P03.Iterator;

namespace P03.IteratorTest
{
    using System;
    using NUnit.Framework;
    using P03.Iterator.Models;

    [TestFixture()]
    public class ListIteratorTests
    {
        [TestCase()]
        [TestCase("1", "2")]
        public void ConstructorShouldInitCorrect(params string[] values)
        {
            var listIterator = new ListIterator(values);
            Assert.Pass();
        }

        [TestCase(null, null)]
        public void ConstructorShouldThrowAtNullValue(params string[] values)
        {
            Assert.Throws<ArgumentNullException>(() => new ListIterator(values));
        }

        [TestCase()]
        public void HasNextOfNoElementShouldReturnFalse(params string[] values)
        {
            var listIterator = new ListIterator(values);
            Assert.That(listIterator.HasNext(), Is.EqualTo(false));
        }

        [TestCase("1", "2")]
        public void HasNextOfTwoElementShouldReturnTrue(params string[] values)
        {
            var listIterator = new ListIterator(values);
            Assert.That(listIterator.HasNext(), Is.EqualTo(true));
        }

        [TestCase()]
        public void MoveOfNoElementShouldReturnFalse(params string[] values)
        {
            var listIterator = new ListIterator(values);
            Assert.That(listIterator.Move(), Is.EqualTo(false));
        }

        [TestCase("1", "2")]
        public void MoveOfTwoElementShouldReturnTrue(params string[] values)
        {
            var listIterator = new ListIterator(values);
            Assert.That(listIterator.Move(), Is.EqualTo(true));
        }

        [TestCase()]
        public void PrintOfNoElementShouldReturnFalse(params string[] values)
        {
            var listIterator = new ListIterator(values);
            Assert.Throws<InvalidOperationException>(() => listIterator.Print());
        }

        [TestCase("1", "2")]
        public void PrintOfTwoElementShouldReturnTrue(params string[] values)
        {
            var listIterator = new ListIterator(values);
            Assert.That(listIterator.Print(), Is.EqualTo("1"));
            Assert.That(listIterator.Move(), Is.EqualTo(true));
            Assert.That(listIterator.Print(), Is.EqualTo("2"));
        }

        public static IEnumerable TestCasesValueString
        {
            get
            {
                yield return new TestCaseData(
                    new List<string> {
                        "Create",
                        "Print",
                        "END"},
                    new List<string> {
                        "Invalid Operation!"}
                );

                yield return new TestCaseData(
                    new List<string> {
                        "Create Stefcho Goshky",
                        "HasNext",
                        "Print",
                        "Move",
                        "Print",
                        "END"},
                    new List<string>  {
                        "True",
                        "Stefcho",
                        "True",
                        "Goshky",}
                );

                yield return new TestCaseData(
                    new List<string> {
                        "Create 1 2 3",
                        "HasNext",
                        "Move",
                        "HasNext",
                        "HasNext",
                        "Move",
                        "HasNext",
                        "END"},
                    new List<string>  {
                        "True",
                        "True",
                        "True",
                        "True",
                        "True",
                        "False",}
                );
            }
        }

        [Test]
        [TestCaseSource(nameof(TestCasesValueString))]
        public void IntegrationTests(List<string> commandsList, List<string> expectedResultList)
        {
            var resultList = new List<string>
            {
            };

            string[] listArgs = commandsList[0].Split(' ').Skip(1).ToArray();
            var listIterator = new ListIterator(listArgs);
            var engine = new Engine(listIterator);

            for (int i = 1; i < commandsList.Count - 1; i++)
            {
                resultList.Add(engine.InterpretCommand(commandsList[i]));
            }

            Assert.That(expectedResultList, Is.EquivalentTo(resultList));
        }
    }
}
