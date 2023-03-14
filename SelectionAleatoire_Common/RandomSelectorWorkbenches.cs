using SelectionAleatoire_Common.Workbench;
using ValeurAleatoire_Common;

namespace SelectionAleatoire_Common
{
    public static class RandomSelectorWorkbenches
    {
        public static void Select<ElementType>(IRandomSelector<ElementType> selector, long iterations)
        {
            using (WorkbenchReporter reporter = new WorkbenchReporter())
            {
                string name = string.Format("Select x {0} on {1}", iterations, selector.ToString(true));
                SelectRandomSelectorWorkbench<ElementType> workbench = new SelectRandomSelectorWorkbench<ElementType>(name, selector);

                reporter.WriteExecutionBegin(workbench);
                workbench.Execute(iterations);
                reporter.WriteExecutionEnd(workbench);
            }
        }

        public static void Pop<ElementType>(IRandomSelector<ElementType> selector, long iterations)
        {
            using (WorkbenchReporter reporter = new WorkbenchReporter())
            {
                string name = string.Format("Pop x {0} on {1}", iterations, selector.ToString(true));
                SelectRandomSelectorWorkbench<ElementType> workbench = new SelectRandomSelectorWorkbench<ElementType>(name, selector);

                reporter.WriteExecutionBegin(workbench);
                workbench.Execute(iterations);
                reporter.WriteExecutionEnd(workbench);
            }
        }

        public static void Human<ElementType>(IRandomSelector<ElementType> selector)
        {
            using (WorkbenchReporter reporter = new WorkbenchReporter())
            {
                string name = string.Format("Human interactive test on {0}", selector.ToString(true));
                HumanRandomSelectorWorkbench<ElementType> workbench = new HumanRandomSelectorWorkbench<ElementType>(name, selector);

                reporter.WriteExecutionBegin(workbench);
                workbench.Execute();
                reporter.WriteExecutionEnd(workbench);
            }
        }
    }
}
