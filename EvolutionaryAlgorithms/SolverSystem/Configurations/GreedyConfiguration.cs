using EvolutionaryAlgorithms.SolverSystem.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithms.SolverSystem.Configurations
{
    class GreedyConfiguration : SolverConfiguration
    {
        public GreedySearchType SearchType { get; }
        
        public GreedyConfiguration(AlgorithmType algorithmType, GreedySearchType searchType) : base(algorithmType) 
        {
            SearchType = searchType;
        }
    }
}
