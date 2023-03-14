namespace SelectionAleatoire_Common.Workbench
{
    public class SelectRandomSelectorWorkbench<ElementType> : BaseRandomSelectorWorkbench<ElementType>
    {
        public SelectRandomSelectorWorkbench(string name, IRandomSelector<ElementType> selector)
            : base(name, selector)
        { }

        protected override bool IsDone(long? maxIterations, long iteration)
        {
            return maxIterations.HasValue ? maxIterations.Value < Iterations : false;
        }

        protected override ElementType ExecuteIterationOperation(long iterations, IRandomSelector<ElementType> selector)
        {
            return selector.Select();
        }
    }
}
