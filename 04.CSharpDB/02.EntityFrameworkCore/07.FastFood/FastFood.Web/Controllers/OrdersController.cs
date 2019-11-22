namespace FastFood.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;

    using Data;
    using ViewModels.Orders;
    using FastFood.Models;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class OrdersController : BaseController
    {
        public OrdersController(FastFoodContext context, IMapper mapper)
            : base(context, mapper)
        { }

        public IActionResult Create()
        {
            var createOrderViewModel = new CreateOrderViewModel
            {
                Items = this.GetAll<Item>()
                        .Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name })
                        .ToList(),
                Employees = this.GetAll<Employee>()
                        .Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name })
                        .ToList(),
            };

            return this.View(createOrderViewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToErrorPage();
            }

            var newOrder = this.mapper.Map<Order>(model);
            this.SaveNew(newOrder);
            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var items = this.GetAll<Order>()
                .ProjectTo<OrderAllViewModel>(mapper.ConfigurationProvider)
                .OrderByDescending(x=>x.DateTime)
                .ToList();

            return this.View(items);
        }
    }
}
