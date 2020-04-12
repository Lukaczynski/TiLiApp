using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiLi.Core.Domain.Entities;
using TiLi.Core.Dto.GatewayResponses;
using TiLi.Core.Interfaces.Gateways.Repositories;
using TiLi.Core.Objects;

namespace TiLi.Infrastructure.Data.EntityFramework.Repositories
{
    class TimeEntryRepository : ITimeEntryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public TimeEntryRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async  Task<CreateBaseResponseDTO> Create(TimeEntry timeEntry)
        {
            var appTimeEntry = _mapper.Map<Data.Entities.TimeEntry>(timeEntry);
            var resulr = await _dbContext.TimeEntries.AddAsync(appTimeEntry);
            var res = await _dbContext.SaveChangesAsync();
            return new CreateBaseResponseDTO(resulr.ToString(), res==1);
        }

        public Task<TimeEntry> FindById(int timeEntryId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TimeEntry>> GetAll(Pagination pagination)
        {
            return await Task.Run(() =>
            {
                return _dbContext.TimeEntries.Select(x => _mapper.Map<TimeEntry>(x));
            });
        }
    }
}
