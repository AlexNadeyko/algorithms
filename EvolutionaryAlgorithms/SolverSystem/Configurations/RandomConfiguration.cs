using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithms.SolverSystem.Configurations
{
    class RandomConfiguration : SolverConfiguration
    {
        public int NumberOfAlgorithmRuns
        { get; private set; }

        public RandomConfiguration(AlgorithmType algorithmType, int numberOfAlgorithmRuns) : base(algorithmType)
        {
            NumberOfAlgorithmRuns = numberOfAlgorithmRuns;
        }

    }
}
