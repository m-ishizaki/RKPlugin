using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.Linq;

namespace RkSoftware.RKPlugin.Reflection;

internal static class TypeInitializer
{
    static Dictionary<string, Type> Types = new Dictionary<string, Type>();
    static Dictionary<(Type, string), MethodInfo> Methods = new Dictionary<(Type, string), MethodInfo>();

    static Type? Type(string typeName)
    {
        if (Types.TryGetValue(typeName, out var type) && type != null)
            return type;

        type = System.Type.GetType(typeName);
        if (type == null)
            return null;

        Types[typeName] = type;
        return type;
    }

    public static MethodInfo? Method(string typeName, string key, Func<Type, MethodInfo?> func)
    {
        var type = Type(typeName);
        if (type == null)
            return null;

        var dictionaryKey = (type, key);
        if (Methods.TryGetValue(dictionaryKey, out var method) && method != null)
            return method;

        method = func(type);
        if (method == null)
            return null;

        Methods[dictionaryKey] = method;
        return method;
    }
}

