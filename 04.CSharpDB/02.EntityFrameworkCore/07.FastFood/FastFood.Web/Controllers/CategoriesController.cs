namespace FastFood.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System;

    using Data;
    using ViewModels.Categories;
    using FastFood.Models;
    using AutoMapper.QueryableExtensions;
    using System.Linq;

    public class CategoriesController : BaseController
    {
        public CategoriesController(FastFoodContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToErrorPage();
            }

            var category = this.mapper.Map<Category>(model);
            this.SaveNew(category);

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var categories = this.GetAll<Category>()
                .ProjectTo<CategoryAllViewModel>(mapper.ConfigurationProvider)
                .OrderBy(x => x.Name)
                .ToList();

            return this.View(categories);
        }
    }
}
