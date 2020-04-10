using System;
using System.Collections.Generic;
using System.Text;
using TiLi.Core.Domain.Entities;
using TiLi.Core.Interfaces;

namespace TiLi.Core.Dto.UseCaseResponses
{
    public class GetUserResponse : UseCaseResponseMessage
    {
        public User User { get; }
        public IEnumerable<string> Errors { get; }

        public GetUserResponse(IEnumerable<string> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public GetUserResponse(User user, bool success = false, string message = null) : base(success, message)
        {
            this.User = user;
        }
    }
}
