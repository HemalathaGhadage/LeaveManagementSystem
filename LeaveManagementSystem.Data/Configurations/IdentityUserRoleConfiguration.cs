using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Data.Configurations
{
    public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Microsoft.AspNetCore.Identity.IdentityUserRole<string>> builder)
        {

            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "8dbfaa7e-849a-4802-86c2-2ac2cf5efbd6",
                    UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
                });
        }
    }
}
