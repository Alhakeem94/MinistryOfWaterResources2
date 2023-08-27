using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MinistryOfWarerResources.BackEnd.Interfaces;
using MinistryOfWarerResources.Data;

namespace MinistryOfWarerResources.BackEnd.Repositories
{
    public class SystemUsersRepo : ISystemUsers
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SystemUsersRepo(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<List<IdentityUser>> GetAllUsers()
        {
            var ListOfAllUsers = await _db.Users.ToListAsync();
            return ListOfAllUsers;
        }
    }
}
