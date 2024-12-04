namespace VitalStrike.Domains.Bodies;

public record class RightArm : IBodyPart
{
    public BodyPart BodyPart => BodyPart.RightArmEnum;

    public readonly double Weight = 0.5;

    public HP Hp { get; private set; }

    public RightArm(HP value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Hp = value;
    }

    public RightArm() : this(HP.Max) { }

    public HP ApplyDamage(Damage damage)
    {
        ArgumentNullException.ThrowIfNull(damage, nameof(damage));
        Hp = Hp.ApplyDamage(damage, Weight);
        return Hp;
    }
}
