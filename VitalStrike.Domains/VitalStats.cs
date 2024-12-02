using System.IO.Compression;
using VitalStrike.Domains.Bodies;

namespace VitalStrike.Domains;

/// <summary>
/// 体力
/// </summary>
/// <param name="Face"></param>
/// <param name="Hair"></param>
/// <param name="UpperBody"></param>
/// <param name="LeftArm"></param>
/// <param name="RightArm"></param>
/// <param name="LeftHand"></param>
/// <param name="RightHand"></param>
/// <param name="LeftLeg"></param>
/// <param name="RightLeg"></param>
/// <param name="LeftFoot"></param>
/// <param name="RightFoot"></param>
public record VitalStats(
    FaceHP Face,
    HairHP Hair,
    UpperBodyHP UpperBody,
    LeftArmHP LeftArm,
    RightArmHP RightArm,
    LeftHandHP LeftHand,
    RightHandHP RightHand,
    LeftLegHP LeftLeg,
    RightLegHP RightLeg,
    LeftFootHP LeftFoot,
    RightFootHP RightFoot
)
{

    private readonly IReadOnlyCollection<IBodyPartHP> _bodyParts = [Face, Hair,
                                                                    UpperBody,
                                                                    LeftArm, RightArm,
                                                                    LeftHand, RightHand,
                                                                    LeftLeg, RightLeg,
                                                                    LeftFoot, RightFoot];


    /// <summary>
    /// 体力100
    /// </summary>
    public VitalStats() : this(new FaceHP(), new HairHP(),
                                           new UpperBodyHP(),
                                           new LeftArmHP(), new RightArmHP(),
                                           new LeftHandHP(), new RightHandHP(),
                                           new LeftLegHP(), new RightLegHP(),
                                           new LeftFootHP(), new RightFootHP())
    { }

    /// <summary>
    /// 部位のHPの合計
    /// </summary>
    private double TotalPartsHP => _bodyParts
                                        .Select(x => x.Value.Value * x.Weight)
                                        .Sum(x => x);

    /// <summary>
    /// 体全体のHPを0～100に正規化した値
    /// </summary>
    public HP TotalHP => new HP(Map(TotalPartsHP));

    /// <summary>
    /// 値を指定された範囲に正規化
    /// </summary>
    private static double Map(double value)
    {
        return (value - 0) * (HP.MAX - HP.MIN) / (HP.MAX * 11 - 0) + 0;
    }
}