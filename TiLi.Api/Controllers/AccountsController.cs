using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TiLi.Core.Dto.UseCaseRequests;
using TiLi.Core.Interfaces.UseCases;
using TiLi.Api.Presenters;
using System;
using TiLi.Core.Dto;
using TiLi.Core.Objects;
using Microsoft.AspNetCore.Authorization;

namespace TiLi.Api.Controllers
{
    [AuthorizePermissions(Permissions ="api_access")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IRegisterUserUseCase _registerUserUseCase;
        private readonly BaseResponsePresenter _baseResponsePresenter;

        private readonly IGetUserRoleUseCase _getUserRoleUseCase;
        private readonly GetUserRolesPresenter _rolePresenter;

        private readonly IGetUsersUseCase _getUsersUseCase;
        private readonly GetUsersPresenter _getUsersPresenter;

        private readonly IAddRoleToUserUseCase _addRoleToUserUseCase;

        public AccountsController(
            IRegisterUserUseCase registerUserUseCase,
            BaseResponsePresenter registerUserPresenter,
            IGetUserRoleUseCase getUserRoleUseCase,
            GetUserRolesPresenter rolePresenter,
            IGetUsersUseCase getUsersUseCase,
            GetUsersPresenter getUsersPresenter,
            IAddRoleToUserUseCase addRoleToUserUseCase

            )
        {
            _registerUserUseCase = registerUserUseCase;
            _baseResponsePresenter = registerUserPresenter;

            _getUserRoleUseCase = getUserRoleUseCase;
            _rolePresenter = rolePresenter;

            _getUsersUseCase = getUsersUseCase;
            _getUsersPresenter = getUsersPresenter;
            _addRoleToUserUseCase = addRoleToUserUseCase;
        }

        // POST api/accounts
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Models.Request.RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _registerUserUseCase.Handle(new RegisterUserRequest(request.FirstName, request.LastName, request.Email,
                request.UserName, request.Password), _baseResponsePresenter);
            return _baseResponsePresenter.ContentResult;
        }


        //GET api/accounts/
        [HttpGet]
        public async Task<ActionResult> GetUsers([FromQuery] int? limit = null, [FromQuery] int? page = null)
        {

            Pagination pagination = null;
            if (limit != null || page != null)
            {
                pagination = new Pagination(limit, page);
            }
            await _getUsersUseCase.Handle(new GetUsersRequest(pagination), _getUsersPresenter);
            return _getUsersPresenter.ContentResult;
        }

        //GET api/accounts/{userId}/Role
        [Route("{userId}/Role")]
        [HttpGet]
      
        public async Task<ActionResult> GetUserRoles([FromRoute] string userId, [FromQuery] int? limit = null, [FromQuery] int? page = null)
        {
           
            if (String.IsNullOrEmpty(userId))
            {
                ModelState.AddModelError("userId", "Cannot be null or empty.");
                return BadRequest(ModelState);
            }
            Pagination pagination = null;
            if (limit != null || page != null)
            {
                pagination = new Pagination(limit, page);
            }
            await _getUserRoleUseCase.Handle(new GetUserRoleRequest(userId, pagination), _rolePresenter);
            return _rolePresenter.ContentResult;
        }

        //POST api/accounts/{userId}/Role
        [Route("{userId}/Role")]
        [HttpPost]
        public async Task<ActionResult> PostRoleToUser([FromRoute] string userId, [FromBody] Models.Request.AddRoleToUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (String.IsNullOrEmpty(userId))
            {
                ModelState.AddModelError("userId", "Cannot be null or empty.");
                return BadRequest(ModelState);
            }
            await _addRoleToUserUseCase.Handle(new AddRoleToUserRequest(userId, request.IdRole), _baseResponsePresenter);
            return _baseResponsePresenter.ContentResult;
        }
    }
}

