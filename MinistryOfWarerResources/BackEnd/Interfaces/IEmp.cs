using MinistryOfWarerResources.Models;

namespace MinistryOfWarerResources.BackEnd.Interfaces
{
    public interface IEmp
    {
        public Task<bool> CheckIfUserExistsInDB(string EmpNumber);
        public Task<string> AddNewEmpToTheSystem(EmpModel NewEmp);
        public Task<List<EmpModel>> GetListOfAllEmps();
        public Task<string> DeleteEmp(int EmpId);
        public Task<string> DeleteListOfEmps(List<int> ListOfDeletedEmps);
    }
}

