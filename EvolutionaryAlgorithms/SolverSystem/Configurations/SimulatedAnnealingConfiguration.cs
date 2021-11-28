using EvolutionaryAlgorithms.SolverSystem.Configurations.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithms.SolverSystem.Configurations
{
    public class SimulatedAnnealingConfiguration : SolverConfiguration
    {
        public double InitialTemperaturePercent { get; init; }
        public int NumberOfIterations { get; init; }
        public int NumberOfRuns { get; init; }
        public MutationType MutationType { get; private set; }
        public double SwapProbability { get; private set; }

        public SimulatedAnnealingConfiguration(int numberOfRuns, int numberOfIterations, double initialTemperature,
            MutationType mutationType, double swapProbability = 0) : base(AlgorithmType.SIMULATED_ANNEALING)
        {
            InitialTemperaturePercent = initialTemperature;
            NumberOfIterations = numberOfIterations;
            NumberOfRuns = numberOfRuns;
            MutationType = mutationType;
            SwapProbability = swapProbability;
        }

    }
}
