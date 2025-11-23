using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TalabatDemo.Factories;
using Microsoft.OpenApi.Models;

namespace TalabatDemo.Extentions
{
    public static class ServiceRegisteration
    {
        public static IServiceCollection AddSwaggerService(this IServiceCollection Services) {
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen( options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    In=ParameterLocation.Header,
                    Name="Authorization",
                    Type=SecuritySchemeType.ApiKey,
                    Scheme="Bearer",
                    Description="Enter 'Bearer' Followed By Space And Your Token"

                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference=new OpenApiReference()
                            {
                                Id="Bearer",
                                Type=ReferenceType.SecurityScheme
                            }

                        },
                        new string[]{ }
                    
                    }
                    

                });
            });
            return Services;

        }

        public static IServiceCollection AddWebApplicationServices (this IServiceCollection Services, IConfiguration configuration)
        {
            Services.Configure<ApiBehaviorOptions>((options) =>
            {
                options.InvalidModelStateResponseFactory = ApiResponseFactory.GenerateApiValidationErrorResponse;
            });
            Services.ConfigureJWT(configuration);
            return Services;
        }
        private static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSection = configuration.GetSection("JwtOptions");
            var secretKey = jwtSection["SecretKey"];
            var issuer = jwtSection["Issuer"];
            var audience = jwtSection["Audience"];
            services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(config =>
            {
                config.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))

                };

            });
        }
    }
}
