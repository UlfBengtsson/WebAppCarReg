using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarReg.Models.Identity;
using WebAppCarReg.Models.ViewModels;

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
        public async Task<IActionResult> Login(IdentityLoginViewModel identityLogin)
        {

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(identityLogin.UserName, identityLogin.Password, false, false);// username,password,presistlogin,lockout

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                /*if (result.IsLockedOut)
                {

                }*/
                ViewBag.Msg = "Failed to login.";
            }
            

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
        public async Task<IActionResult> SignUp(IdentityCreateViewModel identityCreate)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser();
                appUser.UserName = identityCreate.UserName;
                var result = await _userManager.CreateAsync(appUser, identityCreate.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }

                ViewBag.Msg = "Failed to sign up.";
            }
            
            return View(identityCreate);
        }

        //[Authorize] not needed here becouse the controller is set to demand this
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        //change Password/Username .....
    }
}
