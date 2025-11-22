using Azure;
using DomainLayer.Contracts;
using DomainLayer.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersistenceLayer;
using PersistenceLayer.Data;
using PersistenceLayer.Repositories;
using ServiceAbstractionLayer;
using ServicesLayer;
using TalabatDemo.CustomMiddlewares;
using TalabatDemo.Factories;
using PresentationLaye;
using TalabatDemo.Extentions;

namespace TalabatDemo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddSwaggerService();


            #region Register User-Defined Services
            builder.Services.AddApplicationServices();
            builder.Services.AddInfraStructureService(builder.Configuration);
            builder.Services.AddWebApplicationServices(builder.Configuration);
            

            #endregion

            var app = builder.Build();
            await app.SeedDatabaseAsync();

            // Configure the HTTP request pipeline.

            #region Configure the HTTP request pipeline
            app.UseCustomExceptionMiddleware();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run(); 
            #endregion
        }
    }
}
