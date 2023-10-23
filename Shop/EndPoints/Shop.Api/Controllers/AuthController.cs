using Common.Application;
using Common.Application.SecurityUtil;
using Common.AspNetCore;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.JwtUtility;
using Shop.Api.ViewModels.Auth;
using Shop.Application.Users.Register;
using Shop.Presentation.facade.Users;

namespace Shop.Api.Controllers
{
    public class AuthController : ApiController
    {
        private readonly IUserFacade _userFacade;
        private readonly IConfiguration _configuration;
        public AuthController(IUserFacade userFacade, IConfiguration configuration)
        {
            _userFacade = userFacade;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<ApiResult<string>> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid == false)
            {
                return new ApiResult<string>()
                {
                    Data = null,
                    IsSuccess = false,
                    MetaData = new()
                    {

                        AppStatusCode = AppStatusCode.BadRequest,
                        Message = JoinErrors(),
                    },
                };
            }
            var user = await _userFacade.GetByPhoneNumber(loginViewModel.PhoneNumber);
            if (user == null)
            {
                return CommandResult(OperationResult<string>.Error("Phonenumber does not exist"));
            }

            if (Sha256Hasher.IsCompare(user.Password, loginViewModel.Password) == false)
            {
                return CommandResult(OperationResult<string>.Error("Password is not correct"));
            }

            if (user.IsActive == false)
            {
                return CommandResult(OperationResult<string>.Error("Your account is not active"));
            }
            var token = JwtTokenBuilder.BuildToken(user, _configuration);
            return new ApiResult<string>()
            {
                Data = token,
                IsSuccess = true,
                MetaData = new(),
            };
        }

        [HttpPost("register")]
        public async Task<ApiResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid == false)
            {
                return new ApiResult()
                {
                    IsSuccess = false,
                    MetaData = new()
                    {

                        AppStatusCode = AppStatusCode.BadRequest,
                        Message = JoinErrors(),
                    },
                };
            }
            var command = new RegisterUserCommand(new PhoneNumber(registerViewModel.PhoneNumber), registerViewModel.Password);
            return CommandResult(await _userFacade.Register(command));
        }
    }
}
