namespace VitalStrike.Domains;

public class Utils
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value">変換したい値</param>
    /// <param name="fromHigh">入力する値の最大値</param>
    /// <param name="fromLow">入力する値の最小値</param>
    /// <param name="toHigh">出力する値の最大値</param>
    /// <param name="toLow">出力する値の最小値</param>
    /// <returns></returns>
    public static double Map(double value, double fromHigh, double fromLow, double toHigh, double toLow)
    {
        return toHigh + (toLow - toHigh) * ((value - fromHigh) / (fromLow - fromHigh));
    }
}
