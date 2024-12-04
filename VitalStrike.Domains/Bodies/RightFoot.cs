namespace VitalStrike.Domains.Bodies;

public record class RightFoot : IBodyPart
{
    public BodyPart BodyPart => BodyPart.RightFootEnum;

    public readonly double Weight = 1;

    public HP Hp { get; private set; }

    public RightFoot(HP value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Hp = value;
    }

    public RightFoot() : this(HP.Max) { }

    public HP ApplyDamage(Damage damage)
    {
        ArgumentNullException.ThrowIfNull(damage, nameof(damage));
        Hp = Hp.ApplyDamage(damage, Weight);
        return Hp;
    }
}
