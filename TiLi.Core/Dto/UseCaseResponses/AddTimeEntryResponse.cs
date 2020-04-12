using System;
using System.Collections.Generic;
using System.Text;
using TiLi.Core.Domain.Entities;
using TiLi.Core.Interfaces;

namespace TiLi.Core.Dto.UseCaseResponses
{
    public class AddTimeEntryResponse : UseCaseResponseMessage
    {
        public TimeEntry TimeEntry { get; }
        public IEnumerable<Error> Errors { get; }

        public AddTimeEntryResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public AddTimeEntryResponse(TimeEntry timeEntrys, bool success = false, string message = null) : base(success, message)
        {
            this.TimeEntry = timeEntrys;
        }
    }
}
