using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetById
{
    public record GetByIdOrderQuery(long OrderId) : IQuery<OrderDto?>;

    internal class GetByIdOrderQueryHandler : IQueryHandler<GetByIdOrderQuery, OrderDto?>
    {
        private readonly ShopContext _shopContext;
        private readonly DapperContext _dapperContext;

        public GetByIdOrderQueryHandler(ShopContext shopContext, DapperContext dapperContext)
        {
            _shopContext = shopContext;
            _dapperContext = dapperContext;
        }

        public async Task<OrderDto?> Handle(GetByIdOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _shopContext.Orders.FirstOrDefaultAsync(i => i.Id == request.OrderId, cancellationToken);
            if (order == null)
                return null;
            var orderDto = order.Map();
            orderDto.UserFullName = await _shopContext.Users.Where(i => i.Id == orderDto.UserId)
                .Select(i => $"{i.Name} {i.Family}")
                .FirstAsync(cancellationToken);
            orderDto.Items = await orderDto.GetOrderItems(_dapperContext);
            return orderDto;
        }
    }
}
