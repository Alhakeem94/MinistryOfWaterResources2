using MinistryOfWarerResources.Models;

namespace MinistryOfWarerResources.BackEnd.Interfaces
{
    public interface IEmp
    {
        public Task<bool> CheckIfUserExistsInDB(string EmpNumber);
        public Task<string> AddNewEmpToTheSystem(EmpModel NewEmp);
    }
}
