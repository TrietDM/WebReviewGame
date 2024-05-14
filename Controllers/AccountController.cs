    using Azure.Core;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.EntityFrameworkCore.Internal;
    using WebReviewGame.Models;
    using WebReviewGame.Models.DBEnitity;

    namespace WebReviewGame.Controllers
    {
        public class AccountController : Controller
        {
            private readonly SignInManager<User> _signInManager;
            private readonly UserManager<User> _userManager;
            public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
            {
                _userManager = userManager;
                _signInManager = signInManager;
            }
            public IActionResult Login()
            {
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> Login(LoginViewModel model)
            {
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.Username!,model.Password!,false,false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Post");
                    }
                    ModelState.AddModelError("", "Invalid login attempt");
                    return View(model);
                }
                return View(model) ;
            }

            public IActionResult Register()
            {
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> Register(RegisterViewModel model)
            {
                if (ModelState.IsValid)
                {
                    User user = new()
                    {
                        Email = model.Email,
                        UserName = model.Username,
                        Role = model.Role,

                    };
                    var result = await _userManager.CreateAsync(user,model.Password!);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "client");
                        await _signInManager.SignInAsync(user, false);
                        return RedirectToAction("Index", "Post");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                return View(model);
            }
            public async Task<IActionResult> Logout()
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Login","Account");
            }

        }
    }
