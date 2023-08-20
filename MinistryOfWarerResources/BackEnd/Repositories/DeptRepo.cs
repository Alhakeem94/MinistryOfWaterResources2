using Microsoft.EntityFrameworkCore;
using MinistryOfWarerResources.BackEnd.Interfaces;
using MinistryOfWarerResources.Data;
using MinistryOfWarerResources.Models;

namespace MinistryOfWarerResources.BackEnd.Repositories
{
    public class DeptRepo : IDepts
    {

        private readonly ApplicationDbContext _db;

        public DeptRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<string> AddDeptToDb(DepModel NewDeptModel)
        {
            var CheckIfDepExistsInDataBase = await _db.DepTable.FirstOrDefaultAsync(a => a.DepName == NewDeptModel.DepName);

            if (CheckIfDepExistsInDataBase is null)
            {
                await _db.DepTable.AddAsync(NewDeptModel);
                await _db.SaveChangesAsync();
                return $"The Dep :{NewDeptModel.DepName} Has been added to the System";
            }
            else
            {
                return $"The Dep :{NewDeptModel.DepName} Already exists in the system";
            }
        }

        public async Task<List<DepModel>> GetAllDepts()
        {
            return await _db.DepTable.ToListAsync();
        }
    }
}
