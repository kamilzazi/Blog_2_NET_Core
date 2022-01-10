using Blog_2.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_2.Controllers
{
    public class AuthController : Controller
    {
        private SignInManager<IdentityUser> _signManager;

        public AuthController(SignInManager<IdentityUser> signManager)
        {
            _signManager = signManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            var result = await _signManager.PasswordSignInAsync(vm.UserName, vm.Password, false, false);

            return RedirectToAction("Index", "Panel");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
