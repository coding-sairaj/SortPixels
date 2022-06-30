using SortPixels.Helpers;

namespace SortPixels.Services;

public class SortingService{
    public int[] sortPixels(int[] pixels)
    {
        List<Tuple<int, int, int>> tuples = pixels.ToTuples();
        tuples.Sort();
        return tuples.ToIntArray();
    }
}