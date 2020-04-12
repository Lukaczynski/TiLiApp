using System;
using System.Collections.Generic;
using System.Text;
using TiLi.Core.Domain.Entities;
using TiLi.Core.Dto.UseCaseResponses;
using TiLi.Core.Interfaces;
using TiLi.Core.Objects;

namespace TiLi.Core.Dto.UseCaseRequests
{
    public class AddTimeEntryRequest : IUseCaseRequest<BaseResponse>
    {
       public DateTime Start { get; }
        public DateTime End { get; }
        public string Comment { get; }

        public AddTimeEntryRequest(DateTime start, DateTime end, string comment="")
        {
            Start = start;
            End = end;
            Comment = comment;
        }
    }
}
