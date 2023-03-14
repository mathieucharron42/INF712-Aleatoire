using Aleatoire_Common;
using System;
using System.Collections.Generic;

namespace ValeurAleatoire_Common
{
    public class DrawRandomValueWorkbench<ElementType> : BaseRandomWorkbench<ElementType>
        where ElementType : struct, IComparable, IComparable<ElementType>, IConvertible, IEquatable<ElementType>, IFormattable
    {
        public DrawRandomValueWorkbench(string name, Func<ElementType> randomFunc, List<ElementType> intervals = null)
            : base(name)
        {
            _randomFunc = randomFunc;
            _intervals = intervals;
        }

        protected override bool IsDone(long? maxIterations, long iteration)
        {
            return maxIterations.HasValue ? maxIterations.Value < Iterations : false;
        }

        protected override ElementType ExecuteInternal(long iteration)
        {
            ElementType value = _randomFunc();
            if(_intervals != null)
            {
                value = FindInterval(value);
            }
            Register(value);
            return value;
        }

        protected ElementType FindInterval(ElementType value)
        {
            int intervalIdx;
            for(intervalIdx = 0; intervalIdx < _intervals.Count-1; ++intervalIdx)
            {
                if (intervalIdx < _intervals.Count - 1)
                {
                    ElementType current = _intervals[intervalIdx];
                    ElementType next = _intervals[intervalIdx + 1];
                    if (value.CompareTo(current) >= 0 && value.CompareTo(next) < 0)
                    {
                        break;
                    }
                }
            }
            return _intervals[intervalIdx];
        }

        private Func<ElementType> _randomFunc;
        private List<ElementType> _intervals;
    }
}
