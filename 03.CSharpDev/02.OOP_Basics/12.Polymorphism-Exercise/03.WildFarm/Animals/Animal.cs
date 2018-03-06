public abstract class Animal : ISoundProducable
{
    private string name;
    private double weight;
    private int foodEaten;

    protected Animal(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public int FoodEaten
    {
        get { return foodEaten; }
        set { foodEaten = value; }
    }

    public string GiveFoodNow { get; set; }

    public virtual bool CanEat(Food food)
    {
        return true;
    }

    public virtual void Eat(int newFoodQuantity)
    {
        this.FoodEaten += newFoodQuantity;
    }
}