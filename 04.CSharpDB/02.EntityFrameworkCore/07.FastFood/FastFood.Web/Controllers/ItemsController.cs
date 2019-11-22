namespace FastFood.Web.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;

    using Data;
    using ViewModels.Items;
    using FastFood.Models;

    public class ItemsController : BaseController
    {
        public ItemsController(FastFoodContext context, IMapper mapper)
            : base(context, mapper)
        { }

        public IActionResult Create()
        {
            var categories = this.context.Categories
                .ProjectTo<CreateItemViewModel>(mapper.ConfigurationProvider)
                .ToList();

            return this.View(categories);
        }

        [HttpPost]
        public IActionResult Create(CreateItemInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToErrorPage();
            }

            var newItem = this.mapper.Map<Item>(model);
            this.SaveNew(newItem);

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var items = this.GetAll<Item>()
                .ProjectTo<ItemsAllViewModels>(mapper.ConfigurationProvider)
                .OrderBy(x => x.Name)
                .ToList();

            return this.View(items);
        }
    }
}
