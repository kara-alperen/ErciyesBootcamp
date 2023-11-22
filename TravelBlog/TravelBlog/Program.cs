using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TravelBlog.Data.Abstract;
using TravelBlog.Data.Concrete;
using TravelBlog.Data.Concrete.EfCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<BlogContext>(options =>
        {
            options.UseSqlite(builder.Configuration["ConnectionStrings:sql_connection"]);
        });

        builder.Services.AddScoped<IPostRepository, EfPostRepository>();
        builder.Services.AddScoped<ITagRepository, EfTagRepository>();
        builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();
        builder.Services.AddScoped<IUserRepository, EfUserRepository>();

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>{
    options.LoginPath = "/Users/Login";
});

        var app = builder.Build();

        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        SeedData.TestVeriliniDoldur(app);

        app.MapControllerRoute(
            name: "post_details",
            pattern: "posts/details/{url}",
            defaults: new { controller = "Posts", action = "Details" }
        );
        app.MapControllerRoute(
            name: "post_by_tag",
            pattern: "posts/tag/{tag}",
            defaults: new { controller = "Posts", action = "Idex" }
        );
        app.MapControllerRoute(
            name: "user_profile",
            pattern: "profile/{username}",
            defaults: new { controller = "Posts", action = "Idex" }
        );
            app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
        );

        app.Run();
    }
}