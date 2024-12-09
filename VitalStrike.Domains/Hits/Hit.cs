using VitalStrike.Domains.Bodies;
using VitalStrike.Domains.Users;

namespace VitalStrike.Domains.Hits;

/// <summary>
/// ヒット
/// </summary>
public record class Hit
{
    /// <summary>
    /// ID
    /// </summary>
    public HitId? HitId { get; init; }

    /// <summary>
    /// 攻撃者ID
    /// </summary>
    public UserId AttackerId { get; init; }

    /// <summary>
    /// ターゲット
    /// </summary>
    public User Target { get; init; }

    /// <summary>
    /// ヒット部位
    /// </summary>
    public BodyPart HitZone { get; init; }

    /// <summary>
    /// ヒット座標
    /// </summary>
    public HitPoint Point { get; init; }

    /// <summary>
    /// ダメージ
    /// </summary>
    public Damage Damage { get; init; }

    /// <summary>
    /// 急所かどうか
    /// </summary>
    public bool IsCritical { get; init; }

    /// <summary>
    /// ヒット日時
    /// </summary>
    public DateTime HitAt { get; init; }

    public Hit(UserId attackerId, User target, BodyPart hitZone,
                HitPoint point, Damage damage, bool isCritical, DateTime hitAt)
    {
        ArgumentNullException.ThrowIfNull(attackerId, nameof(attackerId));
        ArgumentNullException.ThrowIfNull(target, nameof(target));
        ArgumentNullException.ThrowIfNull(hitZone, nameof(hitZone));
        ArgumentNullException.ThrowIfNull(point, nameof(point));
        ArgumentNullException.ThrowIfNull(damage, nameof(damage));

        AttackerId = attackerId;
        Target = target;
        HitZone = hitZone;
        Point = point;
        Damage = damage;
        IsCritical = isCritical;
        HitAt = hitAt;
    }

    public Hit(HitId hitId, UserId attackerId, User target, BodyPart hitZone,
                HitPoint point, Damage damage, bool isCritical, DateTime hitAt) : this(attackerId, target, hitZone,
                                                                                        point, damage, isCritical, hitAt)
    {
        ArgumentNullException.ThrowIfNull(hitId, nameof(hitId));
        HitId = hitId;
    }
}
