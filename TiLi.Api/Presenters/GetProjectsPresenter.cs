using System.Net;
using TiLi.Core.Dto.UseCaseResponses;
using TiLi.Core.Interfaces;
using TiLi.Api.Serialization;

namespace TiLi.Api.Presenters
{
    public class GetProjectsPresenter : IOutputPort<GetProjectsResponse>
    {
        public JsonContentResult ContentResult { get; }

        public GetProjectsPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        public void Handle(GetProjectsResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
