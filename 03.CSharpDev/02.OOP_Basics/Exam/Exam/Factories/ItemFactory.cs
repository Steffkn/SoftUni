namespace DungeonsAndCodeWizards.Factories
{
    using DungeonsAndCodeWizards.Models.Items;
    using System;

    public class ItemFactory
    {
        public Item CreateItem(string itemName)
        {
            switch (itemName)
            {
                case "HealthPotion":
                    return new HealthPotion();
                case "PoisonPotion":
                    return new PoisonPotion();
                case "ArmorRepairKit":
                    return new ArmorRepairKit();
                default:
                    throw new ArgumentException(string.Format("Invalid item \"{0}\"!", itemName));
            }
        }
    }
}
