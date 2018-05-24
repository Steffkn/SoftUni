namespace DungeonsAndCodeWizards.Models.Bags
{
    using DungeonsAndCodeWizards.Models.Items;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public abstract class Bag
    {
        private List<Item> items;

        protected Bag(int capacity = 100)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; }

        public ReadOnlyCollection<Item> Items => new ReadOnlyCollection<Item>(items);

        public int Load => this.items.Sum(i => i.Weight);

        public virtual void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(OutputMessages.FullBag);
            }

            this.items.Add(item);
        }

        public virtual Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(OutputMessages.EmptyBag);
            }

            var item = this.Items.FirstOrDefault(i => i.Name.Equals(name));

            if (item == null)
            {
                throw new ArgumentException(string.Format(OutputMessages.NoItemWithThatName, name));
            }

            return item;
        }
    }
}
