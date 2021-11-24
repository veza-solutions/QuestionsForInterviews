using Interview.Models.AuthenticationModels;
using InterviewContracts;
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
        private readonly IUserService _userService;
        public LogInController(
               ILogger<HomeController> logger,
               SignInManager<IdentityUser> signInManager,
               UserManager<IdentityUser> userManager,
               IUserService userService)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._logger = logger;
            this._userService = userService;
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
            var user = await this._userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ViewBag.IsLoggedIn = "Не сте регистриран моля регистрирайте се ";
                return View();
            }
            var isUserRegistered = await this._userService.IsUserRegistered(model.Email);
            var isEmailConfirmed = await this._userManager.IsEmailConfirmedAsync(user);
            if (isUserRegistered == false)
            {

                ViewBag.IsLoggedIn = "Не сте регистриран моля регистрирайте се ";
                return View();
                
            }
            if(isEmailConfirmed == false)
            {
                ViewBag.IsLoggedIn = "Не сте потвърдили регистрацията моля потвърдете на линка изпратен на пощата Ви";

                return View();
            }
            var result = await this._signInManager.PasswordSignInAsync(model.Email,
                               model.Password, true, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                _logger.LogInformation("Успешно влизане.");
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
