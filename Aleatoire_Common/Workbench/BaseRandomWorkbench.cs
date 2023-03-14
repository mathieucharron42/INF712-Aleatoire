using System;
using System.Collections.Generic;

namespace Aleatoire_Common
{
    public abstract class BaseRandomWorkbench<ElementType> : IRandomWorkbench<ElementType>
    {
        public string Name
        {
            get { return _name; }
        }

        public Dictionary<ElementType, long> Occurences
        {
            get { return _occurences; }
        }

        public long Iterations
        {
            get { return _iterations; }
        }

        public DateTime ExecutionStart
        {
            get { return _start; }
        }

        public DateTime ExecutionEnd
        {
            get { return _end; }
        }

        public BaseRandomWorkbench(string name)
        {
            _name = name;
            _occurences = new Dictionary<ElementType, long>();
        }

        public void Execute(long? iterations = null)
        {
            _occurences.Clear();

            _start = DateTime.Now;
            
            _iterations = 0;
            do
            {
                ExecuteInternal(_iterations);
                ++_iterations;
            }
            while (!IsDone(iterations, _iterations));

            _end = DateTime.Now;
        }

        protected void Register(ElementType value)
        {
            if (!_occurences.ContainsKey(value))
            {
                _occurences[value] = 1;
            }
            else
            {
                ++_occurences[value];
            }
        }

        protected abstract void ExecuteInternal(long iteration);

        protected abstract bool IsDone(long? maxIterations, long iteration);

        private string _name;
        private long _iterations;
        private Dictionary<ElementType, long> _occurences;
        private DateTime _start;
        private DateTime _end;
    }
}
