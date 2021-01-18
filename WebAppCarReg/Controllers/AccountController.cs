using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarReg.Models.Identity;

namespace WebAppCarReg.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) // Constructor Injection
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string userName, string password)
        {

            var result = await _signInManager.PasswordSignInAsync(userName, password, false, false);// username,password,presistlogin,lockout

            if (result.Succeeded)
            {
                return RedirectToAction("Index","Home");
            }
            /*if (result.IsLockedOut)
            {

            }*/
            ViewBag.Msg = "Failed to login.";

            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(string userName, string password)
        {
            AppUser appUser = new AppUser();
            appUser.UserName = userName;
            var result = await _userManager.CreateAsync(appUser, password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }

            ViewBag.Msg = "Failed to sign up.";

            return View();
        }
    }
}
