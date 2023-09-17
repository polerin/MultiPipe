using System;

public class InvalidDefinitionState: Exception
{
    public InvalidDefinitionState() : base() {}

    public InvalidDefinitionState(string message) : base(message) { }

    public InvalidDefinitionState(string message, Exception innerException) : base(message, innerException) { }
}