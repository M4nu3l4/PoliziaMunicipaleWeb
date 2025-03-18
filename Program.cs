using Cops.Data;
using Microsoft.EntityFrameworkCore;
using Cops.Models;

namespace Cops
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<CopsContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

          
            app.MapControllerRoute(
                name: "anagrafica",
                pattern: "Anagrafica/{action=Index}/{id?}",
                defaults: new { controller = "Anagrafica", action = "Index" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
    name: "agenteLogin",
    pattern: "AgenteDiPolizia/Login",
    defaults: new { controller = "AgenteDiPolizia", action = "Login" });

            // Rotta per l'Index dell'agente
            app.MapControllerRoute(
                name: "agenteIndex",
                pattern: "AgenteDiPolizia/Index/{id?}",
                defaults: new { controller = "AgenteDiPolizia", action = "Index" });



            //  il cittadino
            app.MapControllerRoute(
            name: "cittadino",
            pattern: "Cittadino/Index/{codiceFiscale?}",
            defaults: new { controller = "Cittadino", action = "Index" });

            app.UseExceptionHandler("/Home/Error");
            app.Run();
        }
    }
}



