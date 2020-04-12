using System.Collections.Generic;
using System.Threading.Tasks;
using TiLi.Core.Domain.Entities;
using TiLi.Core.Dto.GatewayResponses;
using TiLi.Core.Objects;

namespace TiLi.Core.Interfaces.Gateways.Repositories
{
    public interface IProjectRepository
    {
        Task<CreateBaseResponseDTO> Create(Project project);
        Task<Project> FindByName(string projectName);
        Task<IEnumerable<Project>> GetAll(Pagination pagination);
    }
}
