namespace VitalStrike.Domains.Bodies;

public record class LeftArmHP : IBodyPartHP
{
    public BodyPart BodyPart => BodyPart.LeftArmEnum;

    public double Weight => 1;

    public HP Value { get; init; }

    public LeftArmHP(HP value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Value = value;
    }

    public LeftArmHP() : this(HP.Max()) { }
}
