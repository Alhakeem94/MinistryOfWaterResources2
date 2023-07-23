using MinistryOfWarerResources.Models;

namespace MinistryOfWarerResources.BackEnd.Interfaces
{
    public interface IOffice
    {
        public Task<string> AddNewOffice(OfficeModel NewOffice);
        public Task<List<OfficeModel>> GetAllOffices();

    }
}


