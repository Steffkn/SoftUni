namespace P06.StrategyPattern
{
    using System.Collections.Generic;

    public class PersonAgeComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
}
