using System;
using System.Collections.Generic;
using System.Text;
using TiLi.Core.Dto.UseCaseRequests;
using TiLi.Core.Dto.UseCaseResponses;

namespace TiLi.Core.Interfaces.UseCases
{
    public interface IGetUserRoleUseCase : IUseCaseRequestHandler<GetUserRoleRequest, GetUserRolesResponse>
    {
    }
}
