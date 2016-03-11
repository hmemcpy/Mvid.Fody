using System;

[AttributeUsage(AttributeTargets.Assembly)]
public sealed class MvidAttribute : Attribute
{
    public string Id { get; }

    public MvidAttribute(string  guid)
    {
        Id = guid;
    }
}