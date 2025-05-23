﻿using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionServiceExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddTransient(this object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static object? AddTransient(this object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    public static object? AddTransient(this object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory)
        => Add("public static object? AddTransient(this object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory)");

    public static object? AddTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TService : class where TImplementation : class, TService
        => Add("public static object? AddTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TService : class where TImplementation : class, TService");

    public static object? AddTransient(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
        => Add("public static object? AddTransient(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)");

    public static object? AddTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services) where TService : class
        => Add("public static object? AddTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services) where TService : class");

    public static object? AddTransient<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
        => Add("public static object? AddTransient<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class");

    public static object? AddTransient<TService, TImplementation>(this object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
        => Add("public static object? AddTransient<TService, TImplementation>(this object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService");

    public static object? AddScoped(this object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static object? AddScoped(this object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    public static object? AddScoped(this object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory)
        => Add("public static object? AddScoped(this object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory)");

    public static object? AddScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TService : class where TImplementation : class, TService
        => Add("public static object? AddScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TService : class where TImplementation : class, TService");

    public static object? AddScoped(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
        => Add("public static object? AddScoped(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)");

    public static object? AddScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services) where TService : class
        => Add("public static object? AddScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services) where TService : class");

    public static object? AddScoped<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
        => Add("public static object? AddScoped<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class");

    public static object? AddScoped<TService, TImplementation>(this object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
        => Add("public static object? AddScoped<TService, TImplementation>(this object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService");

    public static object? AddSingleton(this object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static object? AddSingleton(this object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    public static object? AddSingleton(this object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory)
        => Add("public static object? AddSingleton(this object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory)");

    public static object? AddSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TService : class where TImplementation : class, TService
        => Add("public static object? AddSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TService : class where TImplementation : class, TService");

    public static object? AddSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
        => Add("public static object? AddSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)");

    public static object? AddSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services) where TService : class
        => Add("public static object? AddSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services) where TService : class");

    public static object? AddSingleton<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
        => Add("public static object? AddSingleton<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class");

    public static object? AddSingleton<TService, TImplementation>(this object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
        => Add("public static object? AddSingleton<TService, TImplementation>(this object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService");

    public static object? AddSingleton(this object? services, Type serviceType, object implementationInstance)
        => Add("public static object? AddSingleton(this object? services, Type serviceType, object implementationInstance)");

    public static object? AddSingleton<TService>(this object? services, TService implementationInstance) where TService : class
        => Add("public static object? AddSingleton<TService>(this object? services, TService implementationInstance) where TService : class");
}
