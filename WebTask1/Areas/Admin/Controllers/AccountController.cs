using Entites.Dtos.UserDto;
using Entites.Concrete.Models;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bilet1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        //public async Task<IActionResult> Index()
        //{
        //    AppUser user = new AppUser
        //    {
        //        UserName = "Admin",
        //        FullName = "AdminAdmin",

        //    };
        //    await _userManager.CreateAsync(user, "Admin123@");
        //    await _userManager.AddToRoleAsync(user, "Admin");
        //    return Json("ok");
        //}
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            AppUser user = await _userManager.FindByNameAsync(loginDto.UserName);
            var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, true, true);
            if (!result.Succeeded)
            {
                return Json("error");
            }
            return RedirectToAction("Index", "Post");
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");

        }
    }
}
