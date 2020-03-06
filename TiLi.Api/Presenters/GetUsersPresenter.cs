using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TiLi.Api.Serialization;
using TiLi.Core.Dto.UseCaseResponses;
using TiLi.Core.Interfaces;

namespace TiLi.Api.Presenters
{
    public class GetUsersPresenter : IOutputPort<GetUsersResponse>
    {
        public JsonContentResult ContentResult { get; }

        public GetUsersPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        public void Handle(GetUsersResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
