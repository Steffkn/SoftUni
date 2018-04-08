namespace P01.Database.Models
{
    using System;

    public class PersonDatabase : Database<Person>
    {

        public PersonDatabase(params Person[] initialIntegers)
            : base(initialIntegers)
        {
        }

        public override void Add(Person newPerson)
        {
            foreach (var person in Data)
            {
                if (person.Id == newPerson.Id || person.Name == newPerson.Name)
                {
                    throw new InvalidOperationException("Person with that name or id already exists!");
                }
            }

            base.Add(newPerson);
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Negative ids are not allowed!");
            }

            foreach (var person in Data)
            {
                if (person.Id == id)
                {
                    return person;
                }
            }

            throw new InvalidOperationException("No user is present by this id!");
        }

        public Person FindByName(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException(nameof(username), "Empty names are not allowed!");
            }

            foreach (var person in Data)
            {
                if (person.Name == username)
                {
                    return person;
                }
            }

            throw new InvalidOperationException("No user is present by this username!");
        }
    }
}
