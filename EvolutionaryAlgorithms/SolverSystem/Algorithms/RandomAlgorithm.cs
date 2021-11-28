using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithms.SolverSystem.Algorithms
{
    class RandomAlgorithm : Algorithm
    {
        
        public double StandardDeviation
        {get;set;}
        public double AverageFitness
        { get; set; }

        private double _worstFitness;

        public double WorstFitness
        {
            get { return _worstFitness; }
            private set { _worstFitness = value; }
        }
        public int NumberOfRuns
        { get; private set; }

        public RandomAlgorithm(int numberOfRuns) 
        {
            NumberOfRuns = numberOfRuns;
            _worstFitness = Double.MinValue;
        }

        public override void run()
        {
            List<double> fitnesses= new List<double>();
            List<int> individual;
            int fitness = 0;

            for (int counterOfRuns = 0; counterOfRuns < NumberOfRuns; counterOfRuns++)
            {
                individual = generateIndividual();
                fitness = (int) calculateFitness(individual);
                fitnesses.Add(fitness);

                if (fitness < BestFitness)
                {
                    bestSolution = individual;
                    bestFitness = fitness;
                }

                if (fitness > _worstFitness)
                {
                    _worstFitness = fitness;
                }
            }

            AverageFitness = fitnesses.Select(f => f).Sum() / fitnesses.Count();
            StandardDeviation =  Math.Sqrt(fitnesses.Select(f => Math.Pow(f - AverageFitness, 2)).Sum() / fitnesses.Count); 
           
            //displaySolution();
        }

    }
}
