using System;
using System.Collections.Generic;
using SelectionAleatoire_Common;

namespace SelectionAleatoire_Ponderee
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            List<WeightedElement<string>> weightedNames = new List<WeightedElement<string>>()
            {
                new WeightedElement<string>("Mathieu", 82), // 82/118 = 0.6949
                new WeightedElement<string>("Richard", 20), // 20/118 = 0.1694
                new WeightedElement<string>("George", 2),   //  2/118 = 0.0169
                new WeightedElement<string>("Arthur", 10),  // 10/118 = 0.0847
                new WeightedElement<string>("Charlie", 4)   //  4/118 = 0.0338
            };

            const long iterations = 1000000;
            {
                WeightedRandomSelector<string> weightedSelector = new WeightedRandomSelector<string>(random, weightedNames);
                RandomSelectorWorkbenches.Select(weightedSelector, iterations);
            }
            {
                WeightedRandomSelector<string> weightedSelector = new WeightedRandomSelector<string>(random, weightedNames);
                RandomSelectorWorkbenches.Human(weightedSelector);
            }
        }
    }
}
