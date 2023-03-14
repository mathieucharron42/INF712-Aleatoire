using SelectionAleatoire_Common;
using System;
using System.Collections.Generic;

namespace SelectionAleatoire_Logique
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            var weightedNames = new List<DynamicWeightedElement<string, DrawnState>>()
            {
                new DynamicWeightedElement<string, DrawnState>("George", s => { return 1; }),
                new DynamicWeightedElement<string, DrawnState>("Mathieu", s => { return 20; }),
                new DynamicWeightedElement<string, DrawnState>("Paul", s => { return s.PreviousDraw.Contains("Mathieu") ? 4 : 0; }),
                new DynamicWeightedElement<string, DrawnState>("Arthur", s => { return !s.PreviousDraw.Contains("Arthur") ? 20 : 0; }),
                new DynamicWeightedElement<string, DrawnState>("Charlie", s => { return s.PreviousDraw.Contains("George") ? 1 : 0; }),
                new DynamicWeightedElement<string, DrawnState>("Richard", s => { return s.PreviousDraw.Contains("Paul") && s.PreviousDraw.Contains("Arthur") ? 20 : 0; }),
            };

            StatefulRandomSelector<string> statefulSelector = new StatefulRandomSelector<string>(random, weightedNames);
            RandomSelectorWorkbenches.Human(statefulSelector);
        }
    }
}
