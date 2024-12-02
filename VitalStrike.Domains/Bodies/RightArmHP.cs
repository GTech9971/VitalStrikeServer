namespace VitalStrike.Domains.Bodies;

public record class RightArmHP : IBodyPartHP
{
    public BodyPart BodyPart => BodyPart.RightArmEnum;

    public double Weight => 0.5;

    public HP Value { get; init; }

    public RightArmHP(HP value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Value = value;
    }

    public RightArmHP() : this(HP.Max()) { }
}
