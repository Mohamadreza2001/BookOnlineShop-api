using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Sellers.AddInventory;
using Shop.Application.Sellers.Create;
using Shop.Application.Sellers.Edit;
using Shop.Application.Sellers.EditInventory;
using Shop.Presentation.facade.Sellers;
using Shop.Presentation.facade.Sellers.Inventories;
using Shop.Query.Sellers.DTOs;

namespace Shop.Api.Controllers
{
    public class SellerController : ApiController
    {
        private readonly ISellerFacade _sellerFacade;
        private readonly ISellerInventoryFacade _sellerInventoryFacade;

        public SellerController(ISellerFacade sellerFacade, ISellerInventoryFacade sellerInventoryFacade)
        {
            _sellerFacade = sellerFacade;
            _sellerInventoryFacade = sellerInventoryFacade;
        }

        [HttpGet]
        public async Task<ApiResult<SellerFilterResult>> GetSellerByFilter([FromQuery] SellerFilterParams filterParams)
        {
            return QueryResult(await _sellerFacade.GetByFilter(filterParams));
        }

        [HttpGet("{sellerId}")]
        public async Task<ApiResult<SellerDto?>> GetSellerById(long sellerId)
        {
            return QueryResult(await _sellerFacade.GetById(sellerId));
        }

        [HttpPost("addInventory")]
        public async Task<ApiResult> AddSellerInventory(AddSellerInventoryCommand command)
        {
            return CommandResult(await _sellerInventoryFacade.AddInventory(command));
        }

        [HttpPost]
        public async Task<ApiResult> CreateSeller(CreateSellerCommand command)
        {
            return CommandResult(await _sellerFacade.Create(command));
        }

        [HttpPut]
        public async Task<ApiResult> EditSeller(EditSellerCommand command)
        {
            return CommandResult(await _sellerFacade.Edit(command));
        }

        [HttpPut("editInventory")]
        public async Task<ApiResult> EditSellerInventory(EditSellerInventoryCommand command)
        {
            return CommandResult(await _sellerInventoryFacade.EditInventory(command));
        }
    }
}
