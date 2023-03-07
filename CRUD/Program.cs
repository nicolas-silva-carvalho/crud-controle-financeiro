using CRUD.Data;
using CRUD.Helper;
using CRUD.Repository;
using CRUD.Session;
using Microsoft.EntityFrameworkCore;

namespace CRUD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Contexto>(optins => optins.UseSqlServer(builder.Configuration.GetConnectionString("CRUD")));
            builder.Services.AddScoped<ISessao, Sessao>();
            builder.Services.AddScoped<IUsuarios, UsuarioRepos>();
            builder.Services.AddScoped<IControleFinanceiro, ControleFinanceiroRepos>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<IEmail, Email>();
            builder.Services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("@32302e342e30I6y/lx7Y wh2fPDIhhR9EcuZlcql9Q7kj3AB9ovYmZQ=;Mgo DSMBaFt/QHRqVVhkVFpHaVZdX2NLfUN3T2JadV5zZDU7a15RRnVfQV1hSH1SdUVgXXtXdw==;Mgo DSMBMAY9C3t2VVhkQlFacldJXnxAYVF2R2BJflRxd19GY0wxOX1dQl9gSX1TdERgWHxec3BQRGI=;Mgo DSMBPh8sVXJ0S0J XE9AflRBQmpWfFN0RnNYdV9zflVFcDwsT3RfQF5jSn5Rd0ZiWn9ddHFRRA==;@32302e342e30RP2EGQ3cx4f0cPcCAne4DCA2vOPjfSXv120lB3F/2m4=;NRAiBiAaIQQuGjN/V0Z WE9EaFtKVmBWd0x0RWFab196dVZMYF9BJAtUQF1hSn5QdkdiWn5dcHdRQ2le;NT8mJyc2IWhhY31nfWN9Z2toYHxqfGFjYWBzYmliYGljYHMDHmg9OjA8PzIgDDAyISUTPCYnPzw8OH0wPD4=;ORg4AjUWIQA/Gnt2VVhkQlFacldJXnxAYVF2R2BJflRxd19GY0wxOX1dQl9gSX1TdERgWHxec3BTRWI=;@32302e342e30WEB43OivueJXmCP9x6ZBgDvP SRtxHr6bk22LxjXqZM=;@32302e342e30QD YQfWi2mmpYivy0v8UBaijNl3f3xpAI08 8ntWSvA=;@32302e342e30VD7 FAZeJwZS8e9ApBPGUd2D7roBnB8Bq6jICYpQlNc=;@32302e342e30hk3GwZ/TwMNgUhKyK9fVqmCnK3lKO 6 MDzK/XEpUmY=;@32302e342e30I6y/lx7Y wh2fPDIhhR9EcuZlcql9Q7kj3AB9ovYmZQ=");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}