using Accounts.Core.Entities;
using Accounts.Infrastructure.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Infrastructure.Data
{
    public class AccountsContext : DbContext
    {
        public AccountsContext(DbContextOptions<AccountsContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                                .SelectMany(t => t.GetForeignKeys())
                                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

                
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityConfiguration).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<ProfileEntity> Profiles { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<CallBackEntity> CallBacks { get; set;} 
        public DbSet<AppEntity> Apps { get; set; }
        public DbSet<ClientProfileEntity> ClientsProfiles { get; set; }
        public DbSet<ProfileRoleEntity> ProfilesRoles { get; set; }
        public DbSet<UserProfileEntity> UsersProfiles { get; set; }
    }
}