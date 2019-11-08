namespace P03_SalesDatabase.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Sale
    {
        public int SaleId { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}
