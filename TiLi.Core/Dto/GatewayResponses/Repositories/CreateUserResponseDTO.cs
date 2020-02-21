using System.Collections.Generic;

namespace TiLi.Core.Dto.GatewayResponses.Repositories
{
  public sealed class CreateUserResponseDTO : BaseGatewayResponseDTO
  {
    public string Id { get; }
    public CreateUserResponseDTO(string id, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
    {
      Id = id;
    }
  }
}
