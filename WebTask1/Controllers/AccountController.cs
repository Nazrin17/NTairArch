using Entites.Dtos.UserDto;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bilet1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        //public async Task<IActionResult> Index()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "User" });

        //    return Json("ok");
        //}
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto userRegister)
        {
            AppUser user = new AppUser
            {
                FullName = userRegister.FullName,
                Email = userRegister.Email,
                UserName = userRegister.UserName,
            };
            var result=await _userManager.CreateAsync(user, userRegister.Password);
            if (!result.Succeeded)
            {
                //ModelState.AddModelError("", "password or username incorrect");
                return Json("error");
            }
            await _userManager.AddToRoleAsync(user, "user");
            return RedirectToAction("index", "home");
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            AppUser user = await _userManager.FindByNameAsync(loginDto.UserName);
            var result =await _signInManager.PasswordSignInAsync(user, loginDto.Password, true, true);
            if (!result.Succeeded)
            {
                return Json("error");
            }
            return RedirectToAction("Index", "home");
        }
        public async Task<IActionResult> LogOut()
        {
           await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "home");

        }

    }
}
