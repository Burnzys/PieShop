using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PieShop.Models;

namespace PieShop.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(PieUser user)
        {
            if (ModelState.IsValid)
            {
                var temp = await _userManager.FindByNameAsync(user.Username);

                if (temp != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(temp, user.Password, false, false);
                    if (result.Succeeded)
                    {
                        if (string.IsNullOrEmpty(user.ReturnUrl))
                        {
                            return RedirectToAction("Index", "Home");
                        }

                        return Redirect(user.ReturnUrl);
                    }
                }
            }

            ModelState.AddModelError("", "Username or Password not found");
            return View(user);
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(PieUser user)
        {
            if (ModelState.IsValid)
            {
                var temp = new IdentityUser() { UserName = user.Username };
                var result = await _userManager.CreateAsync(temp, user.Password);

                Console.WriteLine(temp.UserName + ", " + result);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}