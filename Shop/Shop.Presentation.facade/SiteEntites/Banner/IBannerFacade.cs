using Common.Application;
using Shop.Application.SiteEntites.Banner.Create;
using Shop.Application.SiteEntites.Banner.Edit;
using Shop.Query.SiteEntites.DTOs;

namespace Shop.Presentation.facade.SiteEntites.Banner
{
    public interface IBannerFacade
    {
        Task<OperationResult> Create(CreateBannerCommand command);
        Task<OperationResult> Edit(EditBannerCommand command);

        Task<BannerDto?> GetById(long id);
        Task<List<BannerDto>> GetList();
    }
}
