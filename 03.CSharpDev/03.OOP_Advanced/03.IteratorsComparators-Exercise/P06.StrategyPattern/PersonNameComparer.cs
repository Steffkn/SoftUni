namespace P06.StrategyPattern
{
    using System.Collections.Generic;

    public class PersonNameComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.Name.Length < y.Name.Length)
            {
                return -1;
            }
            else if (x.Name.Length > y.Name.Length)
            {
                return 1;
            }
            else
            {
                char firstLetterX = x.Name.ToLower()[0];
                char firstLetterY = y.Name.ToLower()[0];

                return firstLetterX.CompareTo(firstLetterY);
            }
        }
    }
}
