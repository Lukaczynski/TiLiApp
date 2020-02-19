using System;
using System.Collections.Generic;
using System.Text;

namespace TiLi.Core.Interfaces.Domains.Entities
{
    public abstract class BaseEntity
    {
        public long Updated { get; set; }
        public long Created { get; set; }

    }
}
