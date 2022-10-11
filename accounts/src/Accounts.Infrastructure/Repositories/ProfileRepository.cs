using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounts.Core.Entities;
using Accounts.Core.Repositories;
using Accounts.Infrastructure.Data;
using Accounts.Infrastructure.Repositories.Base;

namespace Accounts.Infrastructure.Repositories
{
    public class ProfileRepository : Repository<ProfileEntity>, IProfileRepository
    {
        public ProfileRepository(AccountsContext dbContext) : base(dbContext)
        {

        }
    }
}