using Microsoft.AspNetCore.Builder;

namespace MVCSession2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region Register Services In DI Container
            builder.Services.AddControllersWithViews();
            #endregion
            var app = builder.Build();


            #region MapGet
            ////Default
            //app.MapGet("/", () => "Hello World!");
            //// Satic Segment
            //app.MapGet("/maya", () => "Hello maya!");
            ////Dynamic Segment
            //app.MapGet("/{name}", async (context) =>
            //{
            //    var name = context.GetRouteValue("name");
            //    await context.Response.WriteAsync($"Hello {name}!");
            //});

            ////Mixed Segment
            //app.MapGet("/miss{name}", async (context) =>
            //{
            //    var name = context.GetRouteValue("name");
            //    await context.Response.WriteAsync($"Hello Miss {name}!");
            //}); 
            #endregion

            app.UseStaticFiles();
            app.MapControllerRoute(
                name: "Default",
                pattern: "{Controller= Home}/{Action=Index}/{id?}"
                //defaults: new { Controller = "Movies" , Action = "Index" }
                );
            app.Run();
        }
    }
}
