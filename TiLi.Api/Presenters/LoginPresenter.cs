using System.Net;
using TiLi.Core.Dto.UseCaseResponses;
using TiLi.Core.Interfaces;
using TiLi.Serialization;

namespace TiLi.Presenters
{
  public sealed class LoginPresenter : IOutputPort<LoginResponse>
  {
    public JsonContentResult ContentResult { get; }

    public LoginPresenter()
    {
      ContentResult = new JsonContentResult();
    }

    public void Handle(LoginResponse response)
    {
      ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.Unauthorized);
      ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Token) : JsonSerializer.SerializeObject(response.Errors);
    }
  }
}
