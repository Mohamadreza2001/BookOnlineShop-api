using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.UserAgg
{
    public class UserToken : BaseEntity
    {
        private UserToken() { }

        public UserToken(string hashedJwtToken, string hashedRefreshToken, DateTime tokenExpireDate,
            DateTime refreshTokenExpireDate, string device)
        {
            Guard(hashedJwtToken, hashedRefreshToken, tokenExpireDate, refreshTokenExpireDate, device);
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
        public string Device { get; private set; }

        public void Guard(string hashedJwtToken, string hashedRefreshToken, DateTime tokenExpireDate,
            DateTime refreshTokenExpireDate, string device)
        {
            NullOrEmptyDomainDataException.CheckString(hashedJwtToken, nameof(HashedJwtToken));
            NullOrEmptyDomainDataException.CheckString(hashedRefreshToken, nameof(HashedRefreshToken));

            if (tokenExpireDate < DateTime.Now)
                throw new InvalidDomainDataException("Invalid Token ExpireDate");

            if (refreshTokenExpireDate < TokenExpireDate)
                throw new InvalidDomainDataException("Invalid RefreshToken ExpireDate");
        }
    }
}
