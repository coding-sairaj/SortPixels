namespace SortPixels.Helpers;

static class Extensions
{
    public static List<Tuple<int, int, int>> ToTuples(this int[] array)
    {
        var list = new List<Tuple<int, int, int>>();
        for (int i = 0; i < array.Length; i += 4)
        {
            list.Add(new Tuple<int, int, int>(array[i], array[i + 1], array[i + 2]));
        }
        return list;
    }

    public static int[] ToIntArray(this List<Tuple<int, int, int>> tuples)
    {
        int[] result = new int[tuples.Count * 4];
        for (int i = 0, j = 0; i < tuples.Count; i++, j += 4)
        {
            result[j] = tuples[i].Item1;
            result[j + 1] = tuples[i].Item2;
            result[j + 2] = tuples[i].Item3;
            result[j + 3] = 255;
        }
        return result;
    }

    public static void RGBSort(this List<Tuple<int, int, int>> tuples)
    {
        var helper = new SortHelper();
        helper.SortTuple(tuples, new TupleComparer());
    }

    public static void HueSort(this List<Tuple<int, int, int>> tuples)
    {
        var helper = new SortHelper();
        helper.SortTuple(tuples, new TupleHueComparer());
    }
}
