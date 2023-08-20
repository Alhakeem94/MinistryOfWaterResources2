using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using MinistryOfWarerResources.BackEnd.Interfaces;
using MinistryOfWarerResources.Data;
using MinistryOfWarerResources.Models;
using MinistryOfWarerResources.ViewModels;
using MudBlazor;

namespace MinistryOfWarerResources.BackEnd.Repositories
{
    public class EmpRepo : IEmp
    {
        private readonly ApplicationDbContext _db;
        private IWebHostEnvironment _env;
        public EmpRepo(ApplicationDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public async Task<string> AddNewEmpToTheSystem(EmpModel NewEmp)
        {
            await _db.EmpTable.AddAsync(NewEmp);
            await _db.SaveChangesAsync();
            return $"The Emp {NewEmp.EmpFullName} Has Been Added to the system";
        }

        public async Task<bool> CheckIfUserExistsInDB(string EmpNumber)
        {
            var CheckIfUserExists = await _db.EmpTable.FirstOrDefaultAsync(a => a.EmpNumber == EmpNumber.Trim());
            // Mohammed Abdullah Abdul-Hakeem    
            if (CheckIfUserExists is null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public async Task<string> DeleteEmp(int EmpId)
        {
            try
            {
                var DeletedEmp = await _db.EmpTable.FirstOrDefaultAsync(a => a.Id == EmpId);
                _db.EmpTable.Remove(DeletedEmp);
                await _db.SaveChangesAsync();
                return $"The Emp with Id :{EmpId} has been Deleted Successfully";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public async Task<string> DeleteListOfEmps(List<int> ListOfDeletedEmps)
        {
            try
            {
                var ListOfDeletedEmp = new List<EmpModel>();

                foreach (var item in ListOfDeletedEmps)
                {
                    var Emp = await _db.EmpTable.FirstOrDefaultAsync(a => a.Id == item);
                    ListOfDeletedEmp.Add(Emp);
                }

                 _db.EmpTable.RemoveRange(ListOfDeletedEmp);
                 await _db.SaveChangesAsync();
                return "the Emps Have been deleted succesfully";
              
            }
            catch (Exception error) 
            {
                return error.Message;
            }
        }

        public async Task<bool> EditEmp(EmpModel EditedData, InputFileChangeEventArgs EditedPic)
        {
            if (EditedPic is null)
            {
                _db.EmpTable.Update(EditedData);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }




        private async Task<string> UploadUserImageToFileSystem(InputFileChangeEventArgs UploadedImage , string EmpName)
        {

            var FileName = EmpName + "_" + Guid.NewGuid().ToString() + $"{UploadedImage.File.Name}";
            // MohammedAbdull_109273918628736127835gbegt675e
            var FolderPath = $"{_env.WebRootPath}\\EmpImages";
            // var FullPath = //server/wwwroot/EmpImages/FileName
            var FullPath = Path.Combine(FolderPath, FileName);

            var MemoryStream = new MemoryStream();
            await UploadedImage.File.OpenReadStream(2000000).CopyToAsync(MemoryStream);


            // FileMode : to give permission to the filestream to create files
            await using (var fs = new FileStream(FullPath, FileMode.Create, FileAccess.Write))
            {
                MemoryStream.WriteTo(fs);
            }

            return FullPath;
        }


        private void DeleteOldUserImage(string OldImagePath)
        {
            if (File.Exists(OldImagePath) == true)
            {
                File.Delete(OldImagePath);
            }
        }

        public async Task<List<EmpModel>> GetListOfAllEmps()
        {
            var ListOfEmps = await _db.EmpTable.AsNoTracking().Include(a=>a.DeptTable).ThenInclude(a=>a.OfficeTable).ToListAsync();
            return ListOfEmps;
        }




        public async Task<EmpViewModel> GetEmpViewModelByUserId(int EmpId)
        {
            var Model = await _db.EmpTable.Include(a=>a.DeptTable).ThenInclude(a=>a.OfficeTable).FirstOrDefaultAsync(a => a.Id == EmpId);

            var EmpViewModel = new EmpViewModel();
            EmpViewModel.Id = Model.Id;
            EmpViewModel.EmpNumber = Model.EmpNumber;
            EmpViewModel.EmpFullName = Model.EmpFullName;
            EmpViewModel.DateOfEmployemnt = Model.DateOfEmployemnt;
            EmpViewModel.OfficeId = Model.DeptTable.OfficeTableId;
            EmpViewModel.EmpDep = Model.EmpDep;
            EmpViewModel.City = Model.City;
            EmpViewModel.EmpSalary = Model.EmpSalary;
            EmpViewModel.EmpAge = Model.EmpAge;
            EmpViewModel.EmploymentStatus = Model.EmploymentStatus;
            EmpViewModel.EmpImagePath = Model.EmpImagePath;

            return EmpViewModel;
        }






        public async Task<string> EditEmpViewModel(EmpViewModel EditedEmp)
        {
            try
            {
                var Model = await _db.EmpTable.FirstOrDefaultAsync(a => a.Id == EditedEmp.Id);

                Model.EmpNumber = EditedEmp.EmpNumber;
                Model.EmpFullName = EditedEmp.EmpFullName;
                Model.DateOfEmployemnt = EditedEmp.DateOfEmployemnt;
                Model.EmpDep = EditedEmp.EmpDep;
                Model.City = EditedEmp.City;
                Model.EmpSalary = EditedEmp.EmpSalary;
                Model.EmpAge = EditedEmp.EmpAge;
                Model.EmploymentStatus = EditedEmp.EmploymentStatus;
                Model.EmpImagePath = EditedEmp.EmpImagePath;

                _db.EmpTable.Update(Model);
                await _db.SaveChangesAsync();
                return "The Recored has been edited succesfully";

            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
