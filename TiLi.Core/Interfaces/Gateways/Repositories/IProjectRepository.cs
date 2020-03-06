using System.Threading.Tasks;
using TiLi.Core.Domain.Entities;
using TiLi.Core.Dto.GatewayResponses;

namespace TiLi.Core.Interfaces.Gateways.Repositories
{
    public interface IProjectRepository
    {
        Task<CreateBaseResponseDTO> Create(Project project);
        Task<User> FindByName(string projectName);
    }
}
