using System.Collections.Generic;

namespace Aleatoire_Common
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<double> DoubleRange(double min, double max, double step)
        {
            for (double value = min; value <= max; value += step)
            {
                yield return value;
            }
        }
    }
}
