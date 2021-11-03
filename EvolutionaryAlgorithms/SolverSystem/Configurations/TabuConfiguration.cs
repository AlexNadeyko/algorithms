using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithms.SolverSystem.Configurations
{
    class TabuConfiguration : SolverConfiguration
    {
        public int NumberOfAlgorithmRuns
        { get; private set; }

        public int NumberOfIterations
        { get; private set; }
        
        public int SizeOfTabuList
        { get; private set; }

        public int NumberOfNeighbors
        { get; private set; }

        public TabuConfiguration(AlgorithmType algorithmType, int numberOfAlgorithmRuns, int numberOfIterations, int sizeOfTabuList,
            int numberOfNeighbors) : base(algorithmType)
        {
            NumberOfAlgorithmRuns = numberOfAlgorithmRuns;
            NumberOfIterations = numberOfIterations;
            SizeOfTabuList = sizeOfTabuList;
            NumberOfNeighbors = numberOfNeighbors;
        }

    }
}
