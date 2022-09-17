using Accounts.Core.Enums;

namespace Accounts.Application.DTO.Roles
{
    public class RoleResponse : BaseResponse
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public bool IsSystem { get; set; }
        public StatusEnum Status { get; set; }
        public Guid? FatherId { get; set; }
        public Guid AppId { get; set; }
    }
}