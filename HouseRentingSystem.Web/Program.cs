namespace HouseRentingSystem.Web;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Data;
using Data.Models;
using Services.Data;
using Infrastructure.Extensions;
using Infrastructure.ModelBinders;

using static Common.GeneralApplicationConstants;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        string connectionString = builder.Configuration
            .GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        builder.Services
            .AddDbContext<HouseRentingDbContext>(options =>
            options.UseSqlServer(connectionString));

        builder.Services
            .AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = builder
                    .Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");

                options.Password.RequireLowercase = builder
                    .Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequireUppercase = builder
                    .Configuration.GetValue<bool>("Identity:Password:RequireUppercase"); ;
                options.Password.RequireNonAlphanumeric = builder
                    .Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric"); ;
                options.Password.RequireDigit = builder
                    .Configuration.GetValue<bool>("Identity:Password:RequireDigit"); ;
                options.Password.RequiredLength = builder
                    .Configuration.GetValue<int>("Identity:Password:RequiredLength"); ;
            })
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<HouseRentingDbContext>();

        builder.Services
            .AddApplicationServices(typeof(HouseService));

        builder.Services.ConfigureApplicationCookie(cfg =>
        {
            cfg.LoginPath = "/User/Login";
            cfg.AccessDeniedPath = "/Home/Error/401";
        });

        builder.Services
            .AddControllersWithViews()
            .AddMvcOptions(options =>
        {
            options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
            options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
        });

        WebApplication app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error/500");
            app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");

            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        if (app.Environment.IsDevelopment())
        {
            app.SeedAdministrator(DevelopmentAdminEmail);
        }

        app.UseEndpoints(config =>
        {
            config.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );
            config.MapDefaultControllerRoute();
            config.MapRazorPages();
        });

        app.Run();
    }
}