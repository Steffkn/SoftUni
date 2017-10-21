namespace _07.AndreyAndBilliard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AndreyAndBilliard
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var items = new Dictionary<string, decimal>();
            var customers = new List<Customer>();

            // populate items in the shop
            for (int i = 0; i < n; i++)
            {
                var inputs = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                var itemName = inputs[0];
                var itemPrice = decimal.Parse(inputs[1]);

                if (!items.ContainsKey(itemName))
                {
                    items.Add(itemName, 0);
                }

                items[itemName] = itemPrice;
            }

            var input = Console.ReadLine();
            while (input != "end of clients")
            {
                var inputs = input.Split(new char[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries);
                var clientName = inputs[0];
                var clientOrder = inputs[1];
                var clientQuantity = int.Parse(inputs[2]);

                if (items.ContainsKey(clientOrder))
                {
                    var customer = customers.FirstOrDefault(c => c.Name == clientName);
                    if (customer != null)
                    {
                        customer.AddOrder(clientOrder, clientQuantity);
                        customer.Bill += clientQuantity * items[clientOrder];
                    }
                    else
                    {
                        customer = new Customer(clientName);
                        customer.AddOrder(clientOrder, clientQuantity);
                        customer.Bill = clientQuantity * items[clientOrder];
                        customers.Add(customer);
                    }
                }

                input = Console.ReadLine();
            }

            decimal totalBill = 0;
            foreach (var customer in customers.OrderBy(c=>c.Name))
            {
                Console.WriteLine(customer.Name);

                customer.PrintOrders();
                Console.WriteLine($"Bill: {customer.Bill:F2}");
                totalBill += customer.Bill;
            }
            Console.WriteLine($"Total bill: {totalBill:F2}");
        }
    }

    internal class Customer
    {
        private string name;
        private Dictionary<string, int> orders = new Dictionary<string, int>();
        private decimal bill;

        public Customer(string name)
        {
            this.Name = name;
        }

        public void AddOrder(string name, int quantity)
        {
            if (this.orders.ContainsKey(name))
            {
                this.orders[name] += quantity;
            }
            else
            {
                this.orders.Add(name, quantity);
            }
        }

        public void PrintOrders()
        {
            foreach (var order in orders)
            {
                Console.WriteLine($"-- {order.Key} - {order.Value}");
            }
        }

        public decimal Bill { get => bill; set => bill = value; }
        public string Name { get => name; set => name = value; }
    }
}
