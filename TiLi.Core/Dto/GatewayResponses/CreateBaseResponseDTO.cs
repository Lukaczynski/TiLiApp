using System;
using System.Collections.Generic;
using System.Text;

namespace TiLi.Core.Dto.GatewayResponses
{
    public class CreateBaseResponseDTO : BaseGatewayResponseDTO
    {
        public string Id { get; }
        public CreateBaseResponseDTO(string id, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Id = id;
        }
    }
}
