using Microsoft.AspNetCore.Identity;
using Task1.Areas.Admin.Services.Interfaces;

namespace Task1.Areas.Admin.Services.Implementation;

public class UserService : IUserService
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserService(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IEnumerable<IdentityUser>> GetAllUsersAsync()
    {
        return  _userManager.Users.ToList();
    }

    public async Task<IdentityResult> CreateUserAsync(string email, string password)
    {
        var user = new IdentityUser { UserName = email, Email = email };
        return await _userManager.CreateAsync(user, password);
    }

    public async Task AddToRoleAsync(IdentityUser user, string role)
    {
        await _userManager.AddToRoleAsync(user, role);
    }
}

