using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers
{
    public class SellerDomainService : ISellerDomainService
    {
        private readonly ISellerRepository _repository;

        public SellerDomainService(ISellerRepository repository)
        {
            _repository = repository;
        }

        public bool CheckSellerInfo(Seller seller)
        {
            var sellerExist = _repository.Exists(i => i.NationalCode == seller.NationalCode || i.UserId == seller.UserId);
            return !sellerExist;
        }

        public bool IsNationalCodeExist(string nationalCode)
        {
            return _repository.Exists(i => i.NationalCode == nationalCode);
        }
    }
}
