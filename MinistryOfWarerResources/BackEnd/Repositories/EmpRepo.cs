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
    }
}
