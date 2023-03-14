using Aleatoire_Common.Extensions;
using Aleatoire_Common.SelectionAleatoire;
using SelectionAleatoire_Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SelectionAleatoire_Ponderee
{
    class WeightedRandomSelector<T> : IRandomSelector<T>
    {
        private List<WeightedElement<T>> _weightedElements;
        private int _count;
        private Random _random;

        public WeightedRandomSelector(Random random, List<WeightedElement<T>> elements)
        {
            _random = random;
            _weightedElements = new List<WeightedElement<T>>(elements);
            _count = _weightedElements.Count;
        }

        public T Select()
        {
            if (Count() > 0)
            {
                int randomIndex = WeightedRandomIndex();
                return _weightedElements[randomIndex].Element;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public T Pop()
        {
            if (Count() > 0)
            {
                int randomIndex = WeightedRandomIndex();
                T element = _weightedElements[randomIndex].Element;
                Discard(randomIndex);
                return element;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        
        public void Reset()
        {
            _count = _weightedElements.Count;
        }

        public List<T> GetElements()
        {
            return _weightedElements.GetRange(0, Count()).Select(x => x.Element).ToList();
        }

        public int Count()
        {
            return _count;
        }

        public override string ToString()
        {
            return GetType().ToStringWithGenerics();
        }

        public string ToString(bool complete)
        {
            if (complete)
            {
                string elements = string.Join(", ", _weightedElements.GetRange(0, Count()).Select(e => e.ToString(WeightSum())));
                return string.Format("{0} \n {{{1}}}", ToString(), elements);
            }
            else
            {
                return ToString();
            }
        }

        private int WeightedRandomIndex()
        {
            float randomWeight = RandomWeight();
            for (int i = 0; i < Count(); ++i)
            {
                WeightedElement<T> weightedElement = _weightedElements[i];
                randomWeight -= weightedElement.Weight;
                if (randomWeight <= 0)
                {
                    return i;
                }
            }
            throw new InvalidOperationException();
        }

        private float RandomWeight()
        {
            return (float)(_random.NextDouble() * WeightSum());
        }

        private float WeightSum()
        {
            float weight = 0;
            for(int i = 0; i < Count(); ++i)
            {
                WeightedElement<T> weightedElement = _weightedElements[i];
                weight += weightedElement.Weight;
            }
            return weight;
        }

        private void Discard(int index)
        {
            _weightedElements.Swap(index, Count() - 1);
            --_count;
        }
    }
}
