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
    public class GetUsersUseCase : IGetUsersUseCase
    {
        private readonly IUserRepository _userRepository;

        public GetUsersUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(GetUsersRequest message, IOutputPort<GetUsersResponse> outputPort)
        {
            IEnumerable<User> response = await _userRepository.GetUsers(message.Pagination);
            var d = response.ToList();
            outputPort.Handle(new GetUsersResponse(response, true));
            return true;
        }
    }
}
