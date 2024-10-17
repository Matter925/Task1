using Microsoft.AspNetCore.Identity;

namespace Task1.Areas.Admin.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<IdentityUser>> GetAllUsersAsync();
    Task<IdentityResult> CreateUserAsync(string email, string password);
    Task AddToRoleAsync(IdentityUser user, string role);
}
