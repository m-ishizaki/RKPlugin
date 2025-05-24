using System.Diagnostics.CodeAnalysis;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

public static class AutoActivationExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? ActivateSingleton<TService>(this object? services) where TService : class
        => Add("public static object? ActivateSingleton<TService>(this object? services) where TService : class");

    public static object? ActivateSingleton(this object? services, Type serviceType)
        => Add("public static object? ActivateSingleton(this object? services, Type serviceType)");

    public static object? AddActivatedSingleton<TService, TImplementation>(this object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
        => Add("public static object? AddActivatedSingleton<TService, TImplementation>(this object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService");

    public static object? AddActivatedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TService : class where TImplementation : class, TService
        => Add("public static object? AddActivatedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TService : class where TImplementation : class, TService");

    public static object? AddActivatedSingleton<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
        => Add("public static object? AddActivatedSingleton<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class");

    public static object? AddActivatedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services) where TService : class
        => Add("public static object? AddActivatedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services) where TService : class");

    public static object? AddActivatedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
        => Add("public static object? AddActivatedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)");

    public static object? AddActivatedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, Func<IServiceProvider, object> implementationFactory)
        => Add("public static object? AddActivatedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, Func<IServiceProvider, object> implementationFactory)");

    public static object? AddActivatedSingleton(this object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static object? AddActivatedSingleton(this object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    public static void TryAddActivatedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
        => Add("public static void TryAddActivatedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)");

    public static void TryAddActivatedSingleton(this object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static void TryAddActivatedSingleton(this object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    public static void TryAddActivatedSingleton(this object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory)
        => Add("public static void TryAddActivatedSingleton(this object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory)");

    public static void TryAddActivatedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services) where TService : class
        => Add("public static void TryAddActivatedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services) where TService : class");

    public static void TryAddActivatedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TService : class where TImplementation : class, TService
        => Add("public static void TryAddActivatedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TService : class where TImplementation : class, TService");

    public static void TryAddActivatedSingleton<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
        => Add("public static void TryAddActivatedSingleton<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class");

    private static void TryAddAndActivate<TService>(this object? services, object? descriptor) where TService : class
        => Add("private static void TryAddAndActivate<TService>(this object? services, object? descriptor) where TService : class");

    private static void TryAddAndActivate(this object? services, object? descriptor)
        => Add("private static void TryAddAndActivate(this object? services, object? descriptor)");

    public static object? ActivateKeyedSingleton<TService>(this object? services, object? serviceKey) where TService : class
        => Add("public static object? ActivateKeyedSingleton<TService>(this object? services, object? serviceKey) where TService : class");

    public static object? ActivateKeyedSingleton(this object? services, Type serviceType, object? serviceKey)
        => Add("public static object? ActivateKeyedSingleton(this object? services, Type serviceType, object? serviceKey)");

    public static object? AddActivatedKeyedSingleton<TService, TImplementation>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
        => Add("public static object? AddActivatedKeyedSingleton<TService, TImplementation>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService");

    public static object? AddActivatedKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, object? serviceKey) where TService : class where TImplementation : class, TService
        => Add("public static object? AddActivatedKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, object? serviceKey) where TService : class where TImplementation : class, TService");

    public static object? AddActivatedKeyedSingleton<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
        => Add("public static object? AddActivatedKeyedSingleton<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class");

    public static object? AddActivatedKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services, object? serviceKey) where TService : class
        => Add("public static object? AddActivatedKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services, object? serviceKey) where TService : class");

    public static object? AddActivatedKeyedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, object? serviceKey)
        => Add("public static object? AddActivatedKeyedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, object? serviceKey)");

    public static object? AddActivatedKeyedSingleton(this object? services, Type serviceType, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
        => Add("public static object? AddActivatedKeyedSingleton(this object? services, Type serviceType, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)");

    public static object? AddActivatedKeyedSingleton(this object? services, Type serviceType, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static object? AddActivatedKeyedSingleton(this object? services, Type serviceType, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    public static void TryAddActivatedKeyedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, object? serviceKey)
        => Add("public static void TryAddActivatedKeyedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, object? serviceKey)");

    public static void TryAddActivatedKeyedSingleton(this object? services, Type serviceType, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static void TryAddActivatedKeyedSingleton(this object? services, Type serviceType, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    public static void TryAddActivatedKeyedSingleton(this object? services, Type serviceType, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
        => Add("public static void TryAddActivatedKeyedSingleton(this object? services, Type serviceType, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)");

    public static void TryAddActivatedKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services, object? serviceKey) where TService : class
        => Add("public static void TryAddActivatedKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services, object? serviceKey) where TService : class");

    public static void TryAddActivatedKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, object? serviceKey) where TService : class where TImplementation : class, TService
        => Add("public static void TryAddActivatedKeyedSingleton<TService, [DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, object? serviceKey) where TService : class where TImplementation : class, TService");

    public static void TryAddActivatedKeyedSingleton<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
        => Add("public static void TryAddActivatedKeyedSingleton<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class");

    private static void TryAddAndActivateKeyed<TService>(this object? services, object? descriptor) where TService : class
        => Add("private static void TryAddAndActivateKeyed<TService>(this object? services, object? descriptor) where TService : class");

    private static void TryAddAndActivateKeyed(this object? services, object? descriptor)
        => Add("private static void TryAddAndActivateKeyed(this object? services, object? descriptor)");
}
