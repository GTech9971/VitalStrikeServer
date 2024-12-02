namespace VitalStrike.Domains.Bodies;

public record class RightFootHP : IBodyPartHP
{
    public BodyPart BodyPart => BodyPart.RightFootEnum;

    public double Weight => 1.5;

    public HP Value { get; init; }

    public RightFootHP(HP value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Value = value;
    }

    public RightFootHP() : this(HP.Max()) { }
}
