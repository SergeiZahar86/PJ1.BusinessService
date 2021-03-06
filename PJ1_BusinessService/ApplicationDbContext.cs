using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using PJ1_BusinessService.ConfigurationModels;
using PJ1_BusinessService.models;

namespace PJ1_BusinessService
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        /// <summary>
        /// Набор сущностей  WorkedTimes
        /// </summary>
        public DbSet<WorkedTimes> WorkedTimes { get; set; }

        /// <summary>
        /// Настраивает схему, необходимую для структуры идентификации
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>(entity => entity.ToTable(name: "Users"));

            builder.Entity<AppRole>(entity => entity.ToTable(name: "Roles"));

            builder.Entity<IdentityUserRole<int>>(entity => entity.ToTable(name: "UserRoles"));

            builder.Entity<IdentityUserClaim<int>>(entity => entity.ToTable(name: "UserClaim"));

            builder.Entity<IdentityUserLogin<int>>(entity => entity.ToTable("UserLogins"));

            builder.Entity<IdentityUserToken<int>>(entity => entity.ToTable("UserTokens"));

            builder.Entity<IdentityRoleClaim<int>>(entity => entity.ToTable("RoleClaims"));

            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new WorkTimesConfiguration());

        }
    }
}
