using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.Core.Entities
{
    public class ClientProfile
    {
        public Guid ClientId { get; set; }
        public Guid ProfileId { get; set; }
    }
}