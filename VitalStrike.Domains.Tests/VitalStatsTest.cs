using VitalStrike.Domains.Bodies;

namespace VitalStrike.Domains.Tests;

/// <summary>
/// 体力のテスト
/// </summary>
public class VitalStatsTest
{
    [Fact(DisplayName = "最大体力")]
    public void max()
    {
        VitalStats sut = new VitalStats();

        Assert.Equal(HP.Max(), sut.TotalHP);
    }

    [Fact(DisplayName = "頭のみ0")]
    public void empty_head()
    {
        VitalStats sut = new VitalStats(new FaceHP(new HP(0)), new HairHP(), new UpperBodyHP(),
                                        new LeftArmHP(), new RightArmHP(),
                                        new LeftHandHP(), new RightHandHP(),
                                        new LeftLegHP(), new RightLegHP(),
                                        new LeftFootHP(), new RightFootHP());

        Assert.Equal(new HP(0), sut.TotalHP);
    }

    [Fact(DisplayName = "髪のみ0")]
    public void empty_hair()
    {
        VitalStats sut = new VitalStats(new FaceHP(), new HairHP(new HP(0)), new UpperBodyHP(),
                                        new LeftArmHP(), new RightArmHP(),
                                        new LeftHandHP(), new RightHandHP(),
                                        new LeftLegHP(), new RightLegHP(),
                                        new LeftFootHP(), new RightFootHP());

        Assert.Equal(HP.Max(), sut.TotalHP);
    }
}
