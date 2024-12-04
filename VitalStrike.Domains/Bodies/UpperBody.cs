namespace VitalStrike.Domains.Bodies;

public record class UpperBody : IBodyPart
{
    public BodyPart BodyPart => BodyPart.UpperBodyEnum;

    public readonly double Weight = 2.5;

    public HP Hp { get; private set; }

    public UpperBody(HP value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Hp = value;
    }

    public UpperBody() : this(HP.Max) { }

    public HP ApplyDamage(Damage damage)
    {
        ArgumentNullException.ThrowIfNull(damage, nameof(damage));
        Hp = Hp.ApplyDamage(damage, Weight);
        return Hp;
    }
}
