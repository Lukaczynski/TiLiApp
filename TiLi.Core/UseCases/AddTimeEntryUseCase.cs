using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiLi.Core.Domain.Entities;
using TiLi.Core.Dto;
using TiLi.Core.Dto.GatewayResponses;
using TiLi.Core.Dto.UseCaseRequests;
using TiLi.Core.Dto.UseCaseResponses;
using TiLi.Core.Interfaces;
using TiLi.Core.Interfaces.Gateways.Repositories;
using TiLi.Core.Interfaces.UseCases;

namespace TiLi.Core.UseCases
{
    public class AddTimeEntryUseCase : IAddTimeEntryUseCase
    {
        private readonly ITimeEntryRepository _timeEntryRepository;
        public AddTimeEntryUseCase(ITimeEntryRepository timeEntryRepository)
        {
            _timeEntryRepository = timeEntryRepository;
        }
        public async Task<bool> Handle(AddTimeEntryRequest message, IOutputPort<BaseResponse> outputPort)
        {
            CreateBaseResponseDTO response = await _timeEntryRepository.Create(
                new TimeEntry(message.Start,message.End,message.Comment)
                );
           
            outputPort.Handle(response.Success? new BaseResponse(response.Id,response.Success):
                new BaseResponse(new[] {new Error("ERRor1","yep")})
                );
            return response.Success;
        }
    }
}
