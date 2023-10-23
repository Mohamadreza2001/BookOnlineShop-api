using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.UserAgg
{
    public class UserToken : BaseEntity
    {
        public UserToken(string hashedJwtToken, string hashedRefreshToken, DateTime tokenExpireDate,
            DateTime refreshTokenExpireDate, string device)
        {
            HashedJwtToken = hashedJwtToken;
            HashedRefreshToken = hashedRefreshToken;
            TokenExpireDate = tokenExpireDate;
            RefreshTokenExpireDate = refreshTokenExpireDate;
            Device = device;
        }

        public long UserId { get; internal set; }
        public string HashedJwtToken { get; private set; }
        public string HashedRefreshToken { get; private set; }
        public DateTime TokenExpireDate { get; private set; }
        public DateTime RefreshTokenExpireDate { get; private set; }
        public string Device { get; set; }

        public void Guard()
        {
            NullOrEmptyDomainDataException.CheckString(HashedJwtToken, nameof(HashedJwtToken));
            NullOrEmptyDomainDataException.CheckString(HashedRefreshToken, nameof(HashedRefreshToken));

            if (TokenExpireDate < DateTime.Now)
                throw new InvalidDomainDataException("Invalid Token ExpireDate");

            if (RefreshTokenExpireDate < TokenExpireDate)
                throw new InvalidDomainDataException("Invalid RefreshToken ExpireDate");
        }
    }
}
