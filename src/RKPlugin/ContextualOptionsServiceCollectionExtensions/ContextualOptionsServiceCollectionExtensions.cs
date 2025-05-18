namespace Microsoft.Extensions.DependencyInjection;

public static class ContextualOptionsServiceCollectionExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddContextualOptions(this object? services)
        => Add("public static object? AddContextualOptions(this object? services)");

    public static object? Configure<TOptions>(this object? services, Func<object?, object?, object?> loadOptions) where TOptions : class
        => Add("public static object? Configure<TOptions>(this object? services, Func<object?, object?, object?> loadOptions) where TOptions : class");

    public static object? Configure<TOptions>(this object? services, string? name, Func<object?, object?, object?> loadOptions) where TOptions : class
        => Add("public static object? Configure<TOptions>(this object? services, string? name, Func<object?, object?, object?> loadOptions) where TOptions : class");

    public static object? Configure<TOptions>(this object? services, Action<object?, TOptions> configure) where TOptions : class
         => Add("public static object? Configure<TOptions>(this object? services, Action<object?, TOptions> configure) where TOptions : class");

    public static object? Configure<TOptions>(this object services, string? name, Action<object?, TOptions> configure) where TOptions : class
        => Add("public static object? Configure<TOptions>(this object services, string? name, Action<object? TOptions> configure) where TOptions : class");

    public static object? ConfigureAll<TOptions>(this object? services, Func<object?, object?, object?> loadOptions) where TOptions : class
        => Add("public static object? ConfigureAll<TOptions>(this object? services, Func<object?, object?, object?> loadOptions) where TOptions : class");

    public static object? ConfigureAll<TOptions>(this object? services, Action<object?, TOptions> configure) where TOptions : class
        => Add("public static object? ConfigureAll<TOptions>(this object? services, Action<object?, TOptions> configure) where TOptions : class");
}
