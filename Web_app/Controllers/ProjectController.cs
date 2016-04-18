using System;
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
using RO_IX;

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

        // GET: Project/Create
        public ActionResult Create()
        {
            Project project = new Project();
            project.ProjectName = "Project";
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
                project.New();
                project.SetProjectPrices(ProjectPricesItem.ProjectPricesNew());
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Input/" + project.Id);
            }

            return View(project);
        }

        // GET: Project/Input/5
        public ActionResult Input(int? id)
        {
            // Test!
            //System.Threading.Thread.CurrentThread.CurrentCulture = System.Threading.Thread.CurrentThread.CurrentCulture.Clone() as System.Globalization.CultureInfo;

            //if (System.Threading.Thread.CurrentThread.CurrentCulture != null)
            //{
            //    System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ".";
            //    System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
            //}

            // Test!

            var currentUser = manager.FindById(User.Identity.GetUserId());
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Project project = db.Projects.Find(id);
            Project project = db.Projects
                .Include(p => p.ProjectPrices)
                .Where(i => i.Id == id)
                .Single();
            if (project == null)
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

        // POST: Project/Input/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Input([Bind(Include = "Id,ProjectName,ProjectCurRate,ProjectComment,ProjectDate,BoilerName,BolerPower,BoilerProductivity,BoilerPressure,BoilerEfficiency,BoilerAnnnualLoad,WaterInConductivity,WaterInHardness,WaterInTemperature,WaterCondensateReturn,WaterCondensateConductivity,WaterCondensateTemperature,WaterROConductivity,WaterROConductivityMax,WaterIXConductivity,WaterIXConductivityMax,OptionsRORawProductivity,OptionsROUFOn,OptionsROUFPermeate,OptionsROUFProductivity,OptionsROROOn,OptionsROROPermeate,OptionsROROProductivity,OptionsROIXOn,OptionsROIXPermeate,OptionsROIXProductivity,OptionsROEditOn,OptionsIXRawProductivity,OptionsIXUFOn,OptionsIXUFPermeate,OptionsIXUFProductivity,OptionsIXIX1On,OptionsIXIX1Permeate,OptionsIXIX1Productivity,OptionsIXIX2On,OptionsIXIX2Permeate,OptionsIXIX2Productivity,OptionsIXEditOn,ProjectPrices")] Project project)
        {
            // Test!
            //System.Threading.Thread.CurrentThread.CurrentCulture = System.Threading.Thread.CurrentThread.CurrentCulture.Clone() as System.Globalization.CultureInfo;

            //if (System.Threading.Thread.CurrentThread.CurrentCulture != null)
            //{
            //    System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ".";
            //    System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
            //}

            // Test!

            if (ModelState.IsValid)
            {
                foreach(ProjectPrice projectPriceItem in project.ProjectPrices)
                {
                    db.Entry(projectPriceItem).State = EntityState.Modified;
                }
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Result/" + project.Id);
            }
            return View(project);
        }

        // GET: Project/Result/5
        public ActionResult Result(int? id)
        {
            var currentUser = manager.FindById(User.Identity.GetUserId());
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects
                .Include(p => p.ProjectPrices)
                .Where(i => i.Id == id)
                .Single();
            if (project == null)
            {
                return HttpNotFound();
            }
            if (project.User.Id != currentUser.Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
            Result result = new Result(project);
            return View(result);
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
            List<ProjectPrice> projectPrices = db.ProjectPrices
                .Where(i => i.Project.Id == id)
                .ToList();
            db.ProjectPrices.RemoveRange(projectPrices);
            Project project = db.Projects
                .Where(i => i.Id == id)
                .Single();
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
