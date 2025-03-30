using RkSoftware.RKPlugin.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace RkSoftware.RKPlugin;

public class PluginLoadContext : AssemblyLoadContext
{
    public string PluginDirectory { get; init; }
    public bool IsSearchAllDirectories { get; init; }

    public PluginLoadContext(string pluginDirectory) : this(pluginDirectory, true)
    {
    }
    public PluginLoadContext(string pluginDirectory, bool isSearchAllDirectories)
    {
        PluginDirectory = pluginDirectory;
        IsSearchAllDirectories = isSearchAllDirectories;
    }

    private IEnumerable<Assembly> Load(string[] files)
    {
        var dllFiles = files.Select(file => Path.GetFullPath(file));
        var loaded = new List<Assembly>();
        foreach (var dllFile in dllFiles)
        {
            var assembly = LoadFromAssemblyPath(dllFile);
            loaded.Add(assembly);
        }
        return loaded.ToArray();
    }

    public IEnumerable<Assembly> Load()
        => Load(Directory.GetFiles(PluginDirectory, "*.dll", IsSearchAllDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).ToArray());

    public static IEnumerable<PluginLoadContext> LoadExtensions(string pluginDirectory)
    {
        if (!Directory.Exists(pluginDirectory)) return Array.Empty<PluginLoadContext>();

        var directories = Directory.GetDirectories(pluginDirectory).Where(directory => Directory.GetFiles(directory, "*.dll", SearchOption.AllDirectories).Any()).ToArray();
        var contexts = directories.Select(directory => new PluginLoadContext(directory)).ToArray();
        {
            foreach (var context in contexts)
                context.Load();
        }

        if (!Directory.GetFiles(pluginDirectory, "*.dll", SearchOption.TopDirectoryOnly).Any())
            return contexts;

        {
            var context = new PluginLoadContext(pluginDirectory, false);
            context.Load();
            var allContexts = new[] { context }.Concat(contexts).ToArray();
            return allContexts;
        }
    }

    public static object? Invoke(object? services, MethodInfo method, object? obj, object?[]? parameters) =>
        method.Invoke(obj, [new PluginServiceCollection(services), .. parameters ?? Array.Empty<object?>()]);
}