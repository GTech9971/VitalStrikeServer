namespace VitalStrike.Domains.Bodies;

public record class LeftLeg : IBodyPart
{
    public BodyPart BodyPart => BodyPart.LeftLegEnum;

    public readonly double Weight = 1;

    public HP Hp { get; private set; }

    public LeftLeg(HP value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Hp = value;
    }

    public LeftLeg() : this(HP.Max) { }

    public HP ApplyDamage(Damage damage)
    {
        ArgumentNullException.ThrowIfNull(damage, nameof(damage));
        Hp = Hp.ApplyDamage(damage, Weight);
        return Hp;
    }
}
