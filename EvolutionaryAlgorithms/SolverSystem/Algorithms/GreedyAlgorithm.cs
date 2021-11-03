using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithms.SolverSystem.Algorithms
{
    enum GreedySearchType
    {
        NEAREST,
        ALL
    }

    class GreedyAlgorithm : Algorithm
    {
        public List<double> Solutions
        { get; set; }

        public double NearestNodeFitness { get; private set; }
        public List<int> NearestSolution { get; private set; }

        public GreedySearchType SearchType { get; }

        public GreedyAlgorithm(GreedySearchType searchType) 
        {
            SearchType = searchType;
           
        }
        
        public override void run()
        {
            if (SearchType == GreedySearchType.NEAREST)
            {
                NearestSolution = generateIndividual();
                displayIndividual(NearestSolution);
                NearestNodeFitness = calculateFitness(NearestSolution);
                Console.WriteLine($"Fitness = {NearestNodeFitness}");
            }
            else
            {
                List<int> individual;
                double fitness;
                Solutions = new List<double>();

                for (int nodeToVisitIndex = 1; nodeToVisitIndex < Dimension; nodeToVisitIndex++)
                {
                    individual = generateIndividual(nodeToVisitIndex);
                    fitness = calculateFitness(individual);
                    displayIndividual(individual);
                    Console.WriteLine($"Fitness = {fitness}");
                    Solutions.Add(fitness);
                }

            }


            


            //for (int depot = 0; depot < Dimension; depot++)
            //{
            //    if (depot != 0)
            //    {
            //        changeDepot(depot);
            //    }

            //    individual = generateIndividual();
            //    fitness = calculateFitness(individual);
            //    displayIndividual(individual);

            //    Solutions.Add(fitness);
            //}

            //individual = generateIndividual();
            //fitness = calculateFitness(individual);
            //Solutions.Add(fitness);
        }

        protected override List<int> generateIndividual() 
        {
            List<int> individual = new List<int>();
            List<int> citiesToVisit = new List<int>(CityToVisitNodes);
            int nextCityToVisit;
            int actualCargo = 0;
            int actualCity = DepotNode;

            individual.Add(DepotNode);

            while (citiesToVisit.Count() != 0)
            {
                nextCityToVisit = findNearestCity(actualCity, citiesToVisit);

                if (actualCargo + DemandsOfNodes[nextCityToVisit] <= Capacity)
                {
                    individual.Add(nextCityToVisit);
                    actualCargo += DemandsOfNodes[nextCityToVisit];
                    citiesToVisit.Remove(nextCityToVisit);
                    actualCity = nextCityToVisit;
                }
                else
                {
                    individual.Add(DepotNode);
                    actualCargo = 0;
                    actualCity = DepotNode;
                }
            }

            individual.Add(DepotNode);

            return individual;
        }

        private List<int> generateIndividual(int secondNodeToVisit)
        {
            List<int> individual = new List<int>();
            List<int> citiesToVisit = new List<int>(CityToVisitNodes);
            int nextCityToVisit;
            int actualCargo = 0;
            int actualCity = DepotNode;

            individual.Add(DepotNode);

            while (citiesToVisit.Count() != 0)
            {
                if (citiesToVisit.Count() == Dimension - 1)
                {
                    nextCityToVisit = secondNodeToVisit;
                }
                else
                {
                    nextCityToVisit = findNearestCity(actualCity, citiesToVisit);
                }

                if (actualCargo + DemandsOfNodes[nextCityToVisit] <= Capacity)
                {
                    individual.Add(nextCityToVisit);
                    actualCargo += DemandsOfNodes[nextCityToVisit];
                    citiesToVisit.Remove(nextCityToVisit);
                    actualCity = nextCityToVisit;
                }
                else
                {
                    individual.Add(DepotNode);
                    actualCargo = 0;
                    actualCity = DepotNode;
                }
            }

            individual.Add(DepotNode);

            return individual;
        }

        private int findNearestCity(int actualCity, List<int> availableCities)
        {
            int nearestCity = actualCity;
            double minimalDistance = Double.MaxValue;

            foreach (int city in availableCities)
            {
                if (DestinationMatrix[actualCity, city] < minimalDistance)
                {
                    minimalDistance = DestinationMatrix[actualCity, city];
                    nearestCity = city;
                }
            }

            return nearestCity;
        }

        //private void changeDepot(int depot)
        //{
        //    CityToVisitNodes[depot - 1] = DepotNode;
        //    DemandsOfNodes[depot - 1] = DemandsOfNodes[depot];
        //    DemandsOfNodes[depot] = 0;
        //    DepotNode = depot;
        //}
    }
}
