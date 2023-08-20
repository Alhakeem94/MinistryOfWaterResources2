using MinistryOfWarerResources.Models;

namespace MinistryOfWarerResources.BackEnd.Interfaces
{
    public interface IDepts
    {
        public Task<string> AddDeptToDb(DepModel NewDeptModel);
        public Task<List<DepModel>> GetAllDepts();

    }
}
