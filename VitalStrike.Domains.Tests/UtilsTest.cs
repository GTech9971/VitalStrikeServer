namespace VitalStrike.Domains.Tests;

public class UtilsTest
{
    [Fact]
    public void sample()
    {
        double value = 20;

        double actual = Utils.Map(value, 20, 80, 100, 200);

        Assert.Equal(100, actual);
    }

    [Fact]
    public void Max()
    {
        double value = 1100;

        double actual = Utils.Map(value, 1100, 0, 100, 0);

        Assert.Equal(100, actual);
    }

    [Fact]
    public void min()
    {
        double value = 0;

        double actual = Utils.Map(value, 1100, 0, 100, 0);

        Assert.Equal(0, actual);
    }
}
