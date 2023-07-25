﻿namespace Hosihikari.PluginManager;

public abstract class EntryPointAttributeBase : Attribute
{
    internal abstract IEntryPoint CreateInstance();
}

[AttributeUsage(AttributeTargets.Assembly)]
public sealed class EntryPointAttribute<T> : EntryPointAttributeBase where T
    : IEntryPoint, new()
{
    internal override IEntryPoint CreateInstance() => new T();
}
