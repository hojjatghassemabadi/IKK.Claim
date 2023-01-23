using Ikk.Claim.Common.Roles;
using Ikk.Claim.Domain.Commons.Statics;
using Ikk.Claim.Domain.Entities.Users;
using IKK.Claim.Application.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKK.Claim.Persistance.Contexts
{
    public class ClaimDbContext:DbContext,IClaimDbContext
    {
        public ClaimDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(ClaimStatic.SHEMA);
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsRemoved);
            modelBuilder.Entity<Role>().HasData(new Role { Id=1, Name = nameof(UserRoles.Admin) });
            modelBuilder.Entity<User>().HasIndex(u=>u.UserName).IsUnique();
        }
    }
}
