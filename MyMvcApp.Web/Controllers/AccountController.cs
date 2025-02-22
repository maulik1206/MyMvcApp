using MyMvcApp.Application.DTOs;
using MyMvcApp.Application.Services;
using MyMvcApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyMvcApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService _userService;
        public AccountController(UserService userService) { _userService = userService; }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<JsonResult> Login(string email, string password)
        {
            try
            {

                if (await IsValidUser(email, password))
                {
                    FormsAuthentication.SetAuthCookie(email, false);
                    return Json(new { success = true, redirectUrl = Url.Action("Index", "User") });
                }

                return Json(new { success = false, message = "Invalid email or password." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        private async Task<bool> IsValidUser(string email, string password)
        {
            return await _userService.LoginAsync(email, password);
        }

        public PartialViewResult RegisterPartial()
        {
            return PartialView("_RegisterPartial", new RegisterViewModel());
        }

        [HttpPost, ActionName("Register")]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<JsonResult> Register(RegisterViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, message = "Invalid input!" });
                }

                await _userService.CreateUserAsync(new UserDTO { Email = model.Email, PasswordHash = model.Password });
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }        
    }
}