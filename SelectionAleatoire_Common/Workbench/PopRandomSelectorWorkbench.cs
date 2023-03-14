namespace SelectionAleatoire_Common.Workbench
{
    public class PopRandomSelectorWorkbench<ElementType> : BaseRandomSelectorWorkbench<ElementType>
    {
        public PopRandomSelectorWorkbench(string name, IRandomSelector<ElementType> selector)
            : base(name, selector)
        { }

        protected override bool IsDone(long? maxIterations, long iteration)
        {
            return maxIterations.HasValue ? maxIterations.Value < Iterations : false;
        }

        protected override ElementType ExecuteIterationOperation(long iteration, IRandomSelector<ElementType> selector)
        {
            return selector.Pop();
        }
    }
}
