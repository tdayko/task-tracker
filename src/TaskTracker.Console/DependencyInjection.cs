using Microsoft.Extensions.DependencyInjection;

using RestSharp;

namespace TaskTracker.Console;

public static class DependencyInjection
{
    public static IServiceCollection AddRestClient(this IServiceCollection services, Uri uri)
    {
        services.AddSingleton(new RestClient(uri));
        return services;
    }
}