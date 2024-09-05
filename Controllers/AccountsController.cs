using IdentityApp.Data;
using IdentityApp.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountsController(ApplicationDbContext context , UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Register(RegisterViewModel model)
        {
            IdentityUser user = new IdentityUser()
            {
                UserName = model.Name,
                Email = model.Email,
                PasswordHash = model.Password,

            };
           var result=await  userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");

            }
            return View(model);
        }
        public IActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Email , model.Password, model.RememberMe, true);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Home");
            }
            return View(model);

        }
    }
}
