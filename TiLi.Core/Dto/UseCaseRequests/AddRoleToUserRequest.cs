using System;
using System.Collections.Generic;
using System.Text;
using TiLi.Core.Dto.UseCaseResponses;
using TiLi.Core.Interfaces;
using TiLi.Core.Objects;

namespace TiLi.Core.Dto.UseCaseRequests
{
    public class AddRoleToUserRequest : IUseCaseRequest<BaseResponse>
    {
        public AddRoleToUserRequest(string userId, string roleId)
        {
            RoleId = roleId;
            UserId = userId;
        }

        public string UserId { get; }
        public string RoleId { get; }

    }
}
