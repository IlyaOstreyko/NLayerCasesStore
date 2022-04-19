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
        private readonly IUnitOfWorkService _iUnitOfWorkService;
        private readonly IMapper _mapper;

        public AccountController(IUnitOfWorkService iUnitOfWorkService, IMapper mapper)
        {
            _iUnitOfWorkService = iUnitOfWorkService;
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
                var userDTO = _iUnitOfWorkService.Users.GetUserOnEmailAndPassword(model.UserMail, model.UserPassword);

                if (userDTO != null && userDTO.UserMail != null)
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
            var isValidLogin = !_iUnitOfWorkService.Users.CheckLogin(model.UserName);
            var isValidEmail = !_iUnitOfWorkService.Users.CheckEmail(model.UserMail);

            if (ModelState.IsValid && isValidEmail && isValidLogin)
            {
                var userDto = _mapper.Map<UserDTO>(model);
                _iUnitOfWorkService.Users.CreateUser(userDto);
                userDto.UserRole = "user";
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
