using System;
using ValeurAleatoire_Common;

namespace ValeurAleatoire_Uniforme
{
    class Program
    {
        static void Main(string[] args)
        {
            const int iterations = 100000;
            const int min = 0;
            const int max = 20;

            Random random = new Random();

            WorkbenchReporter reporter = new WorkbenchReporter();
            
            string name = string.Format("Uniform {0} to {1} for {2} draws", min, max, iterations);
            Func<int> uniformSampler = RandomUtils.GetUniformSampler(random, min, max);
            RandomValueWorkbench<int> workbench = new RandomValueWorkbench<int>(name, uniformSampler);

            reporter.WriteExecutionBegin(workbench);
            workbench.Execute(iterations);
            reporter.WriteExecutionEnd(workbench);
        }
    }
}
