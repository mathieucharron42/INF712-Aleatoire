using System;

namespace ValeurAleatoire_Common
{
    public static class RandomUtils
    {
        public static Func<int> GetUniformSampler(Random random, int min, int max)
        {
            return () => 
            { 
                return random.Next(min, max); 
            };
        }

        public static Func<double> GetNormalSampler(Random random, double mean = 0, double standardDeviation = 1)
        {
            return () =>
            {
                //https://stackoverflow.com/questions/218060/random-gaussian-variables
                double u1 = 1.0 - random.NextDouble(); //uniform(0,1] random doubles
                double u2 = 1.0 - random.NextDouble();
                double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
                double randNormal = mean + standardDeviation * randStdNormal; //random normal(mean,stdDev^2)
                return randNormal;
            };
        }
    }
}

