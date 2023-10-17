﻿using Dapper;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.OrderAgg;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders
{
    internal static class OrderMapper
    {
        public static OrderDto Map(this Order order)
        {
            return new OrderDto()
            {
                CreationDate = order.CreationDate,
                Id = order.Id,
                OrderStatus = order.Status,
                OrderAddress = order.Address,
                OrderDiscount = order.Discount,
                Items = new(),
                LastUpdate = order.LastUpdate,
                ShippingMethod = order.ShippingMethod,
                UserFullName = "",
                UserId = order.UserId,
            };
        }

        public static async Task<List<OrderItemDto>> GetOrderItems(this OrderDto orderDto, DapperContext dapperContext)
        {
            var model = new List<OrderItemDto>();
            using var connection = dapperContext.CreateConnection;
            var sql = @$"SELECT s.ShopName, o.OrderId, o.InventoryId, o.Count, o.Price,
                p.Title as ProductTitle, p.Slug as ProductSlug, p.ImageName as ProductImageName
                FROM {dapperContext.OrderItems} o
                Inner Join {dapperContext.Inventories} i on o.InventoryId=i.Id
                Inner Join {dapperContext.Products} p on i.ProductId=p.Id
                Inner Join {dapperContext.Sellers} s on i.SellerId=s.Id
                Where o.OrderId=@orderId ";
            var result = await connection.QueryAsync<OrderItemDto>(sql, new { orderId = orderDto.Id });
            return result.ToList();
        }

        public static OrderFilterData MapFilterData(this Order order, ShopContext context)
        {
            var userFullName = context.Users
                .Where(i => i.Id == order.UserId)
                .Select(i => $"{i.Name} {i.Family}")
                .First();
            return new OrderFilterData()
            {
                OrderStatus = order.Status,
                Id = order.Id,
                CreationDate = order.CreationDate,
                City = order.Address?.City,
                ShippingType = order.ShippingMethod?.ShippingType,
                Province = order.Address?.Province,
                TotalItemCount = order.ItemCount,
                TotalPrice = order.TotalPrice,
                UserFullName = userFullName,
                UserId = order.UserId,
            };
        }
    }
}
