namespace FastFood.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System;

    using Data;
    using ViewModels.Employees;
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using System.Collections.Generic;
    using FastFood.Models;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class EmployeesController : BaseController
    {
        public EmployeesController(FastFoodContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public IActionResult Register()
        {
            var positions = this.GetAll<Position>()
                .ProjectTo<SelectListItem>(mapper.ConfigurationProvider)
                .ToList();
            TempData.Add("Positions", positions);

            var model = new RegisterEmployeeInputModel();
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Register(RegisterEmployeeInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToErrorPage();
            }

            var employee = this.mapper.Map<Employee>(model);
            this.SaveNew(employee);

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var employees = this.GetAll<Employee>()
                .ProjectTo<EmployeesAllViewModel>(mapper.ConfigurationProvider)
                .OrderBy(x => x.Name)
                .ToList();

            return this.View(employees);
        }
    }
}
