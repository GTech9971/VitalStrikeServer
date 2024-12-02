namespace VitalStrike.Domains.Hits;

/// <summary>
/// ヒット情報永続化を行う
/// </summary>
public interface IHitRepository
{
    Task<HitId> SaveAsync(Hit hit);
}
