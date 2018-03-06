public class Food
{
    private int quantity;

    public Food(int quantity)
    {
        this.Quantity = quantity;
    }

    public int Quantity { get => quantity; set => quantity = value; }
}