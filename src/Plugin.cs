﻿namespace Hosihikari.PluginManagement;

public abstract class Plugin
{
    public string Name { get; protected set; }
    public Version Version { get; protected set; }

    protected FileInfo _fileInfo;

    protected Plugin(FileInfo fileInfo)
    {
        _fileInfo = fileInfo;
        Name = fileInfo.Name;
        Version = new();
    }

    protected internal abstract void Load();
    protected internal abstract void Initialize();
    protected internal abstract void Unload();
}
