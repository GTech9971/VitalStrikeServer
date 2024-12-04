namespace VitalStrike.Domains.Exceptions;

public class BodyPartNotFoundException : Exception
{
    public BodyPartNotFoundException() : base() { }
    public BodyPartNotFoundException(string message) : base(message) { }
    public BodyPartNotFoundException(string message, Exception innerException) : base(message, innerException) { }
}
