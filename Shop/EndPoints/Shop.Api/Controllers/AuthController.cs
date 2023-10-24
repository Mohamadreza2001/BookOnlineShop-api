using Common.Application;
using Common.Application.SecurityUtil;
using Common.AspNetCore;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.JwtUtility;
using Shop.Api.ViewModels;
using Shop.Api.ViewModels.Auth;
using Shop.Application.Users.AddToken;
using Shop.Application.Users.Register;
using Shop.Application.Users.RemoveToken;
using Shop.Presentation.facade.Users;
using Shop.Query.Users.DTOs;
using UAParser;

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
        public async Task<ApiResult<LoginResultDto>> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid == false)
            {
                return new ApiResult<LoginResultDto>()
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
                return CommandResult(OperationResult<LoginResultDto>.Error("Phonenumber does not exist"));
            }

            if (Sha256Hasher.IsCompare(user.Password, loginViewModel.Password) == false)
            {
                return CommandResult(OperationResult<LoginResultDto>.Error("Password is not correct"));
            }

            if (user.IsActive == false)
            {
                return CommandResult(OperationResult<LoginResultDto>.Error("Your account is not active"));
            }

            var loginResult = await AddTokenAndGenerateJwt(user);
            return CommandResult(loginResult);
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

        [HttpPost("refreshToken")]
        public async Task<ApiResult<LoginResultDto?>> RefreshToken(string refreshToken)
        {
            var result = await _userFacade.GetUserTokenByRefreshToken(refreshToken);

            if (result == null)
                return CommandResult(OperationResult<LoginResultDto?>.NotFound());

            if (result.TokenExpireDate > DateTime.Now)
            {
                return CommandResult(OperationResult<LoginResultDto?>.Error("Token is already valid"));
            }

            if (result.TokenExpireDate < DateTime.Now)
            {
                return CommandResult(OperationResult<LoginResultDto?>.Error("Refresh token time is expired"));
            }

            var user = await _userFacade.GetById(result.UserId);
            await _userFacade.RemoveToken(new RemoveTokenUserCommand(result.UserId, result.Id));
            var loginResult = await AddTokenAndGenerateJwt(user);
            return CommandResult(loginResult);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<ApiResult> Logout()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var result = await _userFacade.GetUserTokenByJwtToken(token);

            if (result == null)
                return CommandResult(OperationResult.NotFound());

            await _userFacade.RemoveToken(new RemoveTokenUserCommand(result.UserId, result.Id));
            return CommandResult(OperationResult.Success());
        }

        private async Task<OperationResult<LoginResultDto>> AddTokenAndGenerateJwt(UserDto user)
        {
            var uaParser = Parser.GetDefault();
            var info = uaParser.Parse(HttpContext.Request.Headers["user-agent"]);
            var device = $"{info.Device.Family}/{info.OS.Family}/{info.OS.Major}.{info.OS.Minor} - {info.UA.Family}";

            var token = JwtTokenBuilder.BuildToken(user, _configuration);
            var refreshToken = Guid.NewGuid().ToString();
            var hashedJwtToken = Sha256Hasher.Hash(token);
            var hashedJwtRefreshToken = Sha256Hasher.Hash(refreshToken);
            var tokenResult = await _userFacade.AddToken(new AddTokenUserCommand(user.Id, hashedJwtToken, hashedJwtRefreshToken,
                DateTime.Now.AddDays(7), DateTime.Now.AddDays(8), device));

            if (tokenResult.Status != OperationResultStatus.Success)
                return OperationResult<LoginResultDto>.Error();

            return OperationResult<LoginResultDto>.Success(new LoginResultDto()
            {
                Token = token,
                RefreshToken = refreshToken,
            });
        }
    }
}
