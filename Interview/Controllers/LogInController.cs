using Interview.Models.AuthenticationModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Controllers
{
    public class LogInController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        public LogInController(
               ILogger<HomeController> logger,
               SignInManager<IdentityUser> signInManager,
               UserManager<IdentityUser> userManager)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._logger = logger;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult LogIn()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Initial", "Home");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn(LogInViewModel model)
        {            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var result = await this._signInManager.PasswordSignInAsync(model.Email,
                           model.Password,true, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                _logger.LogInformation("Успешно влизане.");               
            }
            return RedirectToAction("Initial", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Initial", "Home");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
                
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {                
                await _signInManager.SignInAsync(user, isPersistent: false);               
            }
            return RedirectToAction("Initial", "Home");
        }

        [HttpGet]
        [AllowAnonymous]

        public async Task<IActionResult> LogOut()
        {
            await this._signInManager.SignOutAsync();
            return RedirectToAction("LogIn");
        }
    }
}
