using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository _repository;

        public UserDomainService(IUserRepository repository)
        {
            _repository = repository;
        }

        public bool IsEmailExist(string email)
        {
            return _repository.Exists(i => i.Email == email);
        }

        public bool IsPhoneNumberExist(string phoneNumber)
        {
            return _repository.Exists(i => i.PhoneNumber == phoneNumber);
        }
    }
}
