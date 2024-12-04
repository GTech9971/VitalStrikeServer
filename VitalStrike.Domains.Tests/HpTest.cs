namespace VitalStrike.Domains.Tests;

/// <summary>
/// Hpテスト
/// </summary>
public class HpTest
{
    [Fact(DisplayName = "最大ダメージを受ける")]
    public void damage()
    {
        Damage damage = Damage.Max;

        HP sut = HP.Max.ApplyDamage(damage);

        Assert.True(sut.IsEmpty);
    }

    [Theory(DisplayName = "ウェイト付きダメージ")]
    [InlineData(1, 1, 99)]
    [InlineData(1, 100, 0)]
    [InlineData(1, 50, 50)]
    [InlineData(10, 1.5, 85)]
    public void damage_weight(double damageVal, double weight, double expected)
    {
        Damage damage = new Damage(damageVal);

        HP sut = HP.Max.ApplyDamage(damage, weight);

        Assert.Equal(expected, sut.Value);
    }
}
