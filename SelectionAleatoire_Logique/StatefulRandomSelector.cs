using Aleatoire_Common.Extensions;
using Aleatoire_Common.SelectionAleatoire;
using SelectionAleatoire_Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SelectionAleatoire_Logique
{
    class StatefulRandomSelector<T> : IRandomSelector<T>
    {
        private List<DynamicWeightedElement<T, DrawnState>> _elements;
        private int _count;
        private DrawnState _state;
        private Random _random;

        public StatefulRandomSelector(Random random, List<DynamicWeightedElement<T, DrawnState>> elements)
        {
            _random = random;
            _elements = new List<DynamicWeightedElement<T, DrawnState>>(elements);
            _count = _elements.Count;
            _state = new DrawnState();
        }

        public T Select()
        {
            if (Count() > 0)
            {
                int randomIndex = WeightedRandomIndex();
                var element = _elements[randomIndex].Element;
                _state.PreviousDraw.Add(element);
                return element;
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
                T element = _elements[randomIndex].Element;
                _state.PreviousDraw.Add(element);
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
            _state = new DrawnState();
            _count = _elements.Count;
        }

        public List<T> GetElements()
        {
            return _elements.GetRange(0, Count()).Select(x => x.Element).ToList();
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
                string elements = string.Join(", ", _elements.GetRange(0, Count()).Select(e => e.ToString(_state, WeightSum())));
                return string.Format("{0} \n {{{1}}} \n {2}", ToString(), elements, _state);
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
                var weightedElement = _elements[i];
                randomWeight -= weightedElement.Weight(_state);
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
            for (int i = 0; i < Count(); ++i)
            {
                var dynamicElement = _elements[i];
                weight += dynamicElement.Weight(_state);
            }
            return weight;
        }

        private void Discard(int index)
        {
            _elements.Swap(index, Count() - 1);
            --_count;
        }
    }
}
