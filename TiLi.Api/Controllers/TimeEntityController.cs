using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiLi.Api.Presenters;
using TiLi.Core.Dto.UseCaseRequests;
using TiLi.Core.Interfaces.UseCases;

namespace TiLi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeEntityController : ControllerBase
    {
        private readonly IAddTimeEntryUseCase _addTimeEntryUseCase;
        private readonly BaseResponsePresenter _baseResponsePresenter;

        public TimeEntityController(IAddTimeEntryUseCase addTimeEntryUseCase, BaseResponsePresenter baseResponsePresenter)
        {
            _addTimeEntryUseCase = addTimeEntryUseCase;
            _baseResponsePresenter = baseResponsePresenter;
        }

        // POST: api/TimeEntity
        [HttpPost]
        public async Task<ActionResult> AddTimeEntity([FromBody]Models.Request.AddTimeEntryRequest entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  
            }

            await _addTimeEntryUseCase.Handle(new AddTimeEntryRequest(entity.Start, entity.End, entity.Comment), _baseResponsePresenter);
            return _baseResponsePresenter.ContentResult;
        }
    }
}