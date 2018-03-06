public class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed)
    {
        this.GiveFoodNow = "Meow";
    }

    public override bool CanEat(Food food)
    {
        return food is Vegetable || food is Meat;
    }

    public override void Eat(int newFoodQuantity)
    {
        base.Eat(newFoodQuantity);
        this.Weight += newFoodQuantity * 0.3;
    }
}