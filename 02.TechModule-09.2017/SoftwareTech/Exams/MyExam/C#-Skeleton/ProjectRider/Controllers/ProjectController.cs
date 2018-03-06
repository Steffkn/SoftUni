namespace ProjectRider.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Models;

    [ValidateInput(false)]
    public class ProjectController : Controller
    {
        ProjectRiderDbContext db = new ProjectRiderDbContext();

        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            var ps = db.Projects.ToList();
            return View(ps);
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
        public ActionResult Create(Project project)
        {
            //TODO: Implement me ...
            if (ModelState.IsValid)
            {

                db.Projects.Add(project);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(project);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            //TODO: Implement me ...
            var pj = db.Projects.Find(id);

            if (pj == null)
            {
                return RedirectToAction("Index");
            }

            return View(pj);
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int id, Project project)
        {
            //TODO: Implement me ...

            var pj = db.Projects.Find(id);

            if (pj == null)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                pj.Title = project.Title;
                pj.Description = project.Description;
                pj.Budget = project.Budget;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(project);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            //TODO: Implement me ...
            var pj = db.Projects.Find(id);

            if (pj == null)
            {
                return RedirectToAction("Index");
            }

            return View(pj);
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id, Project reportModel)
        {
            //TODO: Implement me 
            var pj = db.Projects.Find(id);

            if (pj != null)
            {
                db.Projects.Remove(pj);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}