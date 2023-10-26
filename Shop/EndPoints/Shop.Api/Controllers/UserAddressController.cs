using AutoMapper;
using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModels.Users;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.DeleteAddress;
using Shop.Application.Users.EditAddress;
using Shop.Presentation.facade.Users.Addresses;
using Shop.Query.Users.DTOs;

namespace Shop.Api.Controllers
{
    [Authorize]
    public class UserAddressController : ApiController
    {
        private readonly IUserAddressFacade _userAddressFacade;
        private readonly IMapper _mapper;

        public UserAddressController(IUserAddressFacade userAddressFacade, IMapper mapper)
        {
            _userAddressFacade = userAddressFacade;
            _mapper = mapper;
        }

        [HttpGet("{userAddressId}")]
        public async Task<ApiResult<AddressDto?>> GetUserAddressById(long userAddressId)
        {
            return QueryResult(await _userAddressFacade.GetById(userAddressId));
        }

        [HttpGet]
        public async Task<ApiResult<List<AddressDto>>> GetUserAddressList()
        {
            return QueryResult(await _userAddressFacade.GetList(User.GetUserId()));
        }

        [HttpPost("addAddress")]
        public async Task<ApiResult> AddUserAddress(AddUserAddressViewModel viewModel)
        {
            var command = _mapper.Map<AddAddressUserCommand>(viewModel);
            command.UserId = User.GetUserId();
            return CommandResult(await _userAddressFacade.AddAddress(command));
        }

        [HttpPut("editAddress")]
        public async Task<ApiResult> EditUserAddress(EditUserAddressViewModel viewModel)
        {
            var command = _mapper.Map<EditAddressUserCommand>(viewModel);
            command.UserId = User.GetUserId();
            return CommandResult(await _userAddressFacade.EditAddress(command));
        }

        [HttpDelete("deleteAddress/{addressId}")]
        public async Task<ApiResult> DeleteUserAddress(long addressId)
        {
            // this id is just for test
            var userId = 1;
            return CommandResult(await _userAddressFacade.DeleteAddress(new DeleteAddressUserCommand(userId, addressId)));
        }
    }
}
