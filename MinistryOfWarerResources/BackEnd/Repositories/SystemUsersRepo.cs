using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MinistryOfWarerResources.BackEnd.Interfaces;
using MinistryOfWarerResources.Data;
using MinistryOfWarerResources.ViewModels;

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

        public async Task<bool> AddUserToAdminRole(string UserId)
        {
            try
            {

                var User = await _userManager.FindByIdAsync(UserId);
                var ListOfRoles = await _userManager.GetRolesAsync(User);
                if (ListOfRoles.Count == 0)
                {
                    await _userManager.AddToRoleAsync(User, "admin");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public async Task<bool> AddUserToRegulatorRole(string UserId)
        {
            try
            {
                var User = await _userManager.FindByIdAsync(UserId);
                var ListOfRoles = await _userManager.GetRolesAsync(User);
                if (ListOfRoles.Count == 0)
                {
                    await _userManager.AddToRoleAsync(User, "regulator");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public async Task<bool> EditRoleFromAdminToRegulator(string UserId)
        {
            var User = await _userManager.FindByIdAsync(UserId);
            await _userManager.RemoveFromRoleAsync(User, "admin");
            var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "regulator");
            await _userManager.AddToRoleAsync(User, "regulator");
            return true;
        }

        public async Task<bool> EditRoleFromRegulatorToAdmin(string UserId)
        {
            var User = await _userManager.FindByIdAsync(UserId);
            var UserRole = await _db.UserRoles.FirstOrDefaultAsync(a => a.UserId == UserId);
            var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "admin");
            UserRole.RoleId = RoleRecored.Id;
            _db.UserRoles.Update(UserRole);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<IdentityUser>> GetAllUsers()
        {
            var ListOfAllUsers = await _db.Users.ToListAsync();
            return ListOfAllUsers;
        }

        public async Task<List<AllUsersViewModel>> GetListOfAllUsersWithRoles()
        {
            var ListOfAllUsers = await _db.Users.ToListAsync();
            var ListOfViewModels = new List<AllUsersViewModel>();

            foreach (var User in ListOfAllUsers)
            {
                var CheckIfHasARole = await _db.UserRoles.FirstOrDefaultAsync(a => a.UserId == User.Id);

                if (CheckIfHasARole is null)
                {
                    var ViewModel = new AllUsersViewModel();
                    ViewModel.UserId = User.Id;
                    ViewModel.UserName = User.UserName;
                    ViewModel.PassWord = User.PasswordHash;
                    ViewModel.Role = "";
                    ViewModel.HasARole = false;

                    ListOfViewModels.Add(ViewModel);
                }
                else
                {
                    var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Id == CheckIfHasARole.RoleId);
                    var RoleName = RoleRecored.Name;

                    var ViewModel = new AllUsersViewModel();
                    ViewModel.UserId = User.Id;
                    ViewModel.UserName = User.UserName;
                    ViewModel.PassWord = User.PasswordHash;
                    ViewModel.Role = RoleName;
                    ViewModel.HasARole = true;

                    ListOfViewModels.Add(ViewModel);

                }
            }

            return ListOfViewModels;
        }
    }
}
