using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace FastFood.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly FastFoodContext context;
        protected readonly IMapper mapper;

        public BaseController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        
        protected IActionResult RedirectToErrorPage()
        {
            return RedirectToAction("Error", "Home");
        }

        protected DbSet<TEntity> GetAll<TEntity>()
            where TEntity : class
        {
            return this.context.Set<TEntity>();
        }

        protected int SaveNew<TEntity>(TEntity entity)
            where TEntity : class
        {
            this.AddToDbSet(entity);
            return this.Save();
        }

        protected int Save()
        {
            return this.context.SaveChanges();
        }

        protected EntityEntry<TEntity> AddToDbSet<TEntity>(TEntity entity)
            where TEntity : class
        {
            return this.context.Set<TEntity>().Add(entity);
        }

        protected IActionResult All<TEntity, TResult>()
            where TEntity : class
        {
            var positions = this.GetAll<TEntity>()
                .ProjectTo<TResult>(mapper.ConfigurationProvider)
                .ToList();

            return this.View(positions);
        }
    }
}
