namespace VitalStrike.Domains.Bodies;

public record class LeftHand : IBodyPart
{
    public BodyPart BodyPart => BodyPart.LeftHandEnum;

    public readonly double Weight = 0.5;

    public HP Hp { get; private set; }

    public LeftHand(HP value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Hp = value;
    }

    public LeftHand() : this(HP.Max) { }

    public HP ApplyDamage(Damage damage)
    {
        ArgumentNullException.ThrowIfNull(damage, nameof(damage));
        Hp = Hp.ApplyDamage(damage, Weight);
        return Hp;
    }
}
