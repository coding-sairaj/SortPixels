namespace SortPixels.Helpers;
public class SortHelper{
     public List<Tuple<int, int, int>> SortTuple(List<Tuple<int, int, int>> list, IComparer comparer)
     {        
        for(var n = 0; n<list.Count; n++)
        {
            for(var i=0;i<list.Count - n - 1; i++)
            {
                var cur = list[i];
                var nxt = list[i+1];
                if(comparer.Compare(cur, nxt) > 0)
                {
                    list[i] = nxt;
                    list[i+1] = cur;
                }
            }
        }
        return list;
     }
}