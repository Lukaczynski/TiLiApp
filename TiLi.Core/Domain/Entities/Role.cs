using System;
using System.Collections.Generic;
using System.Text;

namespace TiLi.Core.Domain.Entities
{
    public class Role
    {
        public Role(string name, string normalizedName = null, string concurrencyStamp = null, string id = null)
        {
            Id = id;
            Name = name;
            NormalizedName = normalizedName;
            ConcurrencyStamp = concurrencyStamp;
        }

        public string Id { get; }
        public string Name { get; }
        public string NormalizedName { get; }
        public string ConcurrencyStamp { get; }

    }
}
