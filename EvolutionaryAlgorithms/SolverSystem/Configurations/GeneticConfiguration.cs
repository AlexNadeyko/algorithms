using EvolutionaryAlgorithms.SolverSystem.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithms.SolverSystem.Configurations
{
    class GeneticConfiguration : SolverConfiguration
    {
        public int NumberOfAlgorithmRuns
        { get; private set; }

        public int NumberOfPopulations
        { get; private set; }

        public int NumberOfIndividuals
        { get; private set; }

        public CrossoverType CrossoverType
        { get; private set; }

        public double MutationProbaility
        { get; private set; }

        public double CrossoverProbability
        { get; private set; }

        public GeneticConfiguration(AlgorithmType algorithmType, int numberOfAlgorithmRuns, int numberOfPopulations, int numberOfIndividuals,
            CrossoverType crossoverType, double crossoverProbability, double mutationProbaility) : base(algorithmType)
        {
            NumberOfAlgorithmRuns = numberOfAlgorithmRuns;
            NumberOfPopulations = numberOfPopulations;
            NumberOfIndividuals = numberOfIndividuals;
            CrossoverType = crossoverType;
            CrossoverProbability = crossoverProbability;
            MutationProbaility = mutationProbaility;
        }

    }
}
