namespace Microsoft.Extensions.DependencyInjection;

public static class KubernetesProbesExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddKubernetesProbes(this object? services)
        => Add("public static object? AddKubernetesProbes(this object? services)");

    public static object? AddKubernetesProbes(this object? services, object? section)
        => Add("public static object? AddKubernetesProbes(this object? services, object? section)");

    public static object? AddKubernetesProbes(this object? services, Action<object?> configure)
        => Add("public static object? AddKubernetesProbes(this object? services, Action<object?> configure)");
}
