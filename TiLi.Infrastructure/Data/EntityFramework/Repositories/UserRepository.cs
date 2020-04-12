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
using TiLi.Core.Objects;
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

        public async Task<IEnumerable<User>> GetUsers(Pagination pagination)
        {

            if (pagination != null)
            {
                var x = _userManager.Users.Where(x => true).ToList();
                return await Task.Run(() =>
                {
                    return _userManager.Users.
                    OrderBy(x => x.UserName)
                    .Skip((pagination.Pege - 1) * pagination.Limit)
                    .Take(pagination.Pege)
                    .Select(x => _mapper.Map<User>(x))
                    .AsEnumerable()
;
                });
            }
            return await Task.Run(() =>
            {
                var test = _userManager.Users
                .OrderBy(x => x.UserName);
                return _userManager.Users
                .OrderBy(x => x.UserName)
                .Select(x => _mapper.Map<User>(x))
                .AsEnumerable()
                ;
            });
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
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new System.Exception("userId (" + userId + ") not found.") { Source = this.ToString() };
            }
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<CreateBaseResponseDTO> RemoveRole(string userId, string role)
        {

            var appUser = await _userManager.FindByIdAsync(userId);
            var identityResult = await _userManager.RemoveFromRoleAsync(appUser, role);
            return new CreateBaseResponseDTO(appUser.Id, identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
        }

        public async Task<IEnumerable<string>> GetRoles(string userId, Pagination pagination)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new System.Exception("userId (" + userId + ") not found.") { Source = this.ToString() };
            }

            return await _userManager.GetRolesAsync(user);
        }
        #endregion User Role Management
    }
}
