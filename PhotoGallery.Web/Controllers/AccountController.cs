using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using PhotoGallery.Data;
using PhotoGallery.Data.DbContexts;
using PhotoGallery.Service;
using PhotoGallery.Web.Managers;
using System.Web.Mvc;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;

namespace PhotoGallery.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Service.User> _userManager;

        private IAuthenticationManager _authManager => HttpContext.GetOwinContext().Authentication;

        private SignInManager<Service.User, string> _signInManager => new SignInManager<Service.User, string>(_userManager, _authManager);

        public AccountController()
        {
            _userManager =
                new UserManager<Service.User>(
                    new UserStore(new IdentityManager(
                        new DataRepository(new UserDbContext()))));
        }
        
        [ValidateAntiForgeryToken]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Service.User model)
        {
            if (ModelState.IsValid)
            {
                var identity = _userManager.CreateIdentity(model, DefaultAuthenticationTypes.ApplicationCookie);
                _authManager.SignIn(identity);
                return View();
            }

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> RegisterAsync(Service.User model)
        {
            if (ModelState.IsValid)
            {
                await _userManager.CreateAsync(model);

                return RedirectToAction("login");
            }
            return View();
        }

        public ActionResult SignOut()
        {
            _authManager.SignOut();
            return RedirectToAction("login");
        }
    }
}