using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.Core.Entities
{
    public class CallBackEntity : BaseEntity
    {
        [Required]
        public string Url { get; set; }
        [Required]
        public Guid AppId { get; set; }
        public virtual AppEntity App { get; set; }
    }
}