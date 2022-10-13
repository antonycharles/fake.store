using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.Core.Entities
{
    public class ClientProfileEntity
    {
        public Guid ClientId { get; set; }
        public ClientEntity Client { get; set; }
        public Guid ProfileId { get; set; }
        public ProfileEntity Profile { get; set; }
    }
}