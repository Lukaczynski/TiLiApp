using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiLi.Core.Domain.Entities;
using TiLi.Core.Dto;
using TiLi.Core.Dto.UseCaseRequests;
using TiLi.Core.Dto.UseCaseResponses;
using TiLi.Core.Interfaces;
using TiLi.Core.Interfaces.Gateways.Repositories;
using TiLi.Core.Interfaces.UseCases;

namespace TiLi.Core.UseCases
{
    public class GetUserUseCase : IGetUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public GetUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(GetUserRequest message, IOutputPort<GetUserResponse> outputPort)
        {
            User response = await _userRepository.FindById(message.UserId);
            if (response!=null)
            {
                outputPort.Handle(new GetUserResponse(response, true));
            }
            outputPort.Handle(new GetUserResponse(new[] { new Error("login_failure", "Invalid username or password.") }));
            return false;
        }
    }
}
