using System.Collections.Generic;
using System.Linq;

namespace DatabaseModelCreator
{
    public static class ListExtensions
    {
        /// <summary>
        /// Check if list is null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsEmpty<T>(this List<T> list) where T : class
            => list == null && !list.Any();
    }
}
