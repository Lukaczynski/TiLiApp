using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiLi.Api.Presenters;
using TiLi.Core.Dto.UseCaseRequests;
using TiLi.Core.Interfaces.UseCases;
using TiLi.Core.Objects;

namespace TiLi.Api.Controllers
{

    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ICreateProjectUseCase _createProjectUseCase;
        private readonly BaseResponsePresenter _baseResponsePresenter;

        private readonly IGetProjectsUseCase _getProjectsUseCase;
        private readonly GetProjectsPresenter _getProjectsPresenter;

        public ProjectsController(
            ICreateProjectUseCase createProjectUseCase,
            BaseResponsePresenter projectPresenter,
            IGetProjectsUseCase getProjectsUseCase,
            GetProjectsPresenter getProjectsPresenter
            )
        {
            _createProjectUseCase = createProjectUseCase;
            _baseResponsePresenter = projectPresenter;
            _getProjectsUseCase = getProjectsUseCase;
            _getProjectsPresenter = getProjectsPresenter;
        }

        
        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery]Pagination pagination)
        {
            await _getProjectsUseCase.Handle(new GetProjectsRequest(pagination),_getProjectsPresenter);
            return _getProjectsPresenter.ContentResult;
        }
        /*
        // GET: api/Projects/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult> Get(int id)
        {
            return "value";
        }*/

        // POST: api/Projects
        //[AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Models.Request.CreateProjectRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _createProjectUseCase.Handle(new CreateProjectRequest(request.Name, request.Description), _baseResponsePresenter);
            return _baseResponsePresenter.ContentResult;
        }
        /*
        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
        }*/
    }
}
