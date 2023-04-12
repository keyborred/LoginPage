using LoginPage.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LoginPage.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Username == "myusername" && model.Password == "mypassword")
                {
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Username),
                new Claim(ClaimTypes.Role, "User")
            };
                    var identity = new ClaimsIdentity(claims, "MyAuthScheme");
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync("MyAuthScheme", principal);
                    return RedirectToAction("Welcome", "Home");
                }
                ModelState.AddModelError("", "Invalid username or password");
            }
            return View(model);
        }





    }

}
