using Microsoft.AspNetCore.Components.Forms;
using MinistryOfWarerResources.Models;
using MinistryOfWarerResources.ViewModels;

namespace MinistryOfWarerResources.BackEnd.Interfaces
{
    public interface IEmp
    {
        public Task<bool> CheckIfUserExistsInDB(string EmpNumber);
        public Task<string> AddNewEmpToTheSystem(EmpModel NewEmp);
        public Task<List<EmpModel>> GetListOfAllEmps();
        public Task<string> DeleteEmp(int EmpId);
        public Task<string> DeleteListOfEmps(List<int> ListOfDeletedEmps);
        public Task<bool> EditEmp(EmpModel EditedData, InputFileChangeEventArgs EditedPic);
        public Task<EmpViewModel> GetEmpViewModelByUserId(int EmpId);
        public Task<string> EditEmpViewModel(EmpViewModel EditedEmp);
    }
}

