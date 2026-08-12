using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementSystem.Data.Configurations
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
               new IdentityRole
               {
                   Id = "54546861-8ad4-4e17-996e-685fddf5d136",
                   Name = "Employee",
                   NormalizedName = "EMPLOYEE"
               },
               new IdentityRole
               {
                   Id = "4499ef20-d1b8-4321-a8bc-9c9d614f7c82",
                   Name = "Supervisor",
                   NormalizedName = "SUPERVISOR"
               },
               new IdentityRole
               {
                   Id = "8dbfaa7e-849a-4802-86c2-2ac2cf5efbd6",
                   Name = "Administrator",
                   NormalizedName = "ADMINSTRATOR"
               }
               );
        }
    }
}
