namespace VitalStrike.Domains.Bodies;

public record class RightHandHP : IBodyPartHP
{
    public BodyPart BodyPart => BodyPart.RightHandEnum;

    public double Weight => 0.5;

    public HP Value { get; init; }

    public RightHandHP(HP value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Value = value;
    }

    public RightHandHP() : this(HP.Max()) { }
}
