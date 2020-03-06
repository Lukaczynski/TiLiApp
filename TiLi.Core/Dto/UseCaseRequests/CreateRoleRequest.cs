using System;
using System.Collections.Generic;
using System.Text;
using TiLi.Core.Dto.UseCaseResponses;
using TiLi.Core.Interfaces;

namespace TiLi.Core.Dto.UseCaseRequests
{
    public class CreateRoleRequest : IUseCaseRequest<BaseResponse>
    {
        public CreateRoleRequest(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
