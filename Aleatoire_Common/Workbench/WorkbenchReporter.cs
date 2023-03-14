using Aleatoire_Common;
using System;
using System.Collections.Generic;

namespace ValeurAleatoire_Common
{
    public class WorkbenchReporter : IDisposable
    {
        public void WriteExecutionBegin<ValueType>(IRandomWorkbench<ValueType> workbench)
        {
            Console.WriteLine("Executing '{0}'", workbench.Name);
        }
        
        public void WriteExecutionEnd<ValueType>(IRandomWorkbench<ValueType> workbench)
        {
            WriteMetrics(workbench.Iterations, workbench.ExecutionEnd - workbench.ExecutionStart);
            WriteProbability(workbench.Occurences, workbench.Iterations);
            Console.WriteLine();
        }

        private static void WriteMetrics(long iterations, TimeSpan timeSpan)
        {
            Console.WriteLine("{0} iterations in {1} ms", iterations, timeSpan.TotalMilliseconds);
        }

        private static void WriteProbability<ValueType>(Dictionary<ValueType, long> occurences, long iterations)
        {
            string HEADER_ELEMENT = "Element";
            string HEADER_OCCURENCE = "Occurence";
            string HEADER_PROBABILITY = "Probability";
            string HEADER_REPRESENTATION = "Representation";
            List<string> kHEADERS = new List<string>() { HEADER_ELEMENT, HEADER_OCCURENCE, HEADER_PROBABILITY, HEADER_REPRESENTATION };

            int maximumCharacter = occurences.Count * 5;

            List<List<string>> rows = new List<List<string>>();
            foreach (var entry in new SortedDictionary<ValueType, long>(occurences))
            {
                double probability = entry.Value / (double)iterations;

                List<string> values = new List<string>();
                foreach (string row in kHEADERS)
                {
                    string value = null;
                    if (row == HEADER_ELEMENT)
                    {
                        value = entry.Key.ToString();
                    }
                    else if (row == HEADER_OCCURENCE)
                    {
                        value = entry.Value.ToString();
                    }
                    else if (row == HEADER_PROBABILITY)
                    {
                        value = probability.ToString("0.00000000000");
                    }
                    else if (row == HEADER_REPRESENTATION)
                    {
                        
                        value = new string('>', (int)(probability* maximumCharacter));
                    }
                    values.Add(value);
                }
                rows.Add(values);
            }

            TableWriter.ConsoleWrite(kHEADERS, rows);
        }

        public void Dispose()
        {
            
        }
    }
}
