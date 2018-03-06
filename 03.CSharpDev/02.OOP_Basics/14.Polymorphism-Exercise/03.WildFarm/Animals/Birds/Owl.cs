public class Owl : Bird
{
    public Owl(string name, double weight, double wingSize)
        : base(name, weight, wingSize)
    {
        this.GiveFoodNow = "Hoot Hoot";
    }

    public override bool CanEat(Food food)
    {
        return food is Meat;
    }

    public override void Eat(int newFoodQuantity)
    {
        base.Eat(newFoodQuantity);
        this.Weight += newFoodQuantity * 0.25;
    }
}