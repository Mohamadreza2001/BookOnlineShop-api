using Common.Application;
using MediatR;
using Shop.Application.SiteEntites.Slider.Create;
using Shop.Application.SiteEntites.Slider.Edit;
using Shop.Query.SiteEntites.DTOs;
using Shop.Query.SiteEntites.Sliders.GetById;
using Shop.Query.SiteEntites.Sliders.GetList;

namespace Shop.Presentation.facade.SiteEntites.Slider
{
    internal class SliderFacade : ISliderFacade
    {
        private readonly IMediator _mediator;

        public SliderFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> Create(CreateSliderCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Edit(EditSliderCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<SliderDto?> GetById(long id)
        {
            return await _mediator.Send(new GetByIdSliderQuery(id));
        }

        public async Task<List<SliderDto>> GetList()
        {
            return await _mediator.Send(new GetListSliderQuery());
        }
    }
}
