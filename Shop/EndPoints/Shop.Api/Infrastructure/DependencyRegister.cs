using AspNetCoreRateLimit;
using Shop.Api.Infrastructure.JwtUtility;

namespace Shop.Api.Infrastructure
{
    public static class DependencyRegister
    {
        public static void RegisterApiDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MapperProfile).Assembly);
            services.AddTransient<CustomJwtValidation>();
            services.AddCors(options =>
            {
                options.AddPolicy(name: "ShopApi", i => i.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddMemoryCache();

            services.Configure<IpRateLimitOptions>(configuration.GetSection("IpRateLimiting"));

            services.Configure<IpRateLimitPolicies>(configuration.GetSection("IpRateLimitPolicies"));

            services.AddInMemoryRateLimiting();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        }
    }
}
