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
    public class GetUserRolesPresenter : IOutputPort<GetUserRolesResponse>
    {
        public JsonContentResult ContentResult { get; }

        public GetUserRolesPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        public void Handle(GetUserRolesResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
