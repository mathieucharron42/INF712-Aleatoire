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
            const int iterations = 1000000;
            const float mean = 0.0f;
            const float standardDeviation = 1.0f;

            Random random = new Random();

            WorkbenchReporter reporter = new WorkbenchReporter();

            string name = string.Format("Normale avec espérance={0} et écart type={1} pour {2} tirages", mean, standardDeviation, iterations);
            Func<double> randomSampler = RandomUtils.GetNormalSampler(random, mean, standardDeviation);
            List<double> intervals = EnumerableExtensions.DoubleRange(-4, 4, 0.25).ToList();
            RandomValueWorkbench<double> workbench = new RandomValueWorkbench<double>(name, randomSampler, intervals);

            reporter.WriteExecutionBegin(workbench);
            workbench.Execute(iterations);
            reporter.WriteExecutionEnd(workbench);
        }
    }
}
