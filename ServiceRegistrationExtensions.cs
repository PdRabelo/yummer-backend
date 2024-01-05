using System.Reflection;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection AddMyServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        foreach (var type in assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Any()))
        {
            var serviceType = type.GetInterfaces().FirstOrDefault();

            if (serviceType != null)
            {
                services.AddScoped(serviceType, type);
            }
        }

        return services;
    }
}
