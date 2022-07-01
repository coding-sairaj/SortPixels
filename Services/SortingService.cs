using SortPixels.Helpers;

namespace SortPixels.Services;

public class SortingService{
    public int[] getSortPixels(int[] pixels)
    {
        List<Tuple<int, int, int>> tuples = pixels.ToTuples();
        tuples.HueSort();
        return tuples.ToIntArray();
    }
    public int[] sortPixels(int[] pixels)
    {
        List<Tuple<int, int, int>> tuples = pixels.ToTuples();
        tuples.RGBSort();
        return tuples.ToIntArray();
    }
    public int[] getRandomPixels(int[] pixels)
    {
        Random rd = new Random();
        for (var i = 0; i < pixels.Length; i += 4) {
            pixels[i] = rd.Next(0, 255); // red
            pixels[i+1] = rd.Next(0, 255); // green
            pixels[i+2] = rd.Next(0, 255); // blue
            pixels[i+3] = 255; // alpha
        }
        return pixels;
    }    
}