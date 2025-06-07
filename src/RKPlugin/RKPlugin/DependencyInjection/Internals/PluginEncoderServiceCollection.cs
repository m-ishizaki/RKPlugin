using System;
using System.Linq;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginEncoderServiceCollection
{
    static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.EncoderServiceCollectionExtensions,Microsoft.Extensions.WebEncoders";

    public static object? AddWebEncoders(this object? services)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddWebEncoders)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services]);
        return result;
    }

    public static object? AddWebEncoders(this object? services, Action<object?> setupAction)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddWebEncoders)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(setupAction)
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, setupAction]);
        return result;
    }
}