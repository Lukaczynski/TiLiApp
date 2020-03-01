using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TiLi.Core.Domain.Entities;
using TiLi.Core.Dto;
using TiLi.Core.Dto.GatewayResponses;
using TiLi.Core.Dto.GatewayResponses.Repositories;
using TiLi.Core.Interfaces.Gateways.Repositories;
using TiLi.Infrastructure.Data.Entities;


namespace TiLi.Infrastructure.Data.EntityFramework.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;

        public UserRepository(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<CreateBaseResponseDTO> Create(User user, string password)
        {
            var appUser = _mapper.Map<AppUser>(user);
            var identityResult = await _userManager.CreateAsync(appUser, password);

            return new CreateBaseResponseDTO(appUser.Id, identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
        }

        public async Task<User> FindByName(string userName)
        {
            return _mapper.Map<User>(await _userManager.FindByNameAsync(userName));
        }

        public async Task<User> FindById(string userId)
        {
            return _mapper.Map<User>(await _userManager.FindByIdAsync(userId));
        }

        public async Task<bool> CheckPassword(User user, string password)
        {
            return await _userManager.CheckPasswordAsync(_mapper.Map<AppUser>(user), password);
        }


        #region User Role Management
        public async Task<CreateBaseResponseDTO> AddRole(string userId, string role)
        {
            var appUser = await _userManager.FindByIdAsync(userId);
            IdentityResult identityResult = await _userManager.AddToRoleAsync(appUser, role);
            return new CreateBaseResponseDTO(appUser.Id, identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
        }

        public async Task<IEnumerable<string>> GetRoles(string userId)
        {
            return await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(userId));
        }

        public async Task<bool> RemoveRole(string userId, string role)
        {
            var appUser = await _userManager.FindByIdAsync(userId);
            var identityResult = await _userManager.RemoveFromRoleAsync(appUser, role);
            return identityResult.Succeeded;
        }
        #endregion User Role Management
    }
}
