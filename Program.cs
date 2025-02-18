using learn_crud.Services;
using Microsoft.EntityFrameworkCore;

namespace learn_crud
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Đăng ký ApplicationDbContext vào Dependency Injection (DI) để có thể sử dụng nó trong ứng dụng.
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                //Lấy chuỗi kết nối từ appsettings.json
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

                //Sử dụng SQL Server làm database
                options.UseSqlServer(connectionString);
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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
