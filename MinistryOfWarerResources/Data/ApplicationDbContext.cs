using Microsoft.AspNetCore.Identity;
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



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            const string Owner_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string OwnerRole_ID = "oi2eoij-1oqjsdkj-kaslk-OwnerRole";

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = OwnerRole_ID,
                Name = "owner",
                NormalizedName = "OWNER"
            });
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "09iasdlkamsoidu9a8sdkasmd",
                Name = "admin",
                NormalizedName = "ADMIN"
            });
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "09iasdlkamsoidu9a8sdkapiasjdm",
                Name = "regulator",
                NormalizedName = "REGULATOR"
            });

            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = Owner_ID,
                UserName = "MohammedOwner",
                NormalizedUserName = "MOHAMMEDOWNER",
                Email = "MohammedOwner",
                NormalizedEmail = "MOHAMMEDOWNER",
                EmailConfirmed = true,
                PasswordHash =  "Moh12345_",
                SecurityStamp = Guid.NewGuid().ToString()
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = OwnerRole_ID,
                UserId = Owner_ID
            });

         

        }
    }
}