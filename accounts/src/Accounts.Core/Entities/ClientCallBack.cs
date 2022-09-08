using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.Core.Entities
{
    public class ClientCallBack : BaseEntity
    {
        [Required]
        public string Url { get; set; }
        [Required]
        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}