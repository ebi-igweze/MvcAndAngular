using PhotoGallery.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoGallery.Web.Controllers
{
    public class AccountController : Controller
    {

        private GalleryDbContext _db;

        public AccountController() { _db = new GalleryDbContext(); }

        // GET: Account
        public JsonResult Index()
        {
            var galleries = _db.Galleries.ToList();
            return Json(galleries, JsonRequestBehavior.AllowGet);
        }
    }
}