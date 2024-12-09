namespace VitalStrike.Domains.Exceptions;

/// <summary>
/// 存在しない例外
/// </summary>
public class NotFoundException : Exception
{
    public NotFoundException() : base() { }
    public NotFoundException(string message) : base(message) { }
    public NotFoundException(string message, Exception inner) : base(message, inner) { }
}
