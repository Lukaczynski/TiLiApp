using System;
using System.Collections.Generic;
using System.Text;
using TiLi.Core.Dto.UseCaseResponses;
using TiLi.Core.Interfaces;

namespace TiLi.Core.Dto.UseCaseRequests
{
    public class CreateProjectRequest : IUseCaseRequest<BaseResponse>
    {
        public CreateProjectRequest(string name, string description="")
        {
            Name = name;
            Description = description;
        }

        public string Name { get;  }
        public string Description { get; }

    }
}
