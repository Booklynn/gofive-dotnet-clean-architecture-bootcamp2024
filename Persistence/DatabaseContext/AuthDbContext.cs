using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DatabaseContext;
public class AuthDbContext(DbContextOptions<AuthDbContext> options) : IdentityDbContext(options) 
{
    protected override void OnModelCreating(ModelBuilder builder) 
    {
        base.OnModelCreating(builder);

        var readerRoleId = "28d65a5b-a7db-4850-b380-83591f7d7531";
        var writerRoleId = "9740f16c-24a1-4224-a7be-1bb00b7c6892";

        var roles = new List<IdentityRole>() {
            new() 
            {
                Id = readerRoleId,
                Name = "Reader",
                NormalizedName = "Reader".ToUpper(),
                ConcurrencyStamp = readerRoleId
            },
            new()
            {
                Id = writerRoleId,
                Name = "Writer",
                NormalizedName = "Writer".ToUpper(),
                ConcurrencyStamp = writerRoleId
            }
        };

        builder.Entity<IdentityRole>().HasData(roles);

        var adminUserId = "edc267ec-d43c-4e3b-8108-a1a1f819906d";
        var admin = new IdentityUser() {
            Id = adminUserId,
            UserName = "admin@gmail.com",
            Email = "admin@gmail.com",
            NormalizedEmail = "admin@gmail.com".ToUpper(),
            NormalizedUserName = "admin@gmail.com".ToUpper()
        };

        admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Admin@123");

        builder.Entity<IdentityUser>().HasData(admin);

        var adminRoles = new List<IdentityUserRole<string>>()
        {
            new()
            {
                UserId = adminUserId,
                RoleId = readerRoleId
            },
            new()
            {
                UserId = adminUserId,
                RoleId = writerRoleId
            }
        };

        builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
    }
}
