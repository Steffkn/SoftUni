namespace FastFood.Web.ViewModels.Orders
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    public class CreateOrderViewModel
    {
        public List<SelectListItem> Items { get; set; }

        public List<SelectListItem> Employees { get; set; }
    }
}
