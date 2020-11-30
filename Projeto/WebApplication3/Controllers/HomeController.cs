using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Context;

namespace WebApplication3.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private AppContext db = new AppContext();

        public ActionResult Index()
        {
            return View(db.AccountProfileModel.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}