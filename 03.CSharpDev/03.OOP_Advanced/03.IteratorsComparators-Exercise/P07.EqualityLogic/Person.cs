namespace P07.EqualityLogic
{
    using System;

    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; }

        public int Age { get; }

        public int CompareTo(Person other)
        {
            int comparison = this.Name.CompareTo(other.Name);

            if (comparison == 0)
            {
                comparison = this.Age.CompareTo(other.Age);
            }

            return comparison;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }

        public override bool Equals(object obj)
        {
            Person secondPerson = obj as Person;

            int result = this.Name.CompareTo(secondPerson.Name);
            if (result != 0)
            {
                return false;
            }

            result = this.Age.CompareTo(secondPerson.Age);

            if (result != 0)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Age.GetHashCode();
        }
    }
}
