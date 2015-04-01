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
    public class TBriefsController : Controller
    {
        private DepManagerContext db = new DepManagerContext();

        // GET: TBriefs
        public ActionResult Index(int? SelectedTaskJob)
        {

            var taskjobs = db.TaskJobs.OrderBy(q => q.TaskID).ToList();
            ViewBag.SelectedTaskJob = new SelectList(taskjobs, "TaskID", "TaskName", SelectedTaskJob);
            int TaskID = SelectedTaskJob.GetValueOrDefault();

            IQueryable<TBrief> TBriefs = db.TBriefs
                .Where(c => !SelectedTaskJob.HasValue || c.TaskID == TaskID)
                .OrderBy(d => d.BriefID)
                .Include(d => d.TaskJob);
            var sql = taskjobs.ToString();
            return View(TBriefs.ToList());
        }

        // GET: TBriefs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBrief tBrief = db.TBriefs.Find(id);
            if (tBrief == null)
            {
                return HttpNotFound();
            }
            return View(tBrief);
        }

        // GET: TBriefs/Create
        public ActionResult Create()
        {
            ViewBag.TaskID = new SelectList(db.TaskJobs, "TaskID", "TaskName");
            return View();
        }

        // POST: TBriefs/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BriefID,StartTime,EndTime,Plan,Action,Finished,TaskID")] TBrief tBrief)
        {
            if (ModelState.IsValid)
            {
                db.TBriefs.Add(tBrief);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TaskID = new SelectList(db.TaskJobs, "TaskID", "TaskName", tBrief.TaskID);
            return View(tBrief);
        }

        // GET: TBriefs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBrief tBrief = db.TBriefs.Find(id);
            if (tBrief == null)
            {
                return HttpNotFound();
            }
            ViewBag.TaskID = new SelectList(db.TaskJobs, "TaskID", "TaskName", tBrief.TaskID);
            return View(tBrief);
        }

        // POST: TBriefs/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BriefID,StartTime,EndTime,Plan,Action,Finished,TaskID")] TBrief tBrief)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBrief).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TaskID = new SelectList(db.TaskJobs, "TaskID", "TaskName", tBrief.TaskID);
            return View(tBrief);
        }

        // GET: TBriefs/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBrief tBrief = db.TBriefs.Find(id);
            if (tBrief == null)
            {
                return HttpNotFound();
            }
            return View(tBrief);
        }

        // POST: TBriefs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBrief tBrief = db.TBriefs.Find(id);
            db.TBriefs.Remove(tBrief);
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
