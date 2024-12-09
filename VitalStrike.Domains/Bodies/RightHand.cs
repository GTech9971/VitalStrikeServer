namespace VitalStrike.Domains.Bodies;

public record class RightHand : IBodyPart
{
    public BodyPart BodyPart => BodyPart.RightHandEnum;

    public readonly double Weight = 0.5;

    public HP Hp { get; private set; }

    public RightHand(HP value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Hp = value;
    }

    public RightHand() : this(HP.Max) { }

    public HP ApplyDamage(Damage damage, out bool isCritical)
    {
        ArgumentNullException.ThrowIfNull(damage, nameof(damage));
        isCritical = false;
        Hp = Hp.ApplyDamage(damage, Weight);
        return Hp;
    }
}
