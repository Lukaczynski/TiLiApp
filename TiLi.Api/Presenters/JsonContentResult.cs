using Microsoft.AspNetCore.Mvc;

namespace TiLi.Api.Presenters
{
  public sealed class JsonContentResult : ContentResult
  {
    public JsonContentResult()
    {
      ContentType = "application/json";
    }
  }
}
