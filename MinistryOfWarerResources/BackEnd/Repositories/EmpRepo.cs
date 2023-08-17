using Microsoft.EntityFrameworkCore;
using MinistryOfWarerResources.BackEnd.Interfaces;
using MinistryOfWarerResources.Data;
using MinistryOfWarerResources.Models;

namespace MinistryOfWarerResources.BackEnd.Repositories
{
    public class EmpRepo : IEmp
    {
        private readonly ApplicationDbContext _db;

        public EmpRepo(ApplicationDbContext db)
        {
            _db = db;
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

        public async Task<List<EmpModel>> GetListOfAllEmps()
        {
            var ListOfEmps = await _db.EmpTable.AsNoTracking().Include(a=>a.DeptTable).ThenInclude(a=>a.OfficeTable).ToListAsync();
            return ListOfEmps;
        }


    }
}
