using Microsoft.AspNetCore.Identity;

namespace MinistryOfWarerResources.BackEnd.Interfaces
{
    public interface ISystemUsers
    {
        public Task<List<IdentityUser>> GetAllUsers();
    }
}
