using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole 
                {
                    Id= "54546861-8ad4-4e17-996e-685fddf5d136",
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

            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true,
                    FirstName = "Default" ,
                    LastName = "Admin",
                    DateOfBirth = new DateOnly(1990, 1, 1)

                });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "8dbfaa7e-849a-4802-86c2-2ac2cf5efbd6",
                    UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
                });
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }
    }
}
