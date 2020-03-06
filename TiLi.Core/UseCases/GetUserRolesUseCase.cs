using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiLi.Core.Dto.UseCaseRequests;
using TiLi.Core.Dto.UseCaseResponses;
using TiLi.Core.Interfaces;
using TiLi.Core.Interfaces.Gateways.Repositories;
using TiLi.Core.Interfaces.UseCases;

namespace TiLi.Core.UseCases
{
 
     public sealed class GetUserRolesUseCase : IGetUserRoleUseCase
    {

        private readonly IUserRepository _userRepository;

        public GetUserRolesUseCase(IUserRepository projectRepository)
        {
            _userRepository = projectRepository;
        }

       

        

        public async Task<bool> Handle(GetUserRoleRequest message, IOutputPort<GetUserRolesResponse> outputPort)
        {

            var response = await _userRepository.GetRoles(message.UserId,message.Pagination);
            outputPort.Handle( new GetUserRolesResponse(message.UserId, response, true));
            return true;
        }
    }
}
