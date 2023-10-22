using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Users.ChargeWallet;
using Shop.Application.Users.Create;
using Shop.Application.Users.Edit;
using Shop.Application.Users.Register;
using Shop.Presentation.facade.Users;
using Shop.Query.Users.DTOs;

namespace Shop.Api.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserFacade _userFacade;

        public UserController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [HttpGet]
        public async Task<ApiResult<UserFilterResult>> GetUserByFilter(UserFilterParams filterParams)
        {
            return QueryResult(await _userFacade.GetByFilter(filterParams));
        }

        [HttpGet("{userId}")]
        public async Task<ApiResult<UserDto?>> GetUserById(long userId)
        {
            return QueryResult(await _userFacade.GetById(userId));
        }

        [HttpGet("phoneNumber")]
        public async Task<ApiResult<UserDto?>> GetUserByPhoneNumber(string phoneNumber)
        {
            return QueryResult(await _userFacade.GetByPhoneNumber(phoneNumber));
        }

        [HttpPost]
        public async Task<ApiResult> CreateUser(CreateUserCommand command)
        {
            return CommandResult(await _userFacade.Create(command));
        }

        [HttpPut]
        public async Task<ApiResult> EditUser(EditUserCommand command)
        {
            return CommandResult(await _userFacade.Edit(command));
        }

        [HttpPost("chargeWallet")]
        public async Task<ApiResult> ChargeUserWallet(ChargeWalletUserCommand command)
        {
            return CommandResult(await _userFacade.ChargeWallet(command));
        }

        [HttpPost("register")]
        public async Task<ApiResult> RegisterUser(RegisterUserCommand command)
        {
            return CommandResult(await _userFacade.Register(command));
        }
    }
}
