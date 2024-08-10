using Microsoft.EntityFrameworkCore;
using SistemaDeGestao.Data;
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

        var provider = builder.Services.BuildServiceProvider();
        var configuration = provider.GetRequiredService<IConfiguration>();
        builder.Services.AddEntityFrameworkSqlServer()
            .AddDbContext<BancoContent>(item => item.UseSqlServer(configuration.GetConnectionString("DataBase")));

        builder.Services.AddScoped<IFabricantesRepository, FabricantesRepository>();
        builder.Services.AddScoped<IVeiculosRepository, VeiculosRepository>();
        builder.Services.AddScoped<IConcessionariasRepository, ConcessionariasRepository>();
        builder.Services.AddScoped<IVendasRepository, VendasRepository>();
        builder.Services.AddScoped<IVendasService, VendasService>();
        builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();


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

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}