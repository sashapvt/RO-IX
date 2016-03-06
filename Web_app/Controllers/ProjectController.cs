﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_app.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Web_app.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UserManager<ApplicationUser> manager;

        public ProjectController()
        {
            manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

    // GET: Project
    public ActionResult Index()
        {
            var currentUser = manager.FindById(User.Identity.GetUserId());
            return View(db.Projects.ToList().Where(Project => Project.User.Id == currentUser.Id));
        }

        // GET: Project/Details/5
        public ActionResult Details(int? id)
        {
            var currentUser = manager.FindById(User.Identity.GetUserId());
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            if (project.User.Id != currentUser.Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
            return View(project);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            Project project = new Project();
            project.New();
            return View(project);
        }

        // POST: Project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProjectName,ProjectCurRate,ProjectComment,ProjectDate,BoilerName,BolerPower,BoilerProductivity,BoilerPressure,BoilerEfficiency,BoilerAnnnualLoad,WaterInConductivity,WaterInHardness,WaterInTemperature,WaterCondensateReturn,WaterCondensateConductivity,WaterCondensateTemperature,WaterROConductivity,WaterROConductivityMax,WaterIXConductivity,WaterIXConductivityMax,OptionsRORawProductivity,OptionsROUFOn,OptionsROUFPermeate,OptionsROUFProductivity,OptionsROROOn,OptionsROROPermeate,OptionsROROProductivity,OptionsROIXOn,OptionsROIXPermeate,OptionsROIXProductivity,OptionsROEditOn,OptionsIXRawProductivity,OptionsIXUFOn,OptionsIXUFPermeate,OptionsIXUFProductivity,OptionsIXIX1On,OptionsIXIX1Permeate,OptionsIXIX1Productivity,OptionsIXIX2On,OptionsIXIX2Permeate,OptionsIXIX2Productivity,OptionsIXEditOn")] Project project)
        {
            var currentUser = manager.FindById(User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                project.User = currentUser;
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int? id)
        {
            var currentUser = manager.FindById(User.Identity.GetUserId());
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            if (project.User.Id != currentUser.Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
            return View(project);
        }

        // POST: Project/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProjectName,ProjectCurRate,ProjectComment,ProjectDate,BoilerName,BolerPower,BoilerProductivity,BoilerPressure,BoilerEfficiency,BoilerAnnnualLoad,WaterInConductivity,WaterInHardness,WaterInTemperature,WaterCondensateReturn,WaterCondensateConductivity,WaterCondensateTemperature,WaterROConductivity,WaterROConductivityMax,WaterIXConductivity,WaterIXConductivityMax,OptionsRORawProductivity,OptionsROUFOn,OptionsROUFPermeate,OptionsROUFProductivity,OptionsROROOn,OptionsROROPermeate,OptionsROROProductivity,OptionsROIXOn,OptionsROIXPermeate,OptionsROIXProductivity,OptionsROEditOn,OptionsIXRawProductivity,OptionsIXUFOn,OptionsIXUFPermeate,OptionsIXUFProductivity,OptionsIXIX1On,OptionsIXIX1Permeate,OptionsIXIX1Productivity,OptionsIXIX2On,OptionsIXIX2Permeate,OptionsIXIX2Productivity,OptionsIXEditOn")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int? id)
        {
            var currentUser = manager.FindById(User.Identity.GetUserId());
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            if (project.User.Id != currentUser.Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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
