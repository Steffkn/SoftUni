public class Tiger : Feline
{
    public Tiger(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed)
    {
        this.GiveFoodNow = "ROAR!!!";
    }

    public override bool CanEat(Food food)
    {
        return food is Meat;
    }
    public override void Eat(int newFoodQuantity)
    {
        base.Eat(newFoodQuantity);
        this.Weight += newFoodQuantity * 1;
    }
}