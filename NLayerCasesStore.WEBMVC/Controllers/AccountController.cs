using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NLayerCasesStore.BLL.DTO;
using NLayerCasesStore.BLL.Interfaces;
using NLayerCasesStore.WEBMVC.ModelsView;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NLayerCasesStore.WEBMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var userDTO = _userService.GetUserOnEmailAndPassword(model.UserMail, model.UserPassword);

                if (userDTO != null)
                {
                    await Authenticate(userDTO.UserMail,userDTO.UserRole);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var isValidLogin = !_userService.CheckLogin(model.UserName);
            var isValidEmail = !_userService.CheckEmail(model.UserMail);

            if (ModelState.IsValid && isValidEmail && isValidLogin)
            {
                var userDto = _mapper.Map<UserDTO>(model);
                _userService.CreateUser(userDto);
                await Authenticate(userDto.UserMail, userDto.UserRole);

                return RedirectToAction("Index", "Home");               

            }

            if (!isValidLogin)
            {
                ModelState.AddModelError("", "Некорректный логин");
            }

            if (!isValidEmail)
            {
                ModelState.AddModelError("", "Некорректный email");
            }

            return View(model);
        }

        private async Task Authenticate(string userEmail, string userRole)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, userEmail),
                new Claim("Role", userRole)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }
    }
}
