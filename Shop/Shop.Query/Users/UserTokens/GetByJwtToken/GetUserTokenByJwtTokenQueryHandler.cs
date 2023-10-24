using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.UserTokens.GetByJwtToken
{
    internal class GetUserTokenByJwtTokenQueryHandler : IQueryHandler<GetUserTokenByJwtTokenQuery, UserTokenDto?>
    {
        private readonly DapperContext _dapperContext;

        public GetUserTokenByJwtTokenQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<UserTokenDto?> Handle(GetUserTokenByJwtTokenQuery request, CancellationToken cancellationToken)
        {
            using var connection = _dapperContext.CreateConnection;
            var sql = $"select top(1) * from {_dapperContext.UserTokens} where HashJwtToken=@hashJwtToken";
            return await connection.QueryFirstOrDefaultAsync<UserTokenDto>(sql, new { hashJstToken = request.HashJwtToken });
        }
    }
}
