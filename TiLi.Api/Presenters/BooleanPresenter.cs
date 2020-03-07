using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiLi.Core.Dto.UseCaseResponses;
using TiLi.Core.Interfaces;

namespace TiLi.Api.Presenters
{
    public class BooleanPresenter : IOutputPort<BooleanResponse>
    {
        public bool BoolenResult { get; set; }

        public BooleanPresenter()
        {
            BoolenResult = false;
        }

        public void Handle(BooleanResponse response)
        {
            BoolenResult = response.Success;
        }
    }
}
