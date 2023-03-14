namespace SelectionAleatoire_Ponderee
{
    struct WeightedElement<T>
    {
        public T Element { get; private set; }
        public float Weight { get; private set; }

        public WeightedElement(T element, float weight)
        {
            Element = element;
            Weight = weight;
        }

        public string ToString(float totalWeight)
        {
            return string.Format("[{0}/{1}|{2}]", Weight, totalWeight, Element);
        }
    }
}
