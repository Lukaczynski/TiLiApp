using System;
using System.Collections.Generic;
using System.Text;
using TiLi.Infrastructure.Data.EntityFramework.Entities;

namespace TiLi.Infrastructure.Data.Entities
{
    public class TimeEntry : BaseEntity
    {
        public TimeEntry() : base()
        {
        }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Comment { get; set; }
        public virtual Project Project {get; set;}

    }
}
