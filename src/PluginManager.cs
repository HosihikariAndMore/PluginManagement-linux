﻿namespace Hosihikari.PluginManager;

public static class Manager
{
    private static readonly Dictionary<string, Plugin> s_plugins;

    static Manager()
    {
        s_plugins = new();
    }

    public static string? Load(Plugin plugin)
    {
        if (!plugin.Load() || string.IsNullOrWhiteSpace(plugin.Name))
        {
            plugin.Unload();
            return default;
        }
        s_plugins[plugin.Name] = plugin;
        return plugin.Name;
    }

    public static void Initialize(string name)
    {
        if (!s_plugins.TryGetValue(name, out Plugin? plugin))
        {
            throw new NullReferenceException();
        }
        if (!plugin.Initialize())
        {
            Unload(name);
        }
    }

    public static void Unload(string name)
    {
        if (!s_plugins.TryGetValue(name, out Plugin? plugin))
        {
            throw new NullReferenceException();
        }
        plugin.Unload();
        s_plugins.Remove(name);
    }

    internal static IEnumerable<string> EnumerateNames()
    {
        foreach (string name in s_plugins.Keys)
        {
            yield return name;
        }
    }
}
