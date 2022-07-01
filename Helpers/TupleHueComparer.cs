namespace SortPixels.Helpers;

public class TupleHueComparer : IComparer
{
    public int Compare(Tuple<int, int, int> x, Tuple<int, int, int> y)
    {
        int res = CalculateHue(x).CompareTo(CalculateHue(y));
        return res;
    }

    private int CalculateHue(Tuple<int, int, int> x)
    {
        int red = x.Item1;
        int blue = x.Item2;
        int green = x.Item3;
        float min = Math.Min(Math.Min(red, green), blue);
        float max = Math.Max(Math.Max(red, green), blue);

        if (min == max)
            return 0;
        float hue;
        if (max == red)
            hue = (green - blue) / (max - min);
        else if (max == green)
            hue = 2f + (blue - red) / (max - min);
        else
            hue = 4f + (red - green) / (max - min);
        hue *= 60;
        if (hue < 0)
            hue += 360;
        return Convert.ToInt32(Math.Round(hue));
    }
}
