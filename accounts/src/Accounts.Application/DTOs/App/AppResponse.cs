using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounts.Core.Enums;

namespace Accounts.Application.DTOs.App
{
    public class AppResponse : BaseResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }

    }
}