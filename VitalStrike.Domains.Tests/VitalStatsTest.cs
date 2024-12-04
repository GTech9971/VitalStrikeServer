using VitalStrike.Domains.Bodies;

namespace VitalStrike.Domains.Tests;

/// <summary>
/// 体力のテスト
/// </summary>
public class VitalStatsTest
{
    [Fact(DisplayName = "最大体力")]
    public void Max()
    {
        VitalStats sut = new VitalStats();

        Assert.Equal(HP.Max, sut.TotalHP);
    }

    [Fact(DisplayName = "頭のみ0")]
    public void empty_head()
    {
        VitalStats sut = new VitalStats(new Face(new HP(0)), new Hair(), new UpperBody(),
                                        new LeftArm(), new RightArm(),
                                        new LeftHand(), new RightHand(),
                                        new LeftLeg(), new RightLeg(),
                                        new LeftFoot(), new RightFoot());

        Assert.Equal(new HP(0), sut.TotalHP);
    }

    [Fact(DisplayName = "髪のみ0")]
    public void empty_hair()
    {
        VitalStats sut = new VitalStats(new Face(), new Hair(new HP(0)), new UpperBody(),
                                        new LeftArm(), new RightArm(),
                                        new LeftHand(), new RightHand(),
                                        new LeftLeg(), new RightLeg(),
                                        new LeftFoot(), new RightFoot());

        Assert.Equal(HP.Max, sut.TotalHP);
    }

    [Fact(DisplayName = "顔にダメージを与える")]
    public void apply_damage_to_face()
    {
        VitalStats sut = new VitalStats();

        Damage damage = Damage.Max;

        sut.ApplyDamage(damage, BodyPart.FaceEnum);

        Assert.True(sut.IsDead);
    }


    [Fact(DisplayName = "左腕にダメージを与える")]
    public void apply_damage_to_left_leg()
    {
        VitalStats sut = new VitalStats();

        Damage damage = Damage.Max;

        sut.ApplyDamage(damage, BodyPart.LeftLegEnum);

        Assert.Equal(90, sut.TotalHP.Value);
    }
}
