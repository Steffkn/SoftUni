public class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion)
        : base(name, weight, livingRegion)
    {
        this.GiveFoodNow = "Squeak";
    }

    public override bool CanEat(Food food)
    {
        return food is Vegetable || food is Fruit;
    }

    public override void Eat(int newFoodQuantity)
    {
        base.Eat(newFoodQuantity);
        this.Weight += newFoodQuantity * 0.1;
    }
}