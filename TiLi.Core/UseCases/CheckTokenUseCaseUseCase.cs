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
    public class CheckTokenUseCaseUseCase : ICheckTokenUseCaseUseCase
    {
        private readonly ITokenRepository _tokenRepository;

        public CheckTokenUseCaseUseCase(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }
        public async Task<bool> Handle(CheckTokenUseCaseRequest message, IOutputPort<CheckTokenUseCaseResponse> outputPort)
        {
            IEnumerable<Role> response = await _tokenRepository.CheckTokenUseCase(message.Pagination);
            var d = response.ToList();
            outputPort.Handle(new CheckTokenUseCaseResponse(response, true));
            return true;
        }
    }
}
