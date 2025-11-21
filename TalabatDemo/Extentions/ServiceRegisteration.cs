using Microsoft.AspNetCore.Mvc;
using TalabatDemo.Factories;

namespace TalabatDemo.Extentions
{
    public static class ServiceRegisteration
    {
        public static IServiceCollection AddSwaggerService(this IServiceCollection Services) {
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen();
            return Services;

        }

        public static IServiceCollection AddWebApplicationServices (this IServiceCollection Services)
        {
            Services.Configure<ApiBehaviorOptions>((options) =>
            {
                options.InvalidModelStateResponseFactory = ApiResponseFactory.GenerateApiValidationErrorResponse;
            });
            return Services;
        }
    }
}
