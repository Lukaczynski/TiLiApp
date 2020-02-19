using Microsoft.AspNetCore.Mvc;

namespace TiLi.Presenters
{
  public sealed class JsonContentResult : ContentResult
  {
    public JsonContentResult()
    {
      ContentType = "application/json";
    }
  }
}
