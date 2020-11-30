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
    public class PostModelsController : Controller
    {
        private AppContext db = new AppContext();

        // GET: PostModels
        public ActionResult Index()
        {
            return View(db.PostModel.OrderByDescending(c=>c.PostCreationTime).ToList());
        }

        // GET: PostModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostModel postModel = db.PostModel.Find(id);
            if (postModel == null)
            {
                return HttpNotFound();
            }
            return View(postModel);
        }

        // GET: PostModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId,PostCreationTime,PostCreator,PostDetails,PostPicture,PostLikes")] PostModel postModel)
        {
            if (ModelState.IsValid)
            {
                postModel.PostId = Guid.NewGuid();
                postModel.PostCreationTime = DateTime.Now;
                postModel.PostCreator = User.Identity.GetUserId();
                postModel.PostLikes = 0;
                db.PostModel.Add(postModel);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View(postModel);
        }

        // GET: PostModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostModel postModel = db.PostModel.Find(id);
            if (postModel == null)
            {
                return HttpNotFound();
            }
            return View(postModel);
        }

        // POST: PostModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostId,PostCreationTime,PostCreator,PostDetails,PostPicture,PostLikes")] PostModel postModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postModel);
        }

        // GET: PostModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostModel postModel = db.PostModel.Find(id);
            if (postModel == null)
            {
                return HttpNotFound();
            }
            return View(postModel);
        }

        // POST: PostModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            PostModel postModel = db.PostModel.Find(id);
            db.PostModel.Remove(postModel);
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