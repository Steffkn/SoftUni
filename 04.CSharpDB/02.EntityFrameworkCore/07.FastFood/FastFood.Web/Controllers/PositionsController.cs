namespace FastFood.Web.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    using Data;
    using Models;
    using ViewModels.Positions;

    public class PositionsController : BaseController
    {
        public PositionsController(FastFoodContext context, IMapper mapper)
            : base(context, mapper)
        { }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreatePositionInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToErrorPage();
            }

            var position = this.mapper.Map<Position>(model);
            this.SaveNew(position);
           
            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var positions = this.GetAll<Position>()
                .ProjectTo<PositionsAllViewModel>(mapper.ConfigurationProvider)
                .OrderBy(x=>x.Name)
                .ToList();

            return this.View(positions);
        }
    }
}
