namespace VitalStrike.Domains.Bodies;

public record class HairHP : IBodyPartHP
{
    public BodyPart BodyPart => BodyPart.HairEnum;

    public double Weight => 0.1;

    public HP Value { get; init; }

    public HairHP(HP value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Value = value;
    }

    public HairHP() : this(HP.Max()) { }
}
