using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Accounts.Core.Enums;

namespace Accounts.Core.DTO.Apps
{
    public class AppRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 5 )]  
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public StatusEnum Status { get; set; }
    }
}