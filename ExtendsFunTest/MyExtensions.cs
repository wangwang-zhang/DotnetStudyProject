

namespace ExtendsFunTest;

public static class MyExtensions
{
    public static List<T> RemoveDuplication<T>(this List<T> list)
    {
        var listArray = list.ToArray();
        for (int i = 0; i < list.Count; i++)
        {
            int count = list.Count(elem => Equals(elem, listArray[i]));
            if (count > 1)
            {
                list.Remove(listArray[i]);
            }
        }
        return list;
    }
}