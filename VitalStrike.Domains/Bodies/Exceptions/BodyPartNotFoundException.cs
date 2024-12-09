using VitalStrike.Domains.Exceptions;

namespace VitalStrike.Domains.Bodies.Exceptions;

public class BodyPartNotFoundException : NotFoundException
{
    public BodyPartNotFoundException() : base() { }
    public BodyPartNotFoundException(string message) : base(message) { }
    public BodyPartNotFoundException(string message, Exception innerException) : base(message, innerException) { }
}
