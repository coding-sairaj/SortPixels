namespace SortPixels.Helpers;
public class TupleComparer : IComparer
{
    public int Compare(Tuple<int, int, int> x, Tuple<int, int, int> y)
    {
        int res = x.Item1.CompareTo(y.Item1);
        if (res == 0)
        {
            res = x.Item2.CompareTo(y.Item2);
            if (res == 0)
            {
                res = x.Item3.CompareTo(y.Item3);
            }
        }
        return res;
    }
}
