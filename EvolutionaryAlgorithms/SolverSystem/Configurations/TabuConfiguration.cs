using EvolutionaryAlgorithms.SolverSystem.Configurations.Common;
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
        
        public double SizeOfTabuList
        { get; private set; }

        public int NumberOfNeighbors
        { get; private set; }

        public MutationType MutationType { get; private set; }

        public double SwapProbability { get; private set; }

        public TabuConfiguration(AlgorithmType algorithmType, int numberOfAlgorithmRuns, int numberOfIterations, double sizeOfTabuList,
            int numberOfNeighbors, MutationType mutationType, double swapProbability = 0) : base(algorithmType)
        {
            NumberOfAlgorithmRuns = numberOfAlgorithmRuns;
            NumberOfIterations = numberOfIterations;
            SizeOfTabuList = sizeOfTabuList;
            NumberOfNeighbors = numberOfNeighbors;
            MutationType = mutationType;
            SwapProbability = swapProbability;
        }

    }
}
