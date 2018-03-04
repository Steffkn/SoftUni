public abstract class Food
{
    public int HappinessPoints { get; set; }

    public Food()
    {
        this.HappinessPoints = -1;
    }

    public Food(int happinessPoints)
    {
        this.HappinessPoints = happinessPoints;
    }
}
