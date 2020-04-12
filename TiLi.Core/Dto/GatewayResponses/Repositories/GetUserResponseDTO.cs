using System.Collections.Generic;
using TiLi.Core.Domain.Entities;

namespace TiLi.Core.Dto.GatewayResponses.Repositories
{
    public sealed class GetUserResponseDTO : BaseGatewayResponseDTO
    {
        public User User { get; }
        public GetUserResponseDTO(User User, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            this.User = User;
        }
    }
}
