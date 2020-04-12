using System.Collections.Generic;
using System.Threading.Tasks;
using TiLi.Core.Domain.Entities;
using TiLi.Core.Dto;
using TiLi.Core.Dto.GatewayResponses;
using TiLi.Core.Dto.GatewayResponses.Repositories;
using TiLi.Core.Objects;

namespace TiLi.Core.Interfaces.Gateways.Repositories
{
    public interface IUserRepository
    {
        Task<CreateBaseResponseDTO> Create(User user, string password);
        Task<User> FindByName(string userName);
        Task<User> FindById(string userId);
        Task<bool> CheckPassword(User user, string password);

        Task<IEnumerable<User>> GetUsers(Pagination pagination);

        #region Role
        Task<CreateBaseResponseDTO> AddRole(string user, string role);
        Task<CreateBaseResponseDTO> RemoveRole(string user, string role);
        Task<IEnumerable<string>> GetRoles(string userId, Pagination pagination);
    
        #endregion Role
    }
}
