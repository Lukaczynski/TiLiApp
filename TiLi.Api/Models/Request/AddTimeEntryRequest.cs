using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiLi.Api.Models.Request
{
    public class AddTimeEntryRequest
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Comment { get; set; }
    }
}
