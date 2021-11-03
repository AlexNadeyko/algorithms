using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithms.SolverSystem.Configurations
{
    public class SimulatedAnnealingConfiguration : SolverConfiguration
    {
        public double InitialTemperature { get; init; }
        public int NumberOfIterations { get; init; }
        public int NumberOfRuns { get; init; }

        public SimulatedAnnealingConfiguration(int numberOfRuns, int numberOfIterations, double initialTemperature) : base(AlgorithmType.SIMULATED_ANNEALING)
        {
            InitialTemperature = initialTemperature;
            NumberOfIterations = numberOfIterations;
            NumberOfRuns = numberOfRuns;
        }

    }
}
