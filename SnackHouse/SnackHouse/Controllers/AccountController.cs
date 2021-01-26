using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SnackHouse.Models.ViewModels;
using System.Threading.Tasks;

namespace SnackHouse.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public ActionResult Login(string url)
        {
            return View(new LoginViewModel()
            {
                URL = url
            });
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.UserName);

            if(user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(model.URL))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction(model.URL);
                    }
                }
            }

            ModelState.AddModelError("", "Usuário não encontrado");
            return View(model);
        }

    }
}
