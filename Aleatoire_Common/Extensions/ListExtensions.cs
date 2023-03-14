using System.Collections.Generic;

namespace Aleatoire_Common
{
    namespace SelectionAleatoire
    {
        public static class ListExtensions
        {
            public static void Swap<T>(this IList<T> list, int index1, int index2)
            {
                T tmp = list[index1];
                list[index1] = list[index2];
                list[index2] = tmp;
            }
        }
    }
}
