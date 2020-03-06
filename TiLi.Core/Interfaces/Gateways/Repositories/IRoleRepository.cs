using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiLi.Core.Domain.Entities;
using TiLi.Core.Dto.GatewayResponses;

namespace TiLi.Core.Interfaces.Gateways.Repositories
{
    public interface IRoleRepository
    {
        Task<CreateBaseResponseDTO> Create(Role rol);
        Task<IEnumerable<Role>> GetAll();
        Task<Role> Update(Role rol, string rolId);
    }
}
