using System;
using System.Collections.Generic;
using System.Text;

namespace TiLi.Core.Interfaces.Domains.Entities
{
    public class UserEntity : BaseEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nick { get; set; }
        public string Password { get; set; }

    }
}
