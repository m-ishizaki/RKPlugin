using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Extensions.DependencyInjection;

public static class ObjectPoolServiceCollectionExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddPooled<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services, Action<object?>? configure = null) where TService : class
        => Add("public static object? AddPooled<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services, Action<object?>? configure = null) where TService : class");

    public static object? AddPooled<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, Action<object?>? configure = null) where TService : class where TImplementation : class, TService
        => Add("public static object? AddPooled<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, Action<object?>? configure = null) where TService : class where TImplementation : class, TService");

    public static object? ConfigurePool<TService>(this object? services, Action<object?> configure) where TService : class
        => Add("public static object? ConfigurePool<TService>(this object? services, Action<object?> configure) where TService : class");

    public static object? ConfigurePools(this object? services, object?section)
        => Add("public static object? ConfigurePools(this object? services, object? section)");

    private static object? AddPooledInternal<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, Action<object?>? configure) where TService : class where TImplementation : class, TService
        => Add("private static object? AddPooledInternal<TService, [DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, Action<object?>? configure) where TService : class where TImplementation : class, TService");
}
