using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiLi.Api.Models.Request;
using TiLi.Api.Presenters;
using TiLi.Core.Interfaces.UseCases;

namespace TiLi.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly ICreateRoleUseCase _createRoleUseCase;
        private readonly BaseResponsePresenter _baseRolePresenter;

        public RoleController(ICreateRoleUseCase createRoleUseCase, BaseResponsePresenter rolePresenter)
        {
            _createRoleUseCase = createRoleUseCase;
            _baseRolePresenter = rolePresenter;
        }

        // GET: api/Role
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //// GET: api/Role/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Role
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateRoleRequest role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _createRoleUseCase.Handle(new Core.Dto.UseCaseRequests.CreateRoleRequest(role.Name), _baseRolePresenter);
            return _baseRolePresenter.ContentResult;
        }
        
        //// PUT: api/Role/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
