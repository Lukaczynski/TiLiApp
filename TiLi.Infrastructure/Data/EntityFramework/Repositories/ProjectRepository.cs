using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiLi.Core.Domain.Entities;
using TiLi.Core.Dto.GatewayResponses;
using TiLi.Core.Dto.GatewayResponses.Repositories;
using TiLi.Core.Interfaces.Gateways.Repositories;

namespace TiLi.Infrastructure.Data.EntityFramework.Repositories
{
    internal sealed class ProjectRepository : IProjectRepository
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProjectRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CreateBaseResponseDTO> Create(Project project)
        {
            var appProject = _mapper.Map<Data.Entities.Project>(project);
            var result = await _dbContext.Projects.AddAsync(appProject);
            var proyectId = await _dbContext.SaveChangesAsync();
            return new CreateBaseResponseDTO(proyectId.ToString(), true, null );
        }

        public Task<User> FindByName(string projectName)
        {
            throw new NotImplementedException();
        }
    }
}
