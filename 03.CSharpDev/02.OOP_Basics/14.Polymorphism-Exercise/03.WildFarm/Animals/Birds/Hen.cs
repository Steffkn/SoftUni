public class Hen : Bird
{
    public Hen(string name, double weight, double wingSize)
        : base(name, weight, wingSize)
    {
        this.GiveFoodNow = "Cluck";
    }

    public override void Eat(int newFoodQuantity)
    {
        base.Eat(newFoodQuantity);
        this.Weight += newFoodQuantity * 0.35;
    }
}