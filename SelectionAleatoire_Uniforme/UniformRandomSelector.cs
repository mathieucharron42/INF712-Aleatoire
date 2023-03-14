using Aleatoire_Common.Extensions;
using SelectionAleatoire_Common;
using System;
using System.Collections.Generic;

namespace SelectionAleatoire_Uniforme
{
    class UniformRandomSelector<T> : IRandomSelector<T>
    {
        public UniformRandomSelector(Random random, List<T> elements)
        {
            _random = random;
            _originalElements = elements;
            _elements = new List<T>(elements);
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
            _elements = new List<T>(_originalElements);
        }

        public int Count()
        {
            return _elements.Count;
        }

        public override string ToString()
        {
            return GetType().ToStringWithGenerics();
        }

        public string ToString(bool complete)
        {
            if (complete)
            {
                string elements = string.Join(", ", _elements);
                return string.Format("{0} {{{1}}}", ToString(), elements);
            }
            else
            {
                return ToString();
            }
        }

        private Random _random;
        private List<T> _originalElements;
        private List<T> _elements;

        private int RandomIndex()
        {
            return _random.Next(Count());
        }

        private void Discard(int index)
        {
            _elements.RemoveAt(index);
        }
    }
}
