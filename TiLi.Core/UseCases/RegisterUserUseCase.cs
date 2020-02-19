using System.Linq;
using System.Threading.Tasks;
using TiLi.Core.Domain.Entities;
using TiLi.Core.Dto.UseCaseRequests;
using TiLi.Core.Dto.UseCaseResponses;
using TiLi.Core.Interfaces;
using TiLi.Core.Interfaces.Gateways.Repositories;
using TiLi.Core.Interfaces.UseCases;

namespace TiLi.Core.UseCases
{
    public sealed class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(RegisterUserRequest message, IOutputPort<RegisterUserResponse> outputPort)
        {
            var response = await _userRepository.Create(new User(message.FirstName, message.LastName,message.Email, message.UserName), message.Password);
            outputPort.Handle(response.Success ? new RegisterUserResponse(response.Id, true) : new RegisterUserResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }
    }
}
