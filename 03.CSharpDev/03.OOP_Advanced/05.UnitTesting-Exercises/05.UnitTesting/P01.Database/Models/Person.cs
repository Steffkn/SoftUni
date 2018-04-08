namespace P01.Database.Models
{
    using System;

    public class Person
    {
        private long id;
        private string name;

        public Person(long id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public long Id
        {
            get => this.id;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.id = value;
            }
        }

        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }
    }
}
