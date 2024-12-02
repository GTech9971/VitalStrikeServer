namespace VitalStrike.Domains.Bodies;

public record class UpperBodyHP : IBodyPartHP
{
    public BodyPart BodyPart => BodyPart.UpperBodyEnum;

    public double Weight => 2.5;

    public HP Value { get; init; }

    public UpperBodyHP(HP value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Value = value;
    }

    public UpperBodyHP() : this(HP.Max()) { }
}
