namespace VitalStrike.Domains.Bodies;

public record class RightLeg : IBodyPart
{
    public BodyPart BodyPart => BodyPart.RightLegEnum;

    public readonly double Weight = 1;

    public HP Hp { get; private set; }

    public RightLeg(HP value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Hp = value;
    }

    public RightLeg() : this(HP.Max) { }

    public HP ApplyDamage(Damage damage)
    {
        ArgumentNullException.ThrowIfNull(damage, nameof(damage));
        Hp = Hp.ApplyDamage(damage, Weight);
        return Hp;
    }
}
