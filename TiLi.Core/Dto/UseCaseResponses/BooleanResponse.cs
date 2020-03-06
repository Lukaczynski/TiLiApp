using System;
using System.Collections.Generic;
using System.Text;
using TiLi.Core.Interfaces;

namespace TiLi.Core.Dto.UseCaseResponses
{
    public class BooleanResponse : UseCaseResponseMessage
    {
        public IEnumerable<string> Errors { get; }

        public BooleanResponse(IEnumerable<string> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public BooleanResponse(bool success = false, string message = null) : base(success, message)
        {
        }
    }
}
