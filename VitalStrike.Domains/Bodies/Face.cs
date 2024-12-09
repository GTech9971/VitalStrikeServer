namespace VitalStrike.Domains.Bodies;

public record class Face : IBodyPart
{
    public BodyPart BodyPart => BodyPart.FaceEnum;

    private readonly double Weight = 20.0;

    public HP Hp { get; private set; }


    public Face(HP value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Hp = value;
    }

    public Face() : this(HP.Max) { }

    public HP ApplyDamage(Damage damage, out bool isCritical)
    {
        ArgumentNullException.ThrowIfNull(damage, nameof(damage));
        isCritical = true;
        Hp = Hp.ApplyDamage(damage, Weight);
        return Hp;
    }
}
