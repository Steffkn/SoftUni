using System;
namespace P05.ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; }

        public int Age { get; }

        public string Town { get; }

        public int CompareTo(Person other)
        {
            int comparison = this.Name.CompareTo(other.Name);

            if (comparison == 0)
            {
                comparison = this.Age.CompareTo(other.Age);

                if (comparison == 0)
                {
                    comparison = this.Town.CompareTo(other.Town);
                }
            }

            return comparison;
        }
    }
}
