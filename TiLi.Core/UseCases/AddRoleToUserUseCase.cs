using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiLi.Core.Domain.Entities;
using TiLi.Core.Dto.GatewayResponses;
using TiLi.Core.Dto.UseCaseRequests;
using TiLi.Core.Dto.UseCaseResponses;
using TiLi.Core.Interfaces;
using TiLi.Core.Interfaces.Gateways.Repositories;
using TiLi.Core.Interfaces.UseCases;

namespace TiLi.Core.UseCases
{
    public class AddRoleToUserUseCase : IAddRoleToUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public AddRoleToUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(AddRoleToUserRequest message, IOutputPort<BaseResponse> outputPort)
        {
            CreateBaseResponseDTO response = await _userRepository.AddRole(message.UserId,message.RoleId);
            outputPort.Handle(response.Success ? new BaseResponse(response.Id, true) : 
                new BaseResponse(response.Errors.Select(e => e.Description)));
        
            return response.Success;
        }
    }
}
