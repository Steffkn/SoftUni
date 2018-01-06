using System.Linq;
using System.Net;
using System.Web.Mvc;
using IMDB.Models;
using System.Collections.Generic;

namespace IMDB.Controllers
{
    [ValidateInput(false)]
    public class FilmController : Controller
    {
        IMDBDbContext db = new IMDBDbContext();

        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            return View(db.Films.ToList());
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            if (ModelState.IsValid)
            {

                db.Films.Add(film);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(film);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            //TODO: Implement me ...
            var movie = db.Films.Find(id);

            if (movie == null)
            {
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Film filmModel)
        {
            //TODO: Implement me ... 

            var movie = db.Films.Find(filmModel.Id);

            if (movie == null)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                movie.Name = filmModel.Name;
                movie.Genre = filmModel.Genre;
                movie.Director = filmModel.Director;
                movie.Year = filmModel.Year;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(filmModel);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {
            var movie = db.Films.Find(id);

            if (movie == null)
            {
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id, Film filmModel)
        {
            //TODO: Implement me ...
            var movie = db.Films.Find(id);

            if (movie != null)
            {
                db.Films.Remove(movie);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}