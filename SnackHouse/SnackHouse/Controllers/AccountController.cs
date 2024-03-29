﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SnackHouse.Models.ViewModels;
using System;
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
            var d1 = DateTime.Now;
            var d2 = DateTime.Now;
            TimeSpan time = d2 - d1;
            return View(new LoginViewModel()
            {
                
                URL = url
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null)
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
                            return Redirect(model.URL);
                        }
                    }
                }

                ModelState.AddModelError("User", "Usuário não encontrado");
                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(model);
            }
            
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel registerViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new IdentityUser() { UserName = registerViewModel.UserName };

                    var result = await _userManager.CreateAsync(user, registerViewModel.Password);

                    if (result.Succeeded)
                    {
                        //Adiciona o usuário padrão ao perfil member
                        await _userManager.AddToRoleAsync(user, "Member");
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        return RedirectToAction("LoggedIn", "Account");
                    }
                }

                return View(registerViewModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(registerViewModel);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
