namespace Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionContainerBuilderExtensions
    {
        public static List<string> Invoked = new List<string>();

        static object? Add(string name)
        {
            Invoked.Add(name);
            return null;
        }

        public static object? BuildServiceProvider(this object? services)
            => Add("public static object? BuildServiceProvider(this object? services)");

        public static object? BuildServiceProvider(this object? services, object? options)
            => Add("public static object? BuildServiceProvider(this object? services, object? options)");

        public static object? BuildServiceProvider(this object? services, bool validateScopes)
            => Add("public static object? BuildServiceProvider(this object? services, bool validateScopes)");
    }
