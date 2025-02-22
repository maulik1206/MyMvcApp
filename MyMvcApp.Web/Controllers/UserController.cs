using MyMvcApp.Application.DTOs;
using MyMvcApp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyMvcApp.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserService _userService;
        public UserController(UserService userService) { _userService = userService; }

        public async Task<ActionResult> Index() => View(await _userService.GetUsersAsync());

        public ActionResult Create() => View();

        [HttpPost]
        public async Task<ActionResult> Create(UserDTO user)
        {
            user.CreatedAt = DateTime.Now;
            if (ModelState.IsValid)
            {
                await _userService.CreateUserAsync(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public async Task<ActionResult> Edit(int id) => View(await _userService.GetUserByIdAsync(id));

        [HttpPost]
        public async Task<ActionResult> Edit(UserDTO user) 
        { 
            if (ModelState.IsValid) 
            { 
                await _userService.UpdateUserAsync(user); 
                return RedirectToAction("Index"); 
            } 
            return View(user); 
        }

        [HttpPost, ActionName("Delete")]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}