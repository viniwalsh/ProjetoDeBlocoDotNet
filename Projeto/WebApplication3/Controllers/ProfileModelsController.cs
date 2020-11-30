using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Context;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Authorize]
    public class ProfileModelsController : Controller
    {
        private AppContext db = new AppContext();

        // GET: ProfileModels
        public ActionResult Index()
        {
            return View(db.AccountProfileModel.ToList());
        }

        // GET: ProfileModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileModel profileModel = db.AccountProfileModel.Find(id);
            if (profileModel == null)
            {
                return HttpNotFound();
            }
            return View(profileModel);
        }

        // GET: ProfileModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfileModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfileId,ProfileUserName,ProfilePicture,ProfileGender,ProfileCreationTime,ProfileEmail")] ProfileModel profileModel)
        {
            if (ModelState.IsValid)
            {
                profileModel.ProfileId = new Guid(User.Identity.GetUserId());
                profileModel.ProfileLoginId = User.Identity.GetUserId();
                profileModel.ProfileCreationTime = DateTime.Now;
                profileModel.ProfileEmail = User.Identity.GetUserName();
                profileModel.ProfilePicture = "data:image/gif;base64,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eYl553pGeqV7BHtje8J8IXyBfOF9QX2hfgF+Yn7CfyN/hH/lgEeAqIEKgWuBzYIwgpKC9INXg7qEHYSAhOOFR4Wrhg6GcobXhzuHn4gEiGmIzokziZmJ/opkisqLMIuWi/yMY4zKjTGNmI3/jmaOzo82j56QBpBukNaRP5GokhGSepLjk02TtpQglIqU9JVflcmWNJaflwqXdZfgmEyYuJkkmZCZ/JpomtWbQpuvnByciZz3nWSd0p5Anq6fHZ+Ln/qgaaDYoUehtqImopajBqN2o+akVqTHpTilqaYapoum/adup+CoUqjEqTepqar/HKqPqwKrdavprFys0K1ErbiuLa6hrxavi7AAsHWw6rFgsdayS7LCszizrrQltJy1E7WKtgG2ebbwt2i34LhZuNG5SrnCuju6tbsuu6e8IbybvRW9j74KvoS+/796v/XAcMDswWfB48JfwtvDWMPUxFHEzsVLxcjGRsbDx0HHv8g9yLzJOsm5yjjKt8s2y7bMNcy1zTXNtc42zrbPN8+40DnQutE80b7SP9LB00TTxtRJ1MvVTtXR1lXW2Ndc1+DYZNjo2WzZ8dp22vvbgNwF3IrdEN2W3hzeot8p36/gNuC94UThzOJT4tvjY+Pr5HPk/OWE5g3mlucf56noMui8VOlG6dDqW+rl63Dr++yG7RHtnO4o7rTvQO/M8Fjw5fFy8f/yjPMZ86f0NPTC9VD13vZt9vv3ivgZ+Kj5OPnH+lf65/t3/Af8mP0p/br+S/7c/23//wAsAAAAAPQB9AEACP4AIQgcSLCgwYMIEypcyLChw4cQI0qcSLGixYsYM2rcyLGjx48gQ4ocSbKkyZMoU6pcybKly5cwY8qcSbOmzZs4c+rcybOnz59AgwodSrSo0aNIkypdyrSp06dQo0qdSrWq1atYs2rdyrWr169gw4odS7as2bNo06pdy7at27dw48qdS7eu3bt48+rdy7ev37+AAwseTLiw4cOIEytezLix48eQI0ueTLmy5cuYM2vezLmz58+gQ4seTbq06dOoU6tezbq169ewY8ueTbu27du4c+vezbu379/AgwsfTry48ePIkytfzry58+fQo0ufTr269evYs2vfzr279+/gw/6LH0++vPnz6NOrX8++vfv38OPLn0+/vv37+PPr38+/v///AAYo4IAEFmjggQgmqOCCDDbo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";
                db.AccountProfileModel.Add(profileModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profileModel);
        }

        // GET: ProfileModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var loggedId = new Guid(User.Identity.GetUserId());
            if (id != loggedId)
            {
                return RedirectToAction("Edit", "ProfileModels", new { id = User.Identity.GetUserId() });
            }
            ProfileModel profileModel = db.AccountProfileModel.Find(id);
            if (profileModel == null)
            {
                return HttpNotFound();
            }
            return View(profileModel);
        }

        // POST: ProfileModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfileId,ProfileUserName,ProfilePicture,ProfileBackgroundPicture,ProfileGender,ProfileCreationTime,ProfileEmail")] ProfileModel profileModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profileModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details","ProfileModels", new { id = profileModel.ProfileId });
            }
            return View(profileModel);
        }

        // GET: ProfileModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileModel profileModel = db.AccountProfileModel.Find(id);
            if (profileModel == null)
            {
                return HttpNotFound();
            }
            return View(profileModel);
        }

        // POST: ProfileModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ProfileModel profileModel = db.AccountProfileModel.Find(id);
            db.AccountProfileModel.Remove(profileModel);
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
