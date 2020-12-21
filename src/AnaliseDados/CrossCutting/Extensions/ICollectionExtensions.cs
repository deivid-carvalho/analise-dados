using System.Collections.Generic;
using System.Linq;

namespace AnaliseDados.CrossCutting.Extensions
{
    public static class ICollectionExtensions
    {
        public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
        {
            return collection == null || !collection.Any();
        }

    }
}
