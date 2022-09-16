namespace APIReto.Core.Extensions;

public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IPersonRepository, PersonRepository>();
        return services;
    }

    public static IServiceCollection AddBusiness(this IServiceCollection services)
    {
        services.AddTransient<IPersonBusiness, PersonBusiness>();
        return services;
    }
}
