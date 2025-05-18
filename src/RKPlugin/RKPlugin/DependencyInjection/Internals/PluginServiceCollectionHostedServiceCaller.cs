using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionHostedServiceExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddHostedService<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THostedService>(this object? services) where THostedService : class
        => Add("public static object? AddHostedService<[DynamicallyAccessedMemberTypes.PublicConstructors)] THostedService>(this object? services) where THostedService : class");

    public static object? AddHostedService<THostedService>(this object? services, Func<IServiceProvider, THostedService> implementationFactory) where THostedService : class
        => Add("public static object? AddHostedService<THostedService>(this object? services, Func<IServiceProvider, THostedService> implementationFactory) where THostedService : class");
}
