using System.Collections.Generic;
using System;

namespace SelectionAleatoire_Common.Workbench
{
    public class HumanRandomSelectorWorkbench<ElementType> : BaseRandomSelectorWorkbench<ElementType>
    {
        public HumanRandomSelectorWorkbench(string name, IRandomSelector<ElementType> selector)
            : base(name, selector)
        { }

        protected override bool IsDone(long? maxIterations, long iteration)
        {
            return _lastChoice == CHOICE_QUIT;
        }

        protected override ElementType ExecuteIterationOperation(long iteration, IRandomSelector<ElementType> selector)
        {
            Console.WriteLine();
            List<string> CHOICES = new List<string>() { CHOICE_SELECT, CHOICE_POP, CHOICE_RESET, CHOICE_QUIT };

            if (iteration > 0)
            {
                Console.WriteLine(selector.ToString(true));
            }

            Console.WriteLine("Operations:");
            Console.WriteLine(" -(S)elect");
            Console.WriteLine(" -(P)op");
            Console.WriteLine(" -(R)eset");
            Console.WriteLine(" -(Q)uit");

            ElementType value = default(ElementType);

            string choice = "";
            while (!CHOICES.Contains(choice))
            {
                Console.Write("Choice?: ");
                choice = Console.ReadLine().ToLower();
            }

            if (choice == CHOICE_SELECT)
            {
                value = selector.Select();
                Console.WriteLine("Element selected '{0}'", value);
            }
            else if (choice == CHOICE_POP)
            {
                value = selector.Pop();
                Console.WriteLine("Element poped '{0}'", value);
            }
            else if (choice == CHOICE_RESET)
            {
                selector.Reset();
                Console.WriteLine("Selector resetted");
            }
            else if (choice == CHOICE_QUIT)
            {
                // nothing to do
            }
            _lastChoice = choice;
            return value;
        }

        private const string CHOICE_SELECT = "s";
        private const string CHOICE_POP = "p";
        private const string CHOICE_RESET = "r";
        private const string CHOICE_QUIT = "q";

        private string _lastChoice;
    }
}
