using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SistemaDeGestao.Data;
using SistemaDeGestao.Helper;
using SistemaDeGestao.Interface;
using SistemaDeGestao.Repository;
using SistemaDeGestao.Service;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var connection = builder.Configuration.GetConnectionString("DataBase");
        builder.Services.AddDbContext<BancoContent>(options => options.UseSqlServer(connection));

        builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<BancoContent>();

        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        builder.Services.AddScoped<IFabricantesRepository, FabricantesRepository>();
        builder.Services.AddScoped<IVeiculosRepository, VeiculosRepository>();
        builder.Services.AddScoped<IConcessionariasRepository, ConcessionariasRepository>();
        builder.Services.AddScoped<IVendasRepository, VendasRepository>();
        builder.Services.AddScoped<IVendasService, VendasService>();
        builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();
        builder.Services.AddScoped<ISessao, Sessao>();

        builder.Services.AddSession(o =>
        {
            o.Cookie.HttpOnly = true;
            o.Cookie.IsEssential = true;
        });


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

        app.UseAuthentication();
        app.UseAuthorization();
        //app.UseSession();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Login}/{action=Index}/{id?}");

        app.Run();
    }
}