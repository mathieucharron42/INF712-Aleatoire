using Aleatoire_Common.Extensions;
using Aleatoire_Common.SelectionAleatoire;
using SelectionAleatoire_Common;
using System;
using System.Collections.Generic;

namespace SelectionAleatoire_Uniforme
{
    class OptimalUniformRandomSelector<T> : IRandomSelector<T>
    {
        public OptimalUniformRandomSelector(Random random, List<T> elements)
        {
            _random = random;
            _elements = new List<T>(elements);
            _count = _elements.Count;
        }

        public T Select()
        {
            if (Count() > 0)
            {
                int randomIndex = RandomIndex();
                return _elements[randomIndex];
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
                int randomIndex = RandomIndex();
                T element = _elements[randomIndex];
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
            _count = _elements.Count;
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
                string elements = string.Join(", ", _elements.GetRange(0, Count()));
                return string.Format("{0} {{{1}}}", ToString(), elements);
            }
            else
            {
                return ToString();
            }
        }
        private Random _random;
        private List<T> _elements;
        private int _count;

        private int RandomIndex()
        {
            return _random.Next(Count());
        }

        private void Discard(int index)
        {
            _elements.Swap(index, Count() - 1);
            --_count;
        }
    }
}
