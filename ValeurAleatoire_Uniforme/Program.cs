using System;
using ValeurAleatoire_Common;

namespace ValeurAleatoire_Uniforme
{
    class Program
    {
        static void Main(string[] args)
        {
            
            const int min = 0;
            const int max = 20;

            Random random = new Random();

            string name = string.Format("Uniform {0} to {1}", min, max);
            Func<int> uniformSampler = RandomUtils.GetUniformSampler(random, min, max);

            {
                const int iterations = 100000;
                RandomValueWorkbenches.Draw(name, uniformSampler, iterations);
            }

            {
                RandomValueWorkbenches.Human(name, uniformSampler);
            }
        }
    }
}
