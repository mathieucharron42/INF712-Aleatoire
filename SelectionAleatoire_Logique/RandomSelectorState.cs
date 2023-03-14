using System.Collections.Generic;

namespace SelectionAleatoire_Logique
{
    public class DrawnState
    {
        public HashSet<object> PreviousDraw { get; private set; }

        public DrawnState()
        {
            PreviousDraw = new HashSet<object>();
        }

        public override string ToString()
        {
            return string.Format("Previous={{{0}}}", string.Join(",", PreviousDraw));
        }
    }
}
