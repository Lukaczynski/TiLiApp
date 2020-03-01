using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiLi.Core.Domain.Entities;
using TiLi.Core.Dto;
using TiLi.Core.Dto.GatewayResponses;
using TiLi.Core.Interfaces.Gateways.Repositories;
using TiLi.Infrastructure.Data.Entities;

namespace TiLi.Infrastructure.Data.EntityFramework.Repositories
{
    internal sealed class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;

        public RoleRepository(RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<CreateBaseResponseDTO> Create(Role role)
        {
            var appRole = _mapper.Map<AppRole>(role);
            var identityResult = await _roleManager.CreateAsync(appRole);

            return new CreateBaseResponseDTO(appRole.Id, identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));

        }

        public Task<IEnumerable<Role>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Role> Update(Role rol, string rolId)
        {
            throw new NotImplementedException();
        }
    }
}
