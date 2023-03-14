using Aleatoire_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using ValeurAleatoire_Common;

namespace ValeurAleatoire_Normale
{
    class Program
    {
        static void Main(string[] args)
        {
            const float mean = 0.0f;
            const float standardDeviation = 1.0f;

            Random random = new Random();
            Func<double> randomSampler = RandomUtils.GetNormalSampler(random, mean, standardDeviation);
            List<double> intervals = EnumerableExtensions.DoubleRange(-4, 4, 0.25).ToList();

            string name = string.Format("Normal with mean={0} and standard deviation={1}", mean, standardDeviation);

            {
                const int iterations = 1000000;
                RandomValueWorkbenches.Draw(name, randomSampler, iterations, intervals);
            }

            {
                RandomValueWorkbenches.Human(name, randomSampler, intervals);
            }
        }
    }
}
