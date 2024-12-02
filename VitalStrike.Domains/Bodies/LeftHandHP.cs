namespace VitalStrike.Domains.Bodies;

public record class LeftHandHP : IBodyPartHP
{
    public BodyPart BodyPart => BodyPart.LeftHandEnum;

    public double Weight => 0.5;

    public HP Value { get; init; }

    public LeftHandHP(HP value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Value = value;
    }

    public LeftHandHP() : this(HP.Max()) { }
}
