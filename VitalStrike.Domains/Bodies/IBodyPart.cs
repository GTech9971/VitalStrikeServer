namespace VitalStrike.Domains.Bodies;

/// <summary>
/// 体の部位
/// </summary>
public interface IBodyPart
{
    /// <summary>
    /// 部位
    /// </summary>
    BodyPart BodyPart { get; }

    /// <summary>
    /// 体力
    /// </summary>
    HP Hp { get; }

    /// <summary>
    /// ダメージを受ける
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="isCritical">急所かどうか</param>
    /// <returns>ダメージを受けた結果</returns>
    HP ApplyDamage(Damage damage, out bool isCritical);
}
