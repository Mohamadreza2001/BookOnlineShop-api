﻿using Shop.Api.Infrastructure.JwtUtility;

namespace Shop.Api.Infrastructure
{
    public static class DependencyRegister
    {
        public static void RegisterApiDependency(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperProfile).Assembly);
            services.AddTransient<CustomJwtValidation>();
            services.AddCors(options =>
            {
                options.AddPolicy(name: "ShopApi", i => i.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }
    }
}
