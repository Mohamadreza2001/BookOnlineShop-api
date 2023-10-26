using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Application.SiteEntites.Slider.Create;
using Shop.Application.SiteEntites.Slider.Edit;
using Shop.Domain.RoleAgg.Enums;
using Shop.Presentation.facade.SiteEntites.Slider;
using Shop.Query.SiteEntites.DTOs;

namespace Shop.Api.Controllers
{
    [PermissionChecker(Permission.CRUD_Slider)]
    public class SliderController : ApiController
    {
        private readonly ISliderFacade _sliderFacade;

        public SliderController(ISliderFacade sliderFacade)
        {
            _sliderFacade = sliderFacade;
        }

        [HttpGet("{sliderId}")]
        public async Task<ApiResult<SliderDto?>> GetSliderById(long sliderId)
        {
            return QueryResult(await _sliderFacade.GetById(sliderId));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ApiResult<List<SliderDto>>> GetSliderList()
        {
            return QueryResult(await _sliderFacade.GetList());
        }

        [HttpPost]
        public async Task<ApiResult> CreateSlider([FromForm] CreateSliderCommand command)
        {
            return CommandResult(await _sliderFacade.Create(command));
        }

        [HttpPut]
        public async Task<ApiResult> EditSlider([FromForm] EditSliderCommand command)
        {
            return CommandResult(await _sliderFacade.Edit(command));
        }
    }
}
