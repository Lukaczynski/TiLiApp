using System;
using System.Collections.Generic;
using System.Text;
using TiLi.Core.Dto.UseCaseResponses;
using TiLi.Core.Interfaces;
using TiLi.Core.Objects;

namespace TiLi.Core.Dto.UseCaseRequests
{
    public class GetUserRoleRequest : IUseCaseRequest<GetUserRolesResponse>
    {
        public GetUserRoleRequest(string userId, Pagination pagination=null)
        {
            UserId = userId;
            Pagination = pagination;
        }

        public string UserId { get; }
        public Pagination Pagination { get; }
    }
}
