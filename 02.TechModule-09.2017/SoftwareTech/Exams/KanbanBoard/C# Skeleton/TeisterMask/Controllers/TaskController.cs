using System.Linq;
using System.Web.Mvc;
using TeisterMask.Models;

namespace TeisterMask.Controllers
{
        [ValidateInput(false)]
	public class TaskController : Controller
    {
        TeisterMaskDbContext db = new TeisterMaskDbContext();

        [HttpGet]
            [Route("")]
	    public ActionResult Index()
	    {
            return View(db.Tasks.ToList());
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
		public ActionResult Create(Task task)
        {
            if (!ModelState.IsValid)
            {
                return View(task);
            }

            db.Tasks.Add(task);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

		[HttpGet]
		[Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            var task = db.Tasks.Find(id);

            if (task == null)
            {
                return RedirectToAction("Index");
            }

            return View(task);
        }

		[HttpPost]
		[Route("edit/{id}")]
        [ValidateAntiForgeryToken]
		public ActionResult EditConfirm(int id, Task taskModel)
        {
            var task = db.Tasks.Find(id);

            if (task == null)
            {
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                return View(task);
            }

            task.Status = taskModel.Status;
            task.Title = taskModel.Title;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
	}
}