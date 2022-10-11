using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounts.Application.Modules.User.DTO;
using Accounts.Core.Entities;

namespace Accounts.Application.Modules.User.Mappers
{
    public static class UserResponseMapper
    {
        public static UserResponse ToResponse(this UserEntity entity) => new UserResponse
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            Status = entity.Status
        };
    }
}