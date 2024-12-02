namespace VitalStrike.Domains.Bodies;

public record class LeftLegHP : IBodyPartHP
{
    public BodyPart BodyPart => BodyPart.LeftLegEnum;

    public double Weight => 1.5;

    public HP Value { get; init; }

    public LeftLegHP(HP value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Value = value;
    }

    public LeftLegHP() : this(HP.Max()) { }
}
