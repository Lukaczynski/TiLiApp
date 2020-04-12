using System;
using System.Collections.Generic;
using System.Text;
using TiLi.Core.Domain.Entities;
using TiLi.Core.Interfaces;

namespace TiLi.Core.Dto.UseCaseResponses
{
    public class BaseResponse : UseCaseResponseMessage
    {
        public String Id { get; }
        public IEnumerable<Error> Errors { get; }

        public BaseResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public BaseResponse(string id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
        }
    }
}
