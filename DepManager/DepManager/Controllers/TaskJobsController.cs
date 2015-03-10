using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DepManager.Models;

namespace DepManager.Controllers
{
    public class TaskJobsController : Controller
    {
        private DepManagerContext db = new DepManagerContext();

        // GET: TaskJobs
        public ActionResult Index()
        {
            var taskJobs = db.TaskJobs.Include(t => t.ProjectManager);
            return View(taskJobs.ToList());
        }

        // GET: TaskJobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskJob taskJob = db.TaskJobs.Find(id);
            if (taskJob == null)
            {
                return HttpNotFound();
            }
            return View(taskJob);
        }

        // GET: TaskJobs/Create
        public ActionResult Create()
        {
            ViewBag.ManagerID = new SelectList(db.Managers, "ManagerID", "FullName");
            return View();
        }

        // POST: TaskJobs/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaskID,TaskName,ManagerID")] TaskJob taskJob)
        {
            if (ModelState.IsValid)
            {
                db.TaskJobs.Add(taskJob);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManagerID = new SelectList(db.Managers, "ManagerID", "FullName", taskJob.ManagerID);
            return View(taskJob);
        }

        // GET: TaskJobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskJob taskJob = db.TaskJobs.Find(id);
            if (taskJob == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManagerID = new SelectList(db.Managers, "ManagerID", "FullName", taskJob.ManagerID);
            return View(taskJob);
        }

        // POST: TaskJobs/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaskID,TaskName,ManagerID")] TaskJob taskJob)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskJob).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManagerID = new SelectList(db.Managers, "ManagerID", "FullName", taskJob.ManagerID);
            return View(taskJob);
        }

        // GET: TaskJobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskJob taskJob = db.TaskJobs.Find(id);
            if (taskJob == null)
            {
                return HttpNotFound();
            }
            return View(taskJob);
        }

        // POST: TaskJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskJob taskJob = db.TaskJobs.Find(id);
            db.TaskJobs.Remove(taskJob);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
