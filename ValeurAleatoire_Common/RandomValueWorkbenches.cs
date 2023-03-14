using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValeurAleatoire_Common
{
    public static class RandomValueWorkbenches
    {
        public static void Draw<ValueType>(string name, Func<ValueType> randomSampler, int iterations, List<ValueType> intervals = null)
            where ValueType : struct, IComparable, IComparable<ValueType>, IConvertible, IEquatable<ValueType>, IFormattable
        {
            using (WorkbenchReporter reporter = new WorkbenchReporter())
            {
                string workBenchName = string.Format("{0} for {1} draws", name, iterations);
                DrawRandomValueWorkbench<ValueType> workbench = new DrawRandomValueWorkbench<ValueType>(workBenchName, randomSampler, intervals);

                reporter.WriteExecutionBegin(workbench);
                workbench.Execute(iterations);
                reporter.WriteExecutionEnd(workbench);
            }
        }

        public static void Human<ValueType>(string name, Func<ValueType> randomSampler, List<ValueType> intervals = null)
            where ValueType : struct, IComparable, IComparable<ValueType>, IConvertible, IEquatable<ValueType>, IFormattable
        {
            using (WorkbenchReporter reporter = new WorkbenchReporter())
            {
                string workBenchName = string.Format("{0} by human control", name);
                HumanRandomValueWorkbench<ValueType> workbench = new HumanRandomValueWorkbench<ValueType>(workBenchName, randomSampler, intervals);

                reporter.WriteExecutionBegin(workbench);
                workbench.Execute();
                reporter.WriteExecutionEnd(workbench);
            }
        }
    }
}
