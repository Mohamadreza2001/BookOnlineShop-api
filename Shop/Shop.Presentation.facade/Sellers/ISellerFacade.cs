using Common.Application;
using Shop.Application.Sellers.Create;
using Shop.Application.Sellers.Edit;
using Shop.Query.Sellers.DTOs;

namespace Shop.Presentation.facade.Sellers
{
    public interface ISellerFacade
    {
        Task<OperationResult> Create(CreateSellerCommand command);
        Task<OperationResult> Edit(EditSellerCommand command);

        Task<SellerFilterResult> GetByFilter(SellerFilterParams filterParams);
        Task<SellerDto?> GetById(long id);
    }
}
