using System;

namespace Engine.Attributes.Dev;

public class Debug : Attribute
{

    private bool debug { get; } = true;
    public Debug() { }
}