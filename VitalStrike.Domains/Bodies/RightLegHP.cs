namespace VitalStrike.Domains.Bodies;

public record class RightLegHP : IBodyPartHP
{
    public BodyPart BodyPart => BodyPart.RightLegEnum;

    public double Weight => 1.5;

    public HP Value { get; init; }

    public RightLegHP(HP value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Value = value;
    }

    public RightLegHP() : this(HP.Max()) { }
}
