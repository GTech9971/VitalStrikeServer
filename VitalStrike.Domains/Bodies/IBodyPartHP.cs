namespace VitalStrike.Domains.Bodies;

public interface IBodyPartHP
{
    /// <summary>
    /// 部位
    /// </summary>
    BodyPart BodyPart { get; }

    /// <summary>
    /// トータルHPに変換する際の重みづけ
    /// </summary>
    double Weight { get; }

    /// <summary>
    /// 体力
    /// </summary>
    HP Value { get; }
}
