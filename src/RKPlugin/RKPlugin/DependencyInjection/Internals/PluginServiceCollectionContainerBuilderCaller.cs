using System.Reflection;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginServiceCollectionContainerBuilderCaller
{
    public static List<string> Invoked = new List<string>();

    public static object? BuildServiceProvider(this object? services)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
    .FirstOrDefault(m =>
        m.Name == nameof(BuildServiceProvider)
        && m.GetParameters().Length == 0
    );
        return methodInfo?.Invoke(services, null);
    }

    public static object? BuildServiceProvider(this object? services, object? options)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(m =>
            m.Name == nameof(BuildServiceProvider)
            && m.GetParameters().Length == 1
            && m.GetParameters()[0].Name == nameof(options)
    );
        return methodInfo?.Invoke(services, new[] { options });
    }

    public static object? BuildServiceProvider(this object? services, bool validateScopes)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(m =>
            m.Name == nameof(BuildServiceProvider)
            && m.GetParameters().Length == 1
            && m.GetParameters()[0].Name == nameof(validateScopes)
    );
        return methodInfo?.Invoke(services, new object[] { validateScopes });
    }
}
