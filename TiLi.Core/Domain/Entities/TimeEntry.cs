using System;
using System.Collections.Generic;
using System.Text;

namespace TiLi.Core.Domain.Entities
{
    public class TimeEntry
    {
        public int? Id { get; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Comment { get; set; }

        public TimeEntry(DateTime start, DateTime end, string comment="", int? id=null )
        {
            Id = id;
            Start = start;
            End = end;
            Comment = comment;
        }
    }
}
