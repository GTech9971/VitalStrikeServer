namespace VitalStrike.Domains.Bodies;

public record class FaceHP : IBodyPartHP
{
    public BodyPart BodyPart => BodyPart.FaceEnum;

    public double Weight => 20.0;

    public HP Value { get; init; }

    public FaceHP(HP value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Value = value;
    }

    public FaceHP() : this(HP.Max()) { }
}
