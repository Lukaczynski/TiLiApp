using TiLi.Core.Dto.UseCaseRequests;
using TiLi.Core.Dto.UseCaseResponses;

namespace TiLi.Core.Interfaces.UseCases
{
    public interface IRegisterUserUseCase : IUseCaseRequestHandler<RegisterUserRequest, RegisterUserResponse>
    {
    }
}
