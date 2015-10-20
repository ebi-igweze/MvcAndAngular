using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoGallery.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Galleries()
        {
            var result = new object { };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateGallery()
        {
            return View();
        }
    }
}