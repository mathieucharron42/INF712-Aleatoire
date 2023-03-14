using Aleatoire_Common;
using System;
using System.Collections.Generic;

namespace ValeurAleatoire_Common
{
    public class HumanRandomValueWorkbench<ElementType> : DrawRandomValueWorkbench<ElementType>
        where ElementType : struct, IComparable, IComparable<ElementType>, IConvertible, IEquatable<ElementType>, IFormattable
    {
        public HumanRandomValueWorkbench(string name, Func<ElementType> randomFunc, List<ElementType> intervals = null)
            : base(name, randomFunc, intervals)
        {

        }

        protected override bool IsDone(long? maxIterations, long iteration)
        {
            return _lastChoice == CHOICE_QUIT;
        }

        protected override ElementType ExecuteInternal(long iteration)
        {
            Console.WriteLine();
            List<string> CHOICES = new List<string>() { CHOICE_DRAW, CHOICE_QUIT };

            if (iteration > 0)
            {
                Console.WriteLine(Name);
            }

            Console.WriteLine("Operations:");
            Console.WriteLine(" -(D)raw");
            Console.WriteLine(" -(Q)uit");

            string choice = "";
            while (!CHOICES.Contains(choice))
            {
                Console.Write("Choice?: ");
                choice = Console.ReadLine().ToLower();
            }

            ElementType elementType = default(ElementType);

            if (choice == CHOICE_DRAW)
            {
                elementType = base.ExecuteInternal(iteration);
                Console.WriteLine("Drew '{0}'", elementType);
            }

            _lastChoice = choice;
            return elementType;
        }

        private const string CHOICE_DRAW = "d";
        private const string CHOICE_QUIT = "q";

        private string _lastChoice;
    }
}
