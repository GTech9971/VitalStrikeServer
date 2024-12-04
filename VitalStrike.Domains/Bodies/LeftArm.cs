namespace VitalStrike.Domains.Bodies;

public record class LeftArm : IBodyPart
{
    public BodyPart BodyPart => BodyPart.LeftArmEnum;

    private readonly double Weight = 1;

    public HP Hp { get; private set; }


    public LeftArm(HP value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Hp = value;
    }

    public LeftArm() : this(HP.Max) { }

    public HP ApplyDamage(Damage damage)
    {
        ArgumentNullException.ThrowIfNull(damage, nameof(damage));

        Hp = Hp.ApplyDamage(damage, Weight);

        return Hp;
    }
}
