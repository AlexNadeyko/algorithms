using EvolutionaryAlgorithms.SolverSystem.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithms.SolverSystem
{
    public class SolverConfiguration
    {
        public AlgorithmType AlgorithmType
        { get; set; }

        //private int _depotNode;
        //public int DepotNode
        //{
        //    get { return _depotNode; }
        //    set { _depotNode = value - 1; }
        //}

        public SolverConfiguration(AlgorithmType algorithmType)
        {
            AlgorithmType = algorithmType;
        }

    }
}
