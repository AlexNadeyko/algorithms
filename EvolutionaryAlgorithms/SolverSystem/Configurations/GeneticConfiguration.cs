using EvolutionaryAlgorithms.SolverSystem.Algorithms;
using EvolutionaryAlgorithms.SolverSystem.Configurations.Common;
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

        public MutationType MutationType
        { get; private set; }

        public SelectionType SelectionType
        { get; private set; }

        public double TournamentSizePercentage
        { get; private set; }

        public GeneticConfiguration(AlgorithmType algorithmType, int numberOfAlgorithmRuns, int numberOfPopulations, int numberOfIndividuals,
            CrossoverType crossoverType, double crossoverProbability, MutationType mutationType, double mutationProbaility,
            SelectionType selectionType, double tournamentSizePercentage = 0) : base(algorithmType)
        {
            NumberOfAlgorithmRuns = numberOfAlgorithmRuns;
            NumberOfPopulations = numberOfPopulations;
            NumberOfIndividuals = numberOfIndividuals;
            CrossoverType = crossoverType;
            CrossoverProbability = crossoverProbability;
            MutationProbaility = mutationProbaility;
            MutationType = mutationType;
            SelectionType = selectionType;
            TournamentSizePercentage = tournamentSizePercentage;
        }

    }
}
