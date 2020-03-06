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
    public sealed class CreateProjectUseCase : ICreateProjectUseCase
    {

        private readonly IProjectRepository _projectRepository;

        public CreateProjectUseCase(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<bool> Handle(CreateProjectRequest message, IOutputPort<BaseResponse> outputPort)
        {
            var response = await _projectRepository.Create(new Project(message.Name,message.Description));
            outputPort.Handle(response.Success ? new BaseResponse(response.Id, true) : new BaseResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
            
        }
    }
}
