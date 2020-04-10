using System.Collections.Generic;
using TiLi.Core.Domain.Entities;

namespace TiLi.Core.Dto.GatewayResponses.Repositories
{
    public sealed class GetRolesResponseDTO : BaseGatewayResponseDTO
    {
        public string UserId { get; }
        public IEnumerable<Role> Roles { get; }
        public GetRolesResponseDTO(string userId, IEnumerable<Role> roles, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            UserId = userId;
            Roles = roles;
        }
    }
}
