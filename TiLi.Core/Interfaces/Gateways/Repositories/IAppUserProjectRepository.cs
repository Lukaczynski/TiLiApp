using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiLi.Core.Domain.Entities;
using TiLi.Core.Dto.GatewayResponses;
using TiLi.Core.Objects;

namespace TiLi.Core.Interfaces.Gateways.Repositories
{
    public interface IAppUserProjectRepository
    {
        Task<CreateBaseResponseDTO> Create(UserProject project);
        Task<UserProject> FindByName(string projectName);
        Task<IEnumerable<UserProject>> GetProjects(Pagination pagination);
    }
}
