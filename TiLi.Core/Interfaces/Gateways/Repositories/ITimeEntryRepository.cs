using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiLi.Core.Domain.Entities;
using TiLi.Core.Dto.GatewayResponses;
using TiLi.Core.Objects;

namespace TiLi.Core.Interfaces.Gateways.Repositories
{
    public interface ITimeEntryRepository
    {

        Task<CreateBaseResponseDTO> Create(TimeEntry timeEntry);
        Task<TimeEntry> FindById(int timeEntryId);
        Task<IEnumerable<TimeEntry>> GetAll(Pagination pagination);
    }
}
