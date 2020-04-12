using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiLi.Core.Domain.Entities;
using TiLi.Core.Dto.GatewayResponses;
using TiLi.Core.Dto.GatewayResponses.Repositories;
using TiLi.Core.Interfaces.Gateways.Repositories;
using TiLi.Core.Objects;

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

       
        /// <summary>
        /// Fin Project by ther name in the database.
        /// Is not necesary to provide a user id.
        /// </summary>
        /// <see cref="Project"/>
        /// <param name="projectName">The name of project</param>
        /// <returns>An project with provided name.</returns>
        public Task<Project> FindByName(string projectName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Project>> GetAll(Pagination pagination)
        {
            return await Task.Run(() =>
            {
                return _dbContext.Projects.Select(x => _mapper.Map<Project>(x));
            });
        }

       
    }
}
