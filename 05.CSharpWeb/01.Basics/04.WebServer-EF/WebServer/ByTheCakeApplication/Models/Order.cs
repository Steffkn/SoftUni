namespace HTTPServer.ByTheCakeApplication.Models
{
    using System.Collections.Generic;

    public class Order
    {
        public Order()
        {
            this.Products = new List<ProductOrder>();
        }

        public int Id { get; set; }

        public ICollection<ProductOrder> Products { get; set; }
    }
}
