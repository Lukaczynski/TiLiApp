using System;
using System.Collections.Generic;
using System.Text;
using TiLi.Infrastructure.Data.EntityFramework.Entities;

namespace TiLi.Infrastructure.Data.Entities
{
    public class AppUserProject
    {
        public string AppUserId { get; set; }
        public int ProjectId { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual Project Project { get; set; }
        public int AccesLevel { get; set; }
    }
}
