using Interview.Models.AuthenticationModels;
using InterviewContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.EmailModels;
using NETCore.MailKit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Controllers
{
    public class RegisterController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
        public RegisterController(
               ILogger<HomeController> logger,
               SignInManager<IdentityUser> signInManager,
               UserManager<IdentityUser> userManager,
               IEmailSender emailSender)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._logger = logger;
            this._emailSender = emailSender;
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
                //var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var token = await this._userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action("ConfirmEmail", "Register", new { userId = user.Id, token = token }, Request.Scheme);
                var userEmailOptions = new UserEmailOptions
                {
                    Subject = "Верификация на имейл"
                };
                userEmailOptions.ToEmails.Add(user.Email);

                await this._emailSender.SendEmailForEmailConfirmation(userEmailOptions, confirmationLink);              
            }
            return RedirectToAction("Initial", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("LogIn", "LogIn");
            }
            var user = await this._userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"Потребител с id {userId} е невалиден";
                return RedirectToAction("NotFound");
            }

            var result = await this._userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                return View(); 
            }

            ViewBag.ErrorTitle = "Имейла не може да бъде потвърден";
            return View("Error");
        }
    }
}
