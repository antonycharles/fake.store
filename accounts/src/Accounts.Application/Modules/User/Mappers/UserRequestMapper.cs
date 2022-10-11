using Accounts.Application.Modules.User.DTO;
using Accounts.Core.Entities;

namespace Accounts.Application.Modules.User.Mappers
{
    public static class UserRequestMapper
    {
        public static UserEntity ToUser(this UserRequest request) => new UserEntity
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email
        };
    }
}