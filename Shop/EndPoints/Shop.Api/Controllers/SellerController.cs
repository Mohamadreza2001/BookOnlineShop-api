﻿using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Application.Sellers.AddInventory;
using Shop.Application.Sellers.Create;
using Shop.Application.Sellers.Edit;
using Shop.Application.Sellers.EditInventory;
using Shop.Domain.RoleAgg.Enums;
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

        [PermissionChecker(Permission.Seller_Management)]
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

        [Authorize]
        [HttpGet("current")]
        public async Task<ApiResult<SellerDto?>> GetSeller()
        {
            return QueryResult(await _sellerFacade.GetSellerByUserId(User.GetUserId()));
        }

        [PermissionChecker(Permission.Add_Inventory)]
        [HttpPost("addInventory")]
        public async Task<ApiResult> AddSellerInventory(AddSellerInventoryCommand command)
        {
            return CommandResult(await _sellerInventoryFacade.AddInventory(command));
        }

        [PermissionChecker(Permission.Seller_Management)]
        [HttpPost]
        public async Task<ApiResult> CreateSeller(CreateSellerCommand command)
        {
            return CommandResult(await _sellerFacade.Create(command));
        }

        [PermissionChecker(Permission.Edit_Inventory)]
        [HttpPut]
        public async Task<ApiResult> EditSeller(EditSellerCommand command)
        {
            return CommandResult(await _sellerFacade.Edit(command));
        }

        [PermissionChecker(Permission.Edit_Inventory)]
        [HttpPut("editInventory")]
        public async Task<ApiResult> EditSellerInventory(EditSellerInventoryCommand command)
        {
            return CommandResult(await _sellerInventoryFacade.EditInventory(command));
        }

        [HttpGet("inventories")]
        [PermissionChecker(Permission.Seller_Panel)]
        public async Task<ApiResult<List<InventoryDto>>> GetInventories()
        {
            var seller = await _sellerFacade.GetSellerByUserId(User.GetUserId());
            if (seller == null)
                return QueryResult(new List<InventoryDto>());

            var result = await _sellerInventoryFacade.GetList(seller.Id);
            return QueryResult(result);
        }

        [HttpGet("inventories/{inventoryId}")]
        [PermissionChecker(Permission.Seller_Panel)]
        public async Task<ApiResult<InventoryDto>> GetInventories(long inventoryId)
        {
            var seller = await _sellerFacade.GetSellerByUserId(User.GetUserId());
            if (seller == null)
                return QueryResult(new InventoryDto());

            var result = await _sellerInventoryFacade.GetById(inventoryId);
            if (result == null || result.SellerId != seller.Id)
                return QueryResult(new InventoryDto());

            return QueryResult(result);
        }
    }
}
