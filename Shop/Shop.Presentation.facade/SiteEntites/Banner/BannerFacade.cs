using Common.Application;
using MediatR;
using Shop.Application.SiteEntites.Banner.Create;
using Shop.Application.SiteEntites.Banner.Edit;
using Shop.Query.SiteEntites.Banners.GetById;
using Shop.Query.SiteEntites.Banners.GetList;
using Shop.Query.SiteEntites.DTOs;

namespace Shop.Presentation.facade.SiteEntites.Banner
{
    internal class BannerFacade : IBannerFacade
    {
        private readonly IMediator _mediator;

        public BannerFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> Create(CreateBannerCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Edit(EditBannerCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<BannerDto?> GetById(long id)
        {
            return await _mediator.Send(new GetByIdBannerQuery(id));
        }

        public async Task<List<BannerDto>> GetList()
        {
            return await _mediator.Send(new GetListBannerQuery());
        }
    }
}
