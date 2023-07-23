using Microsoft.EntityFrameworkCore;
using MinistryOfWarerResources.BackEnd.Interfaces;
using MinistryOfWarerResources.Data;
using MinistryOfWarerResources.Models;

namespace MinistryOfWarerResources.BackEnd.Repositories
{
    public class OfficeRepo : IOffice
    {

        private ApplicationDbContext _Db;
        public OfficeRepo(ApplicationDbContext Db)
        {
            _Db = Db;
        }

                                                     // HR  LINQ
        public async Task<string> AddNewOffice(OfficeModel NewOffice)
        {
            var CheckIfOfficeExitsInDataBase = await _Db.OfficeTable.FirstOrDefaultAsync(a=>a.OfficeName == NewOffice.OfficeName);            
            if (CheckIfOfficeExitsInDataBase is null)
            {
               await _Db.OfficeTable.AddAsync(NewOffice);
               await _Db.SaveChangesAsync();
               return "The Office Has Been Added Successfuly to the dataBase";
            }
            else
            {
                return "The Office already Exists in the system, please add another office";
            }
        }

        public async Task<List<OfficeModel>> GetAllOffices()
        {
            var ListOfAllOffices = await _Db.OfficeTable.ToListAsync();
            return ListOfAllOffices;
        }
    }
}
