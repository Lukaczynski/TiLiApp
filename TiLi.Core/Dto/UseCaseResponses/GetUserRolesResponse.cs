using System;
using System.Collections.Generic;
using System.Text;
using TiLi.Core.Interfaces;

namespace TiLi.Core.Dto.UseCaseResponses
{
    public class GetUserRolesResponse : UseCaseResponseMessage
    {
        public string UserId { get; }
        public IEnumerable<string> Roles { get; }
        public IEnumerable<Error> Errors { get; }

        public GetUserRolesResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public GetUserRolesResponse(string userId, IEnumerable<string> roles, bool success = false, string message = null) : base(success, message)
        {
            UserId = userId;
            Roles = roles;
        }
    }
}
