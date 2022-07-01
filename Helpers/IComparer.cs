namespace SortPixels.Helpers
{
  public interface IComparer
  {
    int Compare(Tuple<int, int, int> x, Tuple<int, int, int> y);
  }
}