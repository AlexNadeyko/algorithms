using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithms.SolverSystem
{
    public enum AlgorithmType
    {
        RANDOM,
        GREEDY,
        GENETIC,
        TABU_SEARCH,
        SIMULATED_ANNEALING
    }
    public abstract class Algorithm
    {

        public int DepotNode 
        { get; set; }

        public int[,] DestinationMatrix
        { get; set; }

        public int[] CityToVisitNodes
        { get; set; }

        public int[] DemandsOfNodes
        { get;  set; }

        public int Capacity
        { get; set; }
        
        public int Dimension
        { get; set; }
        public string NameOfProblem
        { get; set; }

        protected List<int> bestSolution;

        protected int bestFitness = int.MaxValue;
        public int BestFitness
        { 
            get { return bestFitness; }
            protected set { bestFitness = value; } 
        }
        
        //public List<double> BestFitnesses;

        protected Algorithm() 
        {
            //BestFitnesses = new List<double>();
        }

        public abstract void run();

        public int calculateFitness(List<int> individual)
        {
            int fitness = 0;

            for (int nodeIndex = 0; nodeIndex < individual.Count - 1; nodeIndex++)
            {
                fitness += DestinationMatrix[individual[nodeIndex], individual[nodeIndex + 1]];
            }

            return fitness;
        }

        protected virtual List<int> generateIndividual()
        {
            List<int> individual = new List<int>();
            List<int> citiesToVisit;
            double swapProbability = 0.5;
            Random random = new Random();
            int tempNode;
            int nextNodeToVisit;
            int actualCargo = 0;

            for (int nodeIndex = 0; nodeIndex < CityToVisitNodes.Length - 1; nodeIndex++)
            {
                if (random.NextDouble() > swapProbability)
                {
                    tempNode = CityToVisitNodes[nodeIndex];
                    CityToVisitNodes[nodeIndex] = CityToVisitNodes[nodeIndex + 1];
                    CityToVisitNodes[nodeIndex + 1] = tempNode;
                }
            }

            citiesToVisit = new List<int>(CityToVisitNodes);

            individual.Add(DepotNode);

            while (citiesToVisit.Count != 0)
            {
                nextNodeToVisit = citiesToVisit[random.Next(0, citiesToVisit.Count())];

                if (actualCargo + DemandsOfNodes[nextNodeToVisit] <= Capacity)
                {
                    individual.Add(nextNodeToVisit);
                    actualCargo += DemandsOfNodes[nextNodeToVisit];
                    citiesToVisit.Remove(nextNodeToVisit);
                }
                else 
                {
                    individual.Add(DepotNode);
                    actualCargo = 0;
                }
            }
            individual.Add(DepotNode);

            return individual;
        }

        protected void displayIndividual(List<int> individual)
        {
            int counterOfRoutes = 0;

            Console.WriteLine($"Result for problem - {NameOfProblem}");

            for(int nodeIndex = 0; nodeIndex < individual.Count() - 1; nodeIndex++)
            {
                if (individual[nodeIndex] == DepotNode)
                {
                    Console.Write($"\nRoute #{++counterOfRoutes}: ");
                    continue;
                }

                Console.Write($"{individual[nodeIndex]} ");
            }
            Console.WriteLine();
        }

        protected void displaySolution()
        {
            Console.WriteLine("#########################");
            //displayIndividual(bestIndividual);
            Console.WriteLine($"Fitness: {BestFitness}");
            Console.WriteLine("#########################");
        }
    }
}
