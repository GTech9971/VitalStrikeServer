using VitalStrike.Domains.Bodies;

namespace VitalStrike.Domains.Hits;

/// <summary>
/// ヒット
/// </summary>
public record class Hit
{

    public HitId? HitId { get; init; }

    public UserId AttackerId { get; init; }

    public User Target { get; init; }

    public BodyPart HitZone { get; init; }


    public HitPoint Point { get; init; }

    public Damage Damage { get; init; }

    public bool IsCritical { get; init; }

    /// <summary>
    /// ヒット日時
    /// </summary>
    public DateTime HitAt { get; init; }
}
