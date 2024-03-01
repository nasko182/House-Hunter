namespace HouseRentingSystem.Web.Infrastructure.Extensions;

using System.Reflection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using Data.Models;

using static Common.GeneralApplicationConstants;

public static class WebApplicationBuilderExtensions
{
    /// <summary>
    /// This method registers all services with their interfaces and implementations of given assembly.
    /// The assembly is taken from the type of random service implementation provided.
    /// </summary>
    /// <param name="serviceType">Type of random service implementation</param>
    /// <exception cref="InvalidOperationException"></exception>

    public static void AddApplicationServices(this IServiceCollection services, Type serviceType)
    {
        Assembly? servicesAssembly = Assembly.GetAssembly(serviceType);
        if (servicesAssembly == null)
        {
            throw new InvalidOperationException("Invalid service type provided!");
        }

        Type[] servicesTypes = servicesAssembly.GetTypes()
            .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
            .ToArray();

        foreach (Type servType in servicesTypes)
        {
            Type? interfaceType = servType
                .GetInterface($"I{servType.Name}");
            if (interfaceType == null)
            {
                throw new InvalidOperationException(
                    $"No interface is provide for the service with name: {servType.Name}");
            }

            services.AddScoped(interfaceType, servType);
        }
    }

    public static IApplicationBuilder SeedAdministrator(this IApplicationBuilder app, string email)
    {
        using IServiceScope scopeServices = app.ApplicationServices.CreateScope();

        IServiceProvider serviceProvider = scopeServices.ServiceProvider;

        UserManager<ApplicationUser> userManager =
            serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        RoleManager<IdentityRole<Guid>> roleManager =
            serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

        Task.Run(async () =>
        {
            if (await roleManager.RoleExistsAsync(AdminRoleName))
            {
                return;
            }

            IdentityRole<Guid> role = new IdentityRole<Guid>(AdminRoleName);
            await roleManager.CreateAsync(role);

            ApplicationUser adminUser = await userManager.FindByEmailAsync(email);

            await userManager.AddToRoleAsync(adminUser, AdminRoleName);
        })
            .GetAwaiter()
            .GetResult();

        return app;
    }
}
