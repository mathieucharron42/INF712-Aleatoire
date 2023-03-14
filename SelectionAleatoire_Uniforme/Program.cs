using SelectionAleatoire_Common;
using System;
using System.Collections.Generic;

namespace SelectionAleatoire_Uniforme
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            List<string> names = new List<string>()
            {
                "Mathieu",
                "Richard",
                "George",
                "Arthur",
                "Charlie"
            };

            const long iterations = 10000;
            {
                OptimalUniformRandomSelector<string> uniformSelector = new OptimalUniformRandomSelector<string>(random, names);
                RandomSelectorWorkbenches.Select(uniformSelector, iterations);
            }
            {
                OptimalUniformRandomSelector<string> uniformSelector = new OptimalUniformRandomSelector<string>(random, names);
                RandomSelectorWorkbenches.Pop(uniformSelector, iterations);
            }
            {
                OptimalUniformRandomSelector<string> uniformSelector = new OptimalUniformRandomSelector<string>(random, names);
                RandomSelectorWorkbenches.Human(uniformSelector);
            }
        }
    }
}
