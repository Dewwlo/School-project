using System.Collections.Generic;

namespace TextAdventure.Extensions
{
    public static class ListExtensions
    {
        public static void AddMany<T>(this List<T> list, params T[] elements)
        {
            list.AddRange(elements);
        }
    }
}
