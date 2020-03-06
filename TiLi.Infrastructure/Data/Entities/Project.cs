using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TiLi.Infrastructure.Data.EntityFramework.Entities;

namespace TiLi.Infrastructure.Data.Entities
{
    public class Project : BaseEntity
    {
        public Project() : base()
        {
            this.AppUserProject = new HashSet<AppUserProject>();
        }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AppUserProject> AppUserProject { get; set; }
    }
}
