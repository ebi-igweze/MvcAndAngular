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
    [AllowAnonymous]
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
        
        //[ValidateAntiForgeryToken]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Login(Login model, string returnUrl)
        {
            if (!ModelState.IsValid)return View(model);
            //var newModel = new Service.User(model);

            await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: model.RememberMe, shouldLockout: false);
            return RedirectToAction("index", "Home");
        }

        public ActionResult Register()
        {
            var model = new Service.User();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Register(Service.User model)
        {
            if (!ModelState.IsValid) return View(model);

            var result =  _userManager.Create(model, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(model, isPersistent:false, rememberBrowser:false);
                return RedirectToAction("Index", "Home");
            }
            
            return View(model);
        }

        public ActionResult SignOut()
        {
            _authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("login");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}