namespace HouseRentingSystem.Web.Infrastructure.Extensions;

using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

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
}
