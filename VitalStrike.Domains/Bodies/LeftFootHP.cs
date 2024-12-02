namespace VitalStrike.Domains.Bodies;

public record class LeftFootHP : IBodyPartHP
{
    public BodyPart BodyPart => BodyPart.LeftFootEnum;

    public double Weight => 1.2;

    public HP Value { get; init; }

    public LeftFootHP(HP value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Value = value;
    }

    public LeftFootHP() : this(HP.Max()) { }
}
