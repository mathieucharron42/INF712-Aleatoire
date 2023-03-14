using System;
using System.Collections.Generic;

namespace Aleatoire_Common
{
    public interface IRandomWorkbench<ValueType>
    {
        string Name { get; }
        long Iterations { get; }
        DateTime ExecutionStart { get; }
        DateTime ExecutionEnd { get; }
        Dictionary<ValueType, long> Occurences { get; }
    }
}
