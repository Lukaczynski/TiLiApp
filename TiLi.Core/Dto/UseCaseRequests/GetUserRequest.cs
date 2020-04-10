using System;
using System.Collections.Generic;
using System.Text;
using TiLi.Core.Dto.UseCaseResponses;
using TiLi.Core.Interfaces;
using TiLi.Core.Objects;

namespace TiLi.Core.Dto.UseCaseRequests
{
    public class GetUserRequest : IUseCaseRequest<GetUserResponse>
    {
        public GetUserRequest(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }


    }
}
