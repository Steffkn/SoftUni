public class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion)
        : base(name, weight, livingRegion)
    {
        this.GiveFoodNow = "Woof!";
    }

    public override bool CanEat(Food food)
    {
        return food is Meat;
    }

    public override void Eat(int newFoodQuantity)
    {
        base.Eat(newFoodQuantity);
        this.Weight += newFoodQuantity * 0.4;
    }
}