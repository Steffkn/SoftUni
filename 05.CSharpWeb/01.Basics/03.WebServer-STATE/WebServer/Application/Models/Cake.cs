namespace HttpWebServer.Application.Models
{
    using HttpWebServer.Server;

    public class Cake : Model
    {
        public Cake(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
            this.Add("cakeName", name);
            this.Add("cakePrice", price);
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{this.Name},{this.Price}";
        }
    }
}
