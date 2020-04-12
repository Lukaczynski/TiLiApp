using System;
using System.Collections.Generic;
using System.Text;

namespace TiLi.Core.Objects
{
    public class Pagination
    {
        public Pagination()
        {
            Limit =  50;
            Pege = 1;
        }
        public Pagination(int? limit, int? pege)
        {
            Limit = limit??50;
            Pege = pege??1;
        }

        public int Limit { get; }
        public int Pege { get; }

    }
}
