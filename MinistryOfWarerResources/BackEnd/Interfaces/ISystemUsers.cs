using Microsoft.AspNetCore.Identity;
using MinistryOfWarerResources.ViewModels;

namespace MinistryOfWarerResources.BackEnd.Interfaces
{
    public interface ISystemUsers
    {
        public Task<List<IdentityUser>> GetAllUsers();
        public Task<bool> AddUserToAdminRole(string UserId);
        public Task<bool> AddUserToRegulatorRole(string UserId);
        public Task<List<AllUsersViewModel>> GetListOfAllUsersWithRoles();
        public Task<bool> EditRoleFromAdminToRegulator(string UserId);
        public Task<bool> EditRoleFromRegulatorToAdmin(string UserId);

    }
}
