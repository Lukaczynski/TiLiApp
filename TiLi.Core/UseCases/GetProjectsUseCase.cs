using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiLi.Core.Domain.Entities;
using TiLi.Core.Dto.UseCaseRequests;
using TiLi.Core.Dto.UseCaseResponses;
using TiLi.Core.Interfaces;
using TiLi.Core.Interfaces.Gateways.Repositories;
using TiLi.Core.Interfaces.UseCases;

namespace TiLi.Core.UseCases
{
    public class GetProjectsUseCase : IGetProjectsUseCase
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectsUseCase(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<bool> Handle(GetProjectsRequest message, IOutputPort<GetProjectsResponse> outputPort)
        {
            IEnumerable<Project> response = await _projectRepository.GetAll(
                message.Pagination
                );
            var d = response.ToList();
            outputPort.Handle(new GetProjectsResponse(response, true));
            return true;
        }
    }
}
