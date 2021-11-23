using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithms.SolverSystem.Algorithms
{
    class TabuSearchAlgorithm : Algorithm
    {
        public int NumberOfRuns
        { get; private set; }
        public List<int> BestFitnesses
        { get; set; }

        private readonly int _numberOfIterations;

        private readonly int _tabuListSize;

        private readonly int _numberOfNeighbors;

        public List<int> bestFitnessesInPopulations;

        public List<int> worstFitnessesInPopulations;

        public List<double> averageFitnessesInPopulations;

        public List<int> currentFitnessesInPopulations;

        int bestLocalFintess = int.MaxValue;

        int worstLocalFitness = int.MinValue;

        private readonly Random _random;

        public TabuSearchAlgorithm(int numberOfRuns, int numberOfIterations, int tabuListSize, int numberOfNeighbors)
        {
            NumberOfRuns = numberOfRuns;
            _numberOfIterations = numberOfIterations;
            _tabuListSize = tabuListSize;
            _numberOfNeighbors = numberOfNeighbors;

            BestFitnesses = new List<int>();

            _random = new Random();

            bestFitnessesInPopulations = new List<int>();
            worstFitnessesInPopulations = new List<int>();
            averageFitnessesInPopulations = new List<double>();
            currentFitnessesInPopulations = new List<int>();
            
        }

        public override void run()
        {
            List<int> currentSolution;
            List<string> tabuList = new List<string>(_tabuListSize);
            List<List<int>> neighbors;
            List<int> bestNeighbor;
            double bestNeighborFitness;

            for (int counterOfRuns = 0; counterOfRuns < NumberOfRuns; counterOfRuns++)
            {
                currentSolution = generateIndividual();
                //evaluateSolution(currentSolution);
                tabuList.Add(string.Join(",", currentSolution));
                BestFitness = calculateFitness(currentSolution);

                bestFitnessesInPopulations.Add(BestFitness);
                currentFitnessesInPopulations.Add(BestFitness);
                averageFitnessesInPopulations.Add(BestFitness);
                worstFitnessesInPopulations.Add(BestFitness);

                for (int counterOfIterations = 0; counterOfIterations < _numberOfIterations; counterOfIterations++)
                {
                    neighbors = findNeighbors(currentSolution);
                    currentSolution = neighbors
                        .Select(s => new { fitness = calculateFitness(s), strRepresentation = string.Join(",", s), solution = s })
                        .OrderBy(x => x.fitness)
                        .Where(x => !tabuList.Contains(x.strRepresentation))
                        .Select(x => x.solution)
                        .FirstOrDefault();

                    currentSolution ??= neighbors[0];
                    var currentFitness = calculateFitness(currentSolution);

                    if (currentFitness < BestFitness)
                    {
                        BestFitness = currentFitness;
                        bestSolution = new List<int>(currentSolution);
                    }

                    tabuList.Add(string.Join(",", currentSolution));

                    if (tabuList.Count > _tabuListSize)
                    {
                        tabuList.RemoveAt(0);
                    }

                    //dd

                    //neighbors.RemoveAll(n => tabuList.Contains(string.Join(",", n)));

                    analyzeNeighbors(neighbors);

                    //(bestNeighbor, bestNeighborFitness) = findBestNeighbor(neighbors);

                    //if (bestNeighborFitness < BestFitness)
                    //{
                    //    bestFitness = bestNeighborFitness;
                    //    bestSolution = bestNeighbor;

                    //    //Console.WriteLine($"Found better solution = {BestFitness}");
                    //}

                    //currentSolution = bestNeighbor;

                    //if (tabuList.Count == _tabuListSize)
                    //{
                    //    tabuList.RemoveAt(0);
                    //}

                    //tabuList.Add(string.Join(",", currentSolution));

                    bestFitnessesInPopulations.Add(bestFitness);
                    currentFitnessesInPopulations.Add(currentFitness);
                }

                //Console.WriteLine($"Best solution for iteration = {bestFitness}");
                tabuList.Clear();
                BestFitnesses.Add(BestFitness);
            }
        }

        private void evaluateSolution(List<int> solution)
        {
            int fitness = calculateFitness(solution);

            if(fitness < BestFitness)    
            {
                bestSolution = solution;
                bestFitness = fitness;
            }
        }

        private List<List<int>> findNeighbors(List<int> currentSolution) 
        {
            List<List<int>> neighbors = new List<List<int>>(_numberOfNeighbors);

            for (int i = 0; i < _numberOfNeighbors; i++)
            {
                var currentSolutionClone = new List<int>(currentSolution);

                inversion(currentSolutionClone);
                //swapMutation(currentSolutionClone);

                repairSolution(currentSolutionClone);
                neighbors.Add(currentSolutionClone);
            }

            return neighbors;

            //List<List<int>> neighbors = new List<List<int>>(_numberOfNeighbors);
            //HashSet<string> controlList = new HashSet<string>(_numberOfNeighbors);
            //List<int> neighborSolution;
            //List<int> cloneSolution = new List<int>(solution);
            //string representationOfSolution;

            //while (controlList.Count < _numberOfNeighbors)
            //{
            //    inversion(cloneSolution);
            //    repairSolution(cloneSolution);
            //    representationOfSolution = string.Join(",", cloneSolution);

            //    if (!controlList.Contains(representationOfSolution))
            //    {
            //        controlList.Add(representationOfSolution);
            //        neighbors.Add(cloneSolution);
            //    }

            //    cloneSolution = new List<int>(solution);
            //}

            //return neighbors;
        }

        private (List<int>, double) findBestNeighbor(List<List<int>> neighbors)
        {
            List<int> bestNeighbor = null;
            double bestFitness = Double.MaxValue;
            double fitness;

            foreach(List<int> neighbor in neighbors)
            {
                fitness = calculateFitness(neighbor);

                if (fitness < bestFitness)
                {
                    bestFitness = fitness;
                    bestNeighbor = neighbor;
                }

               

                
            }

            

            return (bestNeighbor, bestFitness);
        }

        private void analyzeNeighbors(List<List<int>> neighbors)
        {
            int worstFitness = int.MinValue;
            int fitness;
            int totalFitness = 0;

            foreach (List<int> neighbor in neighbors)
            {
                fitness = calculateFitness(neighbor);

                totalFitness += fitness;

                if (fitness > worstFitness)
                {
                    worstFitness = fitness;
                }
            }

            worstFitnessesInPopulations.Add(worstFitness);
            averageFitnessesInPopulations.Add(totalFitness / neighbors.Count());
        }

        private void inversion(List<int> solution)
        {
            //Random random = new Random();
            ////var result = new List<int>(solution);
            //solution.RemoveAll(n => n == DepotNode);
            //var idx1 = 0;
            //var idx2 = 0;

            //while (idx1 == idx2)
            //{
            //    idx1 = random.Next(solution.Count);
            //    idx2 = random.Next(solution.Count);
            //}

            //if (idx1 > idx2)
            //{
            //    (idx1, idx2) = (idx2, idx1);
            //}

            //while (idx1 < idx2)
            //{
            //    (solution[idx1], solution[idx2]) = (solution[idx2], solution[idx1]);

            //    idx1++;
            //    idx2--;
            //}



            List<int> inversionPart;
            //Random random = new Random();
            int firstRandomIndex;
            int secondRandomIndex;

            //
            solution.RemoveAll(n => n == DepotNode);
            //

            firstRandomIndex = _random.Next(0, solution.Count - 1);
            secondRandomIndex = _random.Next(firstRandomIndex + 1, solution.Count);

            inversionPart = solution.GetRange(firstRandomIndex, secondRandomIndex - firstRandomIndex + 1);
            solution.RemoveRange(firstRandomIndex, secondRandomIndex - firstRandomIndex + 1);
            inversionPart.Reverse();

            solution.InsertRange(firstRandomIndex, inversionPart);
        }

        private void swapMutation(List<int> solution)
        {
            //Random random = new Random();
            int randomIndex = 0;
            int secondRandomIndex;
            int tempCityNode;

            solution.RemoveAll(n => n == DepotNode);

            for (int index = 0; index < solution.Count(); index++)
            {
                if (_random.NextDouble() < 0.04)
                {
                    randomIndex = _random.Next(0, solution.Count());
                    tempCityNode = solution[randomIndex];
                    solution[randomIndex] = solution[index];
                    solution[index] = tempCityNode;
                }
            }

            //repairIndividual(individual);
        }

        private void repairSolution(List<int> solution)
        {
            int actualCargo = 0;
            int numberNodesToCheck = solution.Count;
            int indexOfNode = 1;

            solution.Insert(0, DepotNode);

            while (numberNodesToCheck != 0)
            {
                if (actualCargo + DemandsOfNodes[solution[indexOfNode]] > Capacity)
                {
                    solution.Insert(indexOfNode, DepotNode);
                    indexOfNode++;
                    actualCargo = 0;
                }

                actualCargo += DemandsOfNodes[solution[indexOfNode]];
                numberNodesToCheck--;
                indexOfNode++;
            }

            solution.Add(DepotNode);
        }

    }
}
