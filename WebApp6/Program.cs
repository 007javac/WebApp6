using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Добавление сервисов MVC
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Обработка ошибок
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        // Маршруты
        app.MapControllerRoute(
            name: "programming",
            pattern: "Programming/{action}/{language?}/{color?}",
            defaults: new { controller = "Programming", action = "Index" }
        );

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Programming}/{action=Index}/{id?}"
        );

        app.Run();
    }
}
