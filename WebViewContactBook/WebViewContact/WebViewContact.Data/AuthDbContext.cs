using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebViewContact.WebViewContact.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Seed Roles to Database
            var AdminRoleId = "507f269f - fd9a - 4735 - 9e9f - d550b1a952a0";
            var AppUserRoleId = "b2982176-7a74-4517-be06-073d1beb2ee9";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "admin",
                    Id = AdminRoleId,
                    ConcurrencyStamp = AdminRoleId
                },
                new IdentityRole
                {
                    Name= "AppUser",
                    NormalizedName = "AppUser",
                    Id =  AppUserRoleId,
                    ConcurrencyStamp = AppUserRoleId
                }

            };


            builder.Entity<IdentityRole>().HasData(roles);

            //Seed AdminUser Role
            var adminId = "3a86e762-b981-4aac-a003-154c2cc5235d";
            var adminUser = new IdentityUser
            {
                UserName = "adminUser@webview.com",
                Email = "admin@webview.com",
                NormalizedEmail = "admin@webview.com".ToUpper(),
                NormalizedUserName = "admin@webview.com".ToUpper(),
                Id = adminId,
            };

            adminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(adminUser, "AdminUser@123");

            builder.Entity<IdentityUser>().HasData(adminUser);


            //Add all Roles to AdminUser
            var adminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = AdminRoleId,
                    UserId = adminId,
                },


                new IdentityUserRole<string>
                {
                    RoleId = AppUserRoleId,
                    UserId = adminId,
                },

            };


            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);


        }
    }
}
