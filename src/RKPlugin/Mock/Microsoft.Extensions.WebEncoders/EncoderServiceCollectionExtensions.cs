namespace Microsoft.Extensions.WebEncoders;

public static class EncoderServiceCollectionExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddWebEncoders(this object? services)
        => Add("public static object? AddWebEncoders(this object? services)");

    public static object? AddWebEncoders(this object? services, Action<object?> setupAction)
        => Add("public static object? AddWebEncoders(this object? services, Action<object?> setupAction)");
}