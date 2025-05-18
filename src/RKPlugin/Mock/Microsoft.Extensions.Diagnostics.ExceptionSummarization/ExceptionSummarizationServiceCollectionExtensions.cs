namespace Microsoft.Extensions.DependencyInjection;

public static class ExceptionSummarizationServiceCollectionExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddExceptionSummarizer(this object? services)
        => Add("public static object? AddExceptionSummarizer(this object? services)");

    public static object? AddExceptionSummarizer(this object? services, Action<object?> configure)
        => Add("public static object? AddExceptionSummarizer(this object? services, Action<object?> configure)");
}
