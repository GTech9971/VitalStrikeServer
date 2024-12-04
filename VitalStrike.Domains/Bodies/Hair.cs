namespace VitalStrike.Domains.Bodies;

public record class Hair : IBodyPart
{
    public BodyPart BodyPart => BodyPart.HairEnum;

    public readonly double Weight = 0.1;

    public HP Hp { get; private set; }

    public Hair(HP value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Hp = value;
    }

    public Hair() : this(HP.Max) { }


    public HP ApplyDamage(Damage damage)
    {
        ArgumentNullException.ThrowIfNull(damage, nameof(damage));
        Hp = Hp.ApplyDamage(damage, Weight);
        return Hp;
    }
}
