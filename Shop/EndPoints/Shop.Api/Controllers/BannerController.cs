using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.SiteEntites.Banner.Create;
using Shop.Application.SiteEntites.Banner.Edit;
using Shop.Presentation.facade.SiteEntites.Banner;
using Shop.Query.SiteEntites.DTOs;
using System.Diagnostics.Contracts;

namespace Shop.Api.Controllers
{
    public class BannerController : ApiController
    {
        private readonly IBannerFacade _bannerFacade;

        public BannerController(IBannerFacade bannerFacade)
        {
            _bannerFacade = bannerFacade;
        }

        [HttpGet("{bannerId}")]
        public async Task<ApiResult<BannerDto?>> GetBannerById(long bannerId)
        {
            return QueryResult(await _bannerFacade.GetById(bannerId));
        }

        [HttpGet]
        public async Task<ApiResult<List<BannerDto>>> GetBannerList()
        {
            return QueryResult(await _bannerFacade.GetList());
        }

        [HttpPost]
        public async Task<ApiResult> CreateBanner([FromForm] CreateBannerCommand command)
        {
            return CommandResult(await _bannerFacade.Create(command));
        }

        [HttpPut]
        public async Task<ApiResult> EditBanner([FromForm] EditBannerCommand command)
        {
            return CommandResult(await _bannerFacade.Edit(command));
        }
    }
}
