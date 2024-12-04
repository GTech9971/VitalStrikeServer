using VitalStrike.Domains.Bodies;
using VitalStrike.Domains.Exceptions;

namespace VitalStrike.Domains;

/// <summary>
/// 体力
/// </summary>
public record VitalStats
{

    private Face _face;
    private Hair _hair;
    private UpperBody _upperBody;
    private LeftArm _leftArm;
    private RightArm _rightArm;
    private LeftHand _leftHand;
    private RightHand _rightHand;
    private LeftLeg _leftLeg;
    private RightLeg _rightLeg;
    private LeftFoot _leftFoot;
    private RightFoot _rightFoot;

    public VitalStats(Face face, Hair hair,
                        UpperBody upperBody,
                        LeftArm leftArm, RightArm rightArm,
                        LeftHand leftHand, RightHand rightHand,
                        LeftLeg leftLeg, RightLeg rightLeg,
                        LeftFoot leftFoot, RightFoot rightFoot)
    {
        ArgumentNullException.ThrowIfNull(face, nameof(face));
        ArgumentNullException.ThrowIfNull(hair, nameof(hair));
        ArgumentNullException.ThrowIfNull(upperBody, nameof(upperBody));
        ArgumentNullException.ThrowIfNull(leftArm, nameof(leftArm));
        ArgumentNullException.ThrowIfNull(rightArm, nameof(rightArm));
        ArgumentNullException.ThrowIfNull(leftHand, nameof(leftHand));
        ArgumentNullException.ThrowIfNull(rightHand, nameof(rightHand));
        ArgumentNullException.ThrowIfNull(leftLeg, nameof(leftLeg));
        ArgumentNullException.ThrowIfNull(rightLeg, nameof(rightLeg));
        ArgumentNullException.ThrowIfNull(leftFoot, nameof(leftFoot));
        ArgumentNullException.ThrowIfNull(rightFoot, nameof(rightFoot));

        _face = face;
        _hair = hair;
        _upperBody = upperBody;
        _leftArm = leftArm;
        _rightArm = rightArm;
        _leftHand = leftHand;
        _rightHand = rightHand;
        _leftLeg = leftLeg;
        _rightLeg = rightLeg;
        _leftFoot = leftFoot;
        _rightFoot = rightFoot;
    }


    /// <summary>
    /// 体力100
    /// </summary>
    public VitalStats() : this(new Face(), new Hair(),
                                           new UpperBody(),
                                           new LeftArm(), new RightArm(),
                                           new LeftHand(), new RightHand(),
                                           new LeftLeg(), new RightLeg(),
                                           new LeftFoot(), new RightFoot())
    { }

    private IReadOnlyCollection<IBodyPart> _bodyParts => [_face, _hair,
                                                            _upperBody,
                                                            _leftArm, _rightArm,
                                                            _leftHand, _rightHand,
                                                            _leftLeg, _rightLeg,
                                                            _leftFoot, _rightFoot];


    /// <summary>
    /// 部位のHPの合計
    /// *髪を除く
    /// </summary>
    private double TotalPartsHP => _bodyParts
                                        .Where(x => x is Hair == false)
                                        .Select(x => x.Hp.Value)
                                        .Sum(x => x);

    /// <summary>
    /// 体全体のHPを0～100に正規化した値
    /// 頭、胴体のHPが0の場合、必ずHPは0になる
    /// 髪は体力計算に関係しない
    /// </summary>
    public HP TotalHP
    {
        get
        {
            if (_face.Hp.IsEmpty || _upperBody.Hp.IsEmpty) { return HP.Empty; }
            // 髪を除く
            double maxValue = (_bodyParts.Count - 1) * HP.MAX;
            double value = Utils.Map(TotalPartsHP, maxValue, 0, 100, 0);
            return new HP(value);
        }
    }

    public bool IsDead => TotalHP.IsEmpty;


    /// <summary>
    /// ダメージを適用する
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="hitBodyPart"></param>
    /// <exception cref="BodyPartNotFoundException"></exception>
    public void ApplyDamage(Damage damage, BodyPart hitBodyPart)
    {
        ArgumentNullException.ThrowIfNull(damage, nameof(damage));
        ArgumentNullException.ThrowIfNull(hitBodyPart, nameof(hitBodyPart));

        IBodyPart? target = _bodyParts
                                .SingleOrDefault(x => x.BodyPart == hitBodyPart);

        if (target == null) { throw new BodyPartNotFoundException("存在しない部位が指定されました。"); }

        target.ApplyDamage(damage);
    }
}