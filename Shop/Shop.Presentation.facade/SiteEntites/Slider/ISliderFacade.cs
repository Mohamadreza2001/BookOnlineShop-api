using Common.Application;
using Shop.Application.SiteEntites.Slider.Create;
using Shop.Application.SiteEntites.Slider.Edit;
using Shop.Query.SiteEntites.DTOs;

namespace Shop.Presentation.facade.SiteEntites.Slider
{
    public interface ISliderFacade
    {
        Task<OperationResult> Create(CreateSliderCommand command);
        Task<OperationResult> Edit(EditSliderCommand command);

        Task<SliderDto?> GetById(long id);
        Task<List<SliderDto>> GetList();
    }
}
