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

    public HP ApplyDamage(Damage damage, out bool isCritical)
    {
        ArgumentNullException.ThrowIfNull(damage, nameof(damage));
        isCritical = false;
        Hp = Hp.ApplyDamage(damage, Weight);
        return Hp;
    }
}
