using System;

namespace SelectionAleatoire_Logique
{
    struct DynamicWeightedElement<T, State>
    {
        public T Element { get; private set; }
        public Func<State, float> Weight { get; private set; }

        public DynamicWeightedElement(T element, Func<State, float> weightFunc)
        {
            Element = element;
            Weight = weightFunc;
        }

        public string ToString(State state, float totalWeight)
        {
            return string.Format("[{1}/{2}|{0}]", Element, Weight(state), totalWeight);
        }
    }
}
