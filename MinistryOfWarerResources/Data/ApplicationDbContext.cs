using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinistryOfWarerResources.Models;

namespace MinistryOfWarerResources.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<EmpModel> EmpTable { get; set; }
        public DbSet<OfficeModel> OfficeTable { get; set; }
        public DbSet<DepModel> DepTable { get; set; }


    }
}