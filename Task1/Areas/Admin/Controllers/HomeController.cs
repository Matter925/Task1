using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Task1.Areas.Admin.Models;
using Task1.Areas.Admin.Services.Interfaces;

namespace Task1.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class HomeController : Controller
{
    private readonly IUserService _userService;

    public HomeController(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _userService.GetAllUsersAsync();
        return View(users);
    }

    // GET: Admin/CreateUser
    public IActionResult CreateUser()
    {
        return View();
    }

    // POST: Admin/CreateUser
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateUser(UserViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _userService.CreateUserAsync(model.Email, model.Password);

            if (result.Succeeded)
            {
                var user = await _userService.GetAllUsersAsync()
                    .ContinueWith(task => task.Result.FirstOrDefault(u => u.Email == model.Email));
                await _userService.AddToRoleAsync(user, "User");

                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View(model);
    }
}