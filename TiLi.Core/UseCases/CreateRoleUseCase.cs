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
    public sealed class CreateRoleUseCase : ICreateRoleUseCase
    {
        private readonly IRoleRepository _rolRepository;

        public CreateRoleUseCase(IRoleRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        public async Task<bool> Handle(CreateRoleRequest message, IOutputPort<BaseResponse> outputPort)
        {
            var response = await _rolRepository.Create(new Role(message.Name));
            outputPort.Handle(response.Success ? new BaseResponse(response.Id, true) : new BaseResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }
    }
}
