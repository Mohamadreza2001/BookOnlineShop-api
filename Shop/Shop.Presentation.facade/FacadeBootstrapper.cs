using Microsoft.Extensions.DependencyInjection;
using Shop.Presentation.facade.Categories;
using Shop.Presentation.facade.Comments;
using Shop.Presentation.facade.Orders;
using Shop.Presentation.facade.Products;
using Shop.Presentation.facade.Roles;
using Shop.Presentation.facade.Sellers;
using Shop.Presentation.facade.Sellers.Inventories;
using Shop.Presentation.facade.SiteEntites.Banner;
using Shop.Presentation.facade.SiteEntites.Slider;
using Shop.Presentation.facade.Users;
using Shop.Presentation.facade.Users.Addresses;
using System.Runtime.CompilerServices;

namespace Shop.Presentation.facade
{
    public static class FacadeBootstrapper
    {
        public static void InitFacadeDependency(this IServiceCollection services)
        {
            services.AddScoped<ICategoryFacade, CategoryFacade>();
            services.AddScoped<ICommentFacade, CommentFacade>();
            services.AddScoped<IOrderFacade, OrderFacade>();
            services.AddScoped<IProductFacade, ProductFacade>();
            services.AddScoped<IRoleFacade, RoleFacade>();
            services.AddScoped<ISellerFacade, SellerFacade>();
            services.AddScoped<IBannerFacade, BannerFacade>();
            services.AddScoped<ISliderFacade, SliderFacade>();
            services.AddScoped<IUserFacade, UserFacade>();
            services.AddScoped<IUserAddressFacade, UserAddressFacade>();
            services.AddScoped<ISellerInventoryFacade, SellerInventoryFacade>();
        }
    }
}
