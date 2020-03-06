using System;
using System.Collections.Generic;
using System.Text;

namespace TiLi.Core.Domain.Entities
{
    public class Project
    {
        public Project(string name, string description="", int? id = null)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public int? Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
