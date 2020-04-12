using System;
using System.Collections.Generic;
using System.Text;
using TiLi.Core.Dto.UseCaseResponses;
using TiLi.Core.Interfaces;
using TiLi.Core.Objects;

namespace TiLi.Core.Dto.UseCaseRequests
{
    public class GetProjectsRequest : IUseCaseRequest<GetProjectsResponse>
    {
        public GetProjectsRequest(Pagination pagination)
        {
            Pagination = pagination;
        }

        public Pagination Pagination { get; }

    }
}
