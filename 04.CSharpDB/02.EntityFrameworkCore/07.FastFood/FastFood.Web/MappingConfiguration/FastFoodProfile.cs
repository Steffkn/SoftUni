namespace FastFood.Web.MappingConfiguration
{
    using AutoMapper;
    using Models;

    using ViewModels.Positions;
    using ViewModels.Employees;
    using FastFood.Web.ViewModels.Categories;
    using FastFood.Web.ViewModels.Items;
    using FastFood.Web.ViewModels.Orders;
    using System;
    using System.Globalization;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class FastFoodProfile : Profile
    {
        private const string OrderDateTimeFormat = "dd MMM yyyy hh:mm:ss";

        public FastFoodProfile()
        {
            // Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            // Employees
            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(x => x.Position, y => y.MapFrom(s => s.Position.Name));
            this.CreateMap<Position, SelectListItem>()
                .ForMember(x => x.Value, y => y.MapFrom(s => s.Id))
                .ForMember(x => x.Text, y => y.MapFrom(s => s.Name));

            this.CreateMap<RegisterEmployeeInputModel, Employee>()
                .ForMember(x => x.PositionId, y => y.MapFrom(s => s.PositionId));

            // Categories
            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.CategoryName));
            this.CreateMap<Category, CategoryAllViewModel>();

            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(x => x.CategoryId, y => y.MapFrom(s => s.Id))
                .ForMember(x => x.CategoryName, y => y.MapFrom(s => s.Name));

            this.CreateMap<CreateItemInputModel, Item>()
                .ForMember(x => x.CategoryId, y => y.MapFrom(s => s.CategoryId));

            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(x => x.Category, y => y.MapFrom(s => s.Category.Name));

            // Orders
            this.CreateMap<CreateOrderInputModel, Order>()
                .ForMember(x => x.DateTime, opt => opt.MapFrom(src => DateTime.UtcNow));

            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(x => x.OrderId, y => y.MapFrom(s => s.Id))
                .ForMember(x => x.Employee, y => y.MapFrom(s => s.Employee.Name))
                .ForMember(x => x.DateTime, y => y.MapFrom(s => s.DateTime.ToString(OrderDateTimeFormat, CultureInfo.InvariantCulture)));

        }
    }
}
