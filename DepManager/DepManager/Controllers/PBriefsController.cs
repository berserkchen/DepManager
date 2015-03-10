﻿using System;
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
    public class PBriefsController : Controller
    {
        private DepManagerContext db = new DepManagerContext();

        // GET: PBriefs
        public ActionResult Index()
        {
            var pBriefs = db.PBriefs.Include(p => p.Project);
            return View(pBriefs.ToList());
        }

        // GET: PBriefs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PBrief pBrief = db.PBriefs.Find(id);
            if (pBrief == null)
            {
                return HttpNotFound();
            }
            return View(pBrief);
        }

        // GET: PBriefs/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName");
            return View();
        }

        // POST: PBriefs/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BriefID,StartTime,EndTime,Plan,Action,ProjectID")] PBrief pBrief)
        {
            if (ModelState.IsValid)
            {
                db.PBriefs.Add(pBrief);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", pBrief.ProjectID);
            return View(pBrief);
        }

        // GET: PBriefs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PBrief pBrief = db.PBriefs.Find(id);
            if (pBrief == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", pBrief.ProjectID);
            return View(pBrief);
        }

        // POST: PBriefs/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BriefID,StartTime,EndTime,Plan,Action,ProjectID")] PBrief pBrief)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pBrief).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", pBrief.ProjectID);
            return View(pBrief);
        }

        // GET: PBriefs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PBrief pBrief = db.PBriefs.Find(id);
            if (pBrief == null)
            {
                return HttpNotFound();
            }
            return View(pBrief);
        }

        // POST: PBriefs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PBrief pBrief = db.PBriefs.Find(id);
            db.PBriefs.Remove(pBrief);
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
