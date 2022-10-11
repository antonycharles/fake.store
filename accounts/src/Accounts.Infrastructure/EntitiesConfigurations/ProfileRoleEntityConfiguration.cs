using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounts.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accounts.Infrastructure.EntitiesConfigurations
{
    public class ProfileRoleEntityConfiguration : IEntityTypeConfiguration<ProfileRoleEntity>
    {
        public void Configure(EntityTypeBuilder<ProfileRoleEntity> builder)
        {
            builder
                .HasKey(s => new { s.ProfileId, s.RoleId });
        }
    }
}