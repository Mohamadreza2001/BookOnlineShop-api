using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application._Utilities;
using Shop.Application.Categories;
using Shop.Application.Products;
using Shop.Application.Roles.Create;
using Shop.Application.Sellers;
using Shop.Application.Users;
using Shop.Domain.CategoryAgg.Services;
using Shop.Domain.ProductAgg.Services;
using Shop.Domain.SellerAgg.Services;
using Shop.Domain.UserAgg.Services;
using Shop.Infrastructure;
using Shop.Query.Orders.GetById;

namespace Shop.Config
{
    public static class ShopBootstrapper
    {
        public static void RegisterShopDependency(this IServiceCollection services, string connectionString)
        {
            InfrastructureBootstrapper.Init(services, connectionString);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Directories).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetByIdOrderQuery).Assembly));

            services.AddTransient<IProductDomainService, ProductDomainService>();
            services.AddTransient<ICategoryDomainService, CategoryDomainService>();
            services.AddTransient<IUserDomainService, UserDomainService>();
            services.AddTransient<ISellerDomainService, SellerDomainService>();

            services.AddValidatorsFromAssembly(typeof(CreateRoleCommandValidator).Assembly);
        }
    }
}