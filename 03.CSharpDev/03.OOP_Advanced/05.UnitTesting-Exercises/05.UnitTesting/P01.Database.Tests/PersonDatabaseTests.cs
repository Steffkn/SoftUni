using System;
using System.Collections.Generic;
using System.Linq;
using P01.Database.Models;

namespace P01.Database.Tests
{
    using NUnit.Framework;

    [TestFixture()]
    public class PersonDatabaseTests
    {
        public static IEnumerable<Person[]> peopleArray
        {
            get
            {
                yield return new[] { new Person(0, "Gosho"), new Person(1, "Tosho"), new Person(2, "Sasho") };
            }
        }

        public static IEnumerable<Person[]> duplicatePeople
        {
            get
            {
                yield return new[] { new Person(1, "Gosho"), new Person(1, "Gosho") };
            }
        }

        public static IEnumerable<Person[]> invalidPeople
        {
            get
            {
                yield return new[] { new Person(-1, null), new Person(0, null) };
            }
        }

        public static IEnumerable<Person[]> TestSubjectsPeople
        {
            get
            {
                yield return new Person[0];
                yield return new[] { new Person(0, "Gosho"), new Person(1, "Tosho"), new Person(2, "Sasho") };
                yield return new[] { new Person(0, "") };
            }
        }

        [Test]
        public void ConstructorShouldInitCorrect()
        {
            var database = new Database<Person>();
            Assert.Pass();
        }

        [TestCaseSource(nameof(TestSubjectsPeople))]
        public void DatabaseShouldHaveCpacity16(params Person[] people)
        {
            var database = new PersonDatabase(people);
            var data = database.Data;
            Assert.That(data.Count, Is.EqualTo(people.Length));
        }

        [TestCaseSource(nameof(peopleArray))]
        public void AddToPeopleDBShouldAddCorrectly(params Person[] people)
        {
            var database = new PersonDatabase();
            foreach (var person in people)
            {
                database.Add(person);
            }
            var data = database.Data.Take(people.Length);
            Assert.That(data.Count, Is.EqualTo(people.Length));
            Assert.That(data, Is.EquivalentTo(people));
        }

        [TestCaseSource(nameof(peopleArray))]
        public void AddDuplicatePeopleShouldThrow(params Person[] people)
        {
            var database = new PersonDatabase();
            foreach (var person in people)
            {
                database.Add(person);
            }

            foreach (var person in people)
            {
                Assert.Throws<InvalidOperationException>(() => database.Add(person));
            }
        }

        [Test]
        public void AddWhenAddingMoreThan16ShoultThrowException()
        {
            var database = new PersonDatabase();

            for (int i = 0; i < 16; i++)
            {
                database.Add(new Person(i, "Name" + i));

            }

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1123, "qwerty")));
        }

        [Test]
        public void Add_NegativeValues_ThrowsArgumentOutOfRangeException()
        {
            var database = new PersonDatabase();
            Assert.Throws<ArgumentOutOfRangeException>(() => database.Add(new Person(-1, "qwerty")));
        }

        [Test]
        public void FindById_NegativeValues_ThrowsArgumentOutOfRangeException()
        {
            var database = new PersonDatabase();
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));
        }

        [Test]
        public void FindById_UnexistingID_ThrowsInvalidOperationException()
        {
            var database = new PersonDatabase();
            Assert.Throws<InvalidOperationException>(() => database.FindById(666));
        }

        [TestCaseSource(nameof(peopleArray))]
        public void FindById_WithExistingPeople_WorksCorrectly(params Person[] people)
        {
            var database = new PersonDatabase();

            foreach (var person in people)
            {
                database.Add(person);
            }

            foreach (var person in people)
            {
                var lastPerson = database.FindById(person.Id);
                Assert.That(lastPerson.Id, Is.EqualTo(person.Id));
                Assert.That(lastPerson.Name, Is.EqualTo(person.Name));
            }
        }

        [Test]
        public void FindByName_NullValue_ThrowsArgumentNullException()
        {
            var database = new PersonDatabase();
            Assert.Throws<ArgumentNullException>(() => database.FindByName(null));
        }

        [Test]
        public void FindByName_UnexistingName_ThrowsInvalidOperationException()
        {
            var database = new PersonDatabase();
            Assert.Throws<InvalidOperationException>(() => database.FindByName("Unnamed"));
        }

        [TestCaseSource(nameof(peopleArray))]
        public void FindByName_WithExistingPeople_WorksCorrectly(params Person[] people)
        {
            var database = new PersonDatabase();

            foreach (var person in people)
            {
                database.Add(person);
            }

            foreach (var person in people)
            {
                var lastPerson = database.FindByName(person.Name);
                Assert.That(lastPerson.Id, Is.EqualTo(person.Id));
                Assert.That(lastPerson.Name, Is.EqualTo(person.Name));
            }
        }
    }
}
