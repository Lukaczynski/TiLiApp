using System.Net;
using TiLi.Core.Dto.UseCaseResponses;
using TiLi.Core.Interfaces;
using TiLi.Api.Serialization;
using TiLi.Core.Dto.UseCaseRequests;

namespace TiLi.Api.Presenters
{
    public class BaseResponsePresenter : IOutputPort<BaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public BaseResponsePresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(BaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
