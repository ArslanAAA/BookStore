using BookStore.Data;
using BookStore.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace BookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<BookStoreContext>(option=>option.UseSqlServer("Server=.;Database=BookStore;User=sa;Password=Glob@l375"));
#if DEBUG
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
            builder.Services.AddScoped<BookRepository, BookRepository>();
            var app = builder.Build();
            app.UseStaticFiles();
            app.MapDefaultControllerRoute();
            //app.MapControllerRoute(
            //    name:"Default",
            //    pattern: "book1/{controller=Home}/{action=Index}/{Id?}"         
            //    );
            app.Run();
        }
    }
}