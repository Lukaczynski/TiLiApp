using System;
using System.Collections.Generic;
using System.Text;

namespace TiLi.Core.Dto.Models
{
    public class UserDTO
    {
        public string Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string UserName { get; }

        internal UserDTO(string firstName, string lastName, string email, string userName, string id = null)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
        }
    }
}
