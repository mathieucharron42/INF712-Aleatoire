using Aleatoire_Common;

namespace SelectionAleatoire_Common.Workbench
{
    public abstract class BaseRandomSelectorWorkbench<ElementType> : BaseRandomWorkbench<ElementType>
    {
        public BaseRandomSelectorWorkbench(string name, IRandomSelector<ElementType> selector)
            : base(name)
        {
            _selector = selector;
        }

        protected override ElementType ExecuteInternal(long iteration)
        {
            ElementType value = ExecuteIterationOperation(iteration, _selector);
            if (value != null)
            {
                Register(value);
            }
            return value;
        }

        protected abstract ElementType ExecuteIterationOperation(long iteration, IRandomSelector<ElementType> selector);

        private IRandomSelector<ElementType> _selector;
    }
}
