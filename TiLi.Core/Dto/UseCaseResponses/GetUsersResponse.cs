using System;
using System.Collections.Generic;
using System.Text;
using TiLi.Core.Domain.Entities;
using TiLi.Core.Interfaces;

namespace TiLi.Core.Dto.UseCaseResponses
{
    public class GetUsersResponse : UseCaseResponseMessage
    {
        public IEnumerable<User> Users { get; }
        public IEnumerable<string> Errors { get; }

        public GetUsersResponse(IEnumerable<string> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public GetUsersResponse(IEnumerable<User> users, bool success = false, string message = null) : base(success, message)
        {
            Users = users;
        }
    }
}
