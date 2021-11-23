using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithms.SolverSystem.Algorithms
{
    enum CrossoverType
    {
        CYCLE_CROSSOVER,
        ORDERED_CROSSOVER
    }

    class GeneticAlgorithm : Algorithm
    {
        public int NumberOfRuns
        { get; private set; }
        public int NumberOfPopulations
        { get; private set; }

        public int NumberOfIndividuals
        { get; private set; }

        public double MutationProbability
        { get; private set; }

        public double CrossoverProbability
        { get; private set; }

        private List<List<int>> _population;

        public CrossoverType CrossoverType
        { get; private set; }
        public List<double> BestFitnesses
        { get; set; }

        public List<double> bestFitnessesInPopulations;

        public List<double> worstFitnessesInPopulations;

        public List<double> averageFitnessesInPopulations;

        private readonly Random _random;


        public GeneticAlgorithm(int numberOfRuns, int numberOfPopulations, int numberOfIndividuals, double mutationProbability, double crossoverProbability,
            CrossoverType crossoverType)
        {
            NumberOfRuns = numberOfRuns;
            NumberOfPopulations = numberOfPopulations;
            NumberOfIndividuals = numberOfIndividuals;
            MutationProbability = mutationProbability;
            CrossoverProbability = crossoverProbability;
            CrossoverType = crossoverType;

            _population = new List<List<int>>();

            _random = new Random();

            bestFitnessesInPopulations = new List<double>();
            worstFitnessesInPopulations = new List<double>();
            averageFitnessesInPopulations = new List<double>();
            BestFitnesses = new List<double>();
        }

        public override void run()
        {
            int counter = 0;

            int numberOfPopulations;

            List<List<int>> newPopulation = new List<List<int>>();
            List<int> individualAfterCrossover = null;
            List<int> firstChildAfterCrossover;
            List<int> secondChildAfterCrossover;
            //Random random = new Random();
            List<List<int>> selection = null;

            for (int iteration = 0; iteration < NumberOfRuns; iteration++)
            {
                numberOfPopulations = NumberOfPopulations;

                initializePopulation();
                evaluateIndividuals();

                counter++;

                if (CrossoverType == CrossoverType.CYCLE_CROSSOVER)
                {
                    while (numberOfPopulations > 0)
                    {
                        selection = tournamentSelection(5, _population.Count);

                        if (selection.Count % 2 != 0)
                        {
                            selection.Add(_population[_random.Next(0, _population.Count)]);
                        }

                        for (int j = 0; j < selection.Count; j += 2)
                        {

                            if (_random.NextDouble() < CrossoverProbability)
                            {
                                (firstChildAfterCrossover, secondChildAfterCrossover) = cycleCrossover(selection[j], selection[j + 1]);

                                repairIndividual(firstChildAfterCrossover);
                                repairIndividual(secondChildAfterCrossover);
                            }
                            else
                            {
                                firstChildAfterCrossover = new List<int>(selection[j]);
                                secondChildAfterCrossover = new List<int>(selection[j + 1]);
                            }

                            //swapMutation(selection[j]);
                            //swapMutation(selection[j + 1]);

                            if (_random.NextDouble() < MutationProbability)
                            {
                                inversionMutation(firstChildAfterCrossover);
                                repairIndividual(firstChildAfterCrossover);
                            }

                            if (_random.NextDouble() < MutationProbability)
                            {
                                inversionMutation(secondChildAfterCrossover);
                                repairIndividual(secondChildAfterCrossover);
                            }

                            newPopulation.Add(firstChildAfterCrossover);
                            newPopulation.Add(secondChildAfterCrossover);
                        }

                        newPopulation[newPopulation.Count - 1] = new List<int>(bestSolution);

                        _population.Clear();
                        _population.AddRange(newPopulation);
                        newPopulation.Clear();
                        
                        evaluateIndividuals();

                        numberOfPopulations--;
                    }
                }
                else
                {
                    while (numberOfPopulations > 0)
                    {
                        //List<int> selection = rouletteSelection();
                        selection = tournamentSelection(5, _population.Count * 2);

                        for (int j = 0; j < selection.Count(); j += 2)
                        {                        
                            if (_random.NextDouble() < CrossoverProbability)
                            {
                                individualAfterCrossover = orderedCrossover(selection[j], selection[j + 1]);
                                repairIndividual(individualAfterCrossover);
                            }
                            else
                            {
                                individualAfterCrossover = new List<int>(selection[j]);
                            }

                            if (_random.NextDouble() < MutationProbability)
                            {
                                inversionMutation(individualAfterCrossover);
                                //swapMutation(individualAfterCrossover);
                                repairIndividual(individualAfterCrossover);
                            }

                            newPopulation.Add(individualAfterCrossover);
                        }

                        _population.Clear();
                        _population.AddRange(newPopulation);
                        newPopulation.Clear();

                        evaluateIndividuals();
                         
                        numberOfPopulations--;
                    }
                }

                //displaySolution();
                BestFitnesses.Add(BestFitness);

                Console.WriteLine(counter);
                newPopulation.Clear();
                _population.Clear();
                //bestFitnessesInPopulations.Clear();
                bestFitness = int.MaxValue;
            }
 
        }

        private void initializePopulation() 
        {
            for (int counterOfIndividuals = 0; counterOfIndividuals < NumberOfIndividuals; counterOfIndividuals++)
            {
                _population.Add(generateIndividual());
            }  
        }

        private void evaluateIndividuals()
        {
            int fitness;
            double bestLocalFintess = Double.MaxValue;
            double worstLocalFitness = Double.MinValue;
            double sumFitness = 0;

            foreach (List<int> individual in _population)
            {
                fitness = calculateFitness(individual);
                sumFitness += fitness;

                if (fitness < bestLocalFintess)
                {
                    bestLocalFintess = fitness;
                }

                if (fitness > worstLocalFitness)
                {
                    worstLocalFitness = fitness;
                }

                if (fitness < BestFitness) 
                {
                    bestFitness = fitness;
                    bestSolution = individual;
                    //Console.WriteLine(BestFitness);
                }
            }

            bestFitnessesInPopulations.Add(bestLocalFintess);
            worstFitnessesInPopulations.Add(worstLocalFitness);
            averageFitnessesInPopulations.Add(sumFitness / _population.Count());
        }

        private List<List<int>> tournamentSelection(int tournamentSize, int numberOfIndividualsToSelect)
        {
            var winnersOfTournaments = new List<List<int>>(numberOfIndividualsToSelect);
            //Random random = new Random();
            for (int i = 0; i < numberOfIndividualsToSelect; i++)
            {
                var tournamentResult = _population.OrderBy(_ => _random.Next())
                    .Take(tournamentSize)
                    .Select(i => new { solution = i, fitness = calculateFitness(i) })
                    .OrderBy(x => x.fitness)
                    .Select(x => x.solution)
                    .First();

                winnersOfTournaments.Add(tournamentResult);
            }

            return winnersOfTournaments;

            //List<List<int>> winnersOfTournaments = new List<List<int>>();
            //List<List<int>> individualsForChoose = _population.Select(individual => new List<int>(individual)).ToList();
            //List<List<int>> selectedIndividuals = new List<List<int>>();
            //double bestFitness = Double.MaxValue;
            //List<int> bestIndividual = null;
            //double fitness;
            //Random random = new Random();
            //int randomIndex = 0;

            //for (int counterOfTournaments = 0; counterOfTournaments < numberOfIndividualsToSelect; counterOfTournaments++)
            //{
            //    for (int countOfSelectedIndividuals = 0; countOfSelectedIndividuals < tournamentSize; countOfSelectedIndividuals++)
            //    {
            //        randomIndex = random.Next(0, individualsForChoose.Count);
            //        selectedIndividuals.Add(individualsForChoose[randomIndex]);
            //        individualsForChoose.RemoveAt(randomIndex);
            //    }

            //    foreach (List<int> individual in selectedIndividuals)
            //    {
            //        fitness = calculateFitness(individual);

            //        if (fitness < bestFitness)
            //        {
            //            bestFitness = fitness;
            //            bestIndividual = individual;
            //        }
            //    }

            //    winnersOfTournaments.Add(bestIndividual);
            //    individualsForChoose.Clear();
            //    individualsForChoose = _population.Select(individual => new List<int>(individual)).ToList();
            //    selectedIndividuals.Clear();
            //    bestFitness = Double.MaxValue;
            //}
            //return winnersOfTournaments;
        }

        private List<int> rouletteSelection()
        {
            double totalFitness = 0;
            List<(double, double)> probabilitiesBorders = new List<(double, double)>();
            double leftBorder = 0;
            double rightBorder = 0;
            Random random = new Random();
            double randomNumber = 0;
            int indexOfMatchedIndividual;

            totalFitness = _population.Select(i => 1 / calculateFitness(i)).Sum();
            rightBorder = (1 / calculateFitness(_population[0])) / totalFitness;

            for (int i = 0; i < _population.Count() - 1; i++)
            {
                probabilitiesBorders.Add((leftBorder, rightBorder));
                leftBorder += (1 / calculateFitness(_population[i])) / totalFitness;
                rightBorder += (1 / calculateFitness(_population[i + 1])) / totalFitness;
            }

            probabilitiesBorders.Add((leftBorder, 1));
            randomNumber = random.NextDouble();
            indexOfMatchedIndividual = probabilitiesBorders.FindIndex(b => randomNumber > b.Item1 && randomNumber <= b.Item2);

            return _population[indexOfMatchedIndividual];
        }

        private void swapMutation(List<int> individual)
        {
            //Random random = new Random();
            int randomIndex = 0;
            int secondRandomIndex;
            int tempCityNode;

            individual.RemoveAll(n => n == DepotNode);
            
            for (int index = 0; index < individual.Count(); index++)
            {
                if (_random.NextDouble() < MutationProbability)
                {
                    randomIndex = _random.Next(0, individual.Count());
                    tempCityNode = individual[randomIndex];
                    individual[randomIndex] = individual[index];
                    individual[index] = tempCityNode;
                }
            }

            //repairIndividual(individual);
        }

        private void inversionMutation(List<int> individual)
        {
            List<int> inversionPart;
            //Random random = new Random();
            int firstRandomIndex;
            int secondRandomIndex;

            individual.RemoveAll(n => n == DepotNode);
            
            firstRandomIndex = _random.Next(0, individual.Count() - 1);
            secondRandomIndex = _random.Next(firstRandomIndex + 1, individual.Count());

            inversionPart = individual.GetRange(firstRandomIndex, secondRandomIndex - firstRandomIndex + 1);
            individual.RemoveRange(firstRandomIndex, secondRandomIndex - firstRandomIndex + 1);
            inversionPart.Reverse();

            individual.InsertRange(firstRandomIndex, inversionPart);
        }

        private List<int> orderedCrossover(List<int> firstParentParam, List<int> secondParentParam)
        {
            List<int> firstParent = new List<int>(firstParentParam);
            List<int> secondParent = new List<int>(secondParentParam);
            firstParent.RemoveAll(n => n == DepotNode);
            secondParent.RemoveAll(n => n == DepotNode);

            List<int> child = new List<int>(new int[firstParent.Count]);
            //Random random = new Random();
            int leftBorderIndex = _random.Next(0, firstParent.Count() - 1);
            int rightBorderIndex = _random.Next(leftBorderIndex, firstParent.Count());
            int positionIndexSecondParent = 0;

            child.RemoveRange(leftBorderIndex, rightBorderIndex - leftBorderIndex + 1);
            child.InsertRange(leftBorderIndex, firstParent.GetRange(leftBorderIndex, rightBorderIndex - leftBorderIndex + 1));

            for (int i = 0; i < leftBorderIndex; i++)
            {
                while (child.Contains(secondParent[positionIndexSecondParent]) )
                {
                    positionIndexSecondParent++;
                }

                child[i] =  secondParent[positionIndexSecondParent];
            }

            for (int j = rightBorderIndex + 1; j < child.Count(); j++)
            {
                while (child.Contains(secondParent[positionIndexSecondParent]))
                {
                    positionIndexSecondParent++;
                }

                child[j] =  secondParent[positionIndexSecondParent];
            }

            return child;
        }

        private (List<int> firstChild, List<int> secondChild) cycleCrossover(List<int> firstParentParam, List<int> secondParentParam)
        {
            List<int> firstParent = new List<int>(firstParentParam);
            List<int> secondParent = new List<int>(secondParentParam);
            firstParent.RemoveAll(n => n == DepotNode);
            secondParent.RemoveAll(n => n == DepotNode);

            List<int> firstChild = new List<int>(new int[firstParent.Count]);
            List<int> secondChild = new List<int>(new int[firstParent.Count]);
            int cycleCounter = 0;
            List<int> selectedIndexes = new List<int>();
           
            int actualIndex = 0;
            int nextNodeToFind;
            bool isFinishCycle = false;
            
            List<int> passedIndexes = new List<int>();

            while (true)
            {
                if (passedIndexes.Contains(actualIndex))
                {
                    if (passedIndexes.Count() != firstParent.Count())
                    {
                        actualIndex++;
                        continue;
                    }
                    break;
                }

                if (actualIndex == firstParent.Count())
                {
                    break;
                }

                cycleCounter++;

                if (secondParent[actualIndex] == firstParent[actualIndex])
                {
                    passedIndexes.Add(actualIndex);
                    selectedIndexes.Add(actualIndex);
                }
                else
                {
                    passedIndexes.Add(actualIndex);
                    selectedIndexes.Add(actualIndex);
                    nextNodeToFind = secondParent[actualIndex];

                    while (!isFinishCycle)
                    {
                        for (int indexFirstParent = 0; indexFirstParent < firstParent.Count(); indexFirstParent++)
                        {
                            if (firstParent[indexFirstParent] == nextNodeToFind)
                            {
                                if (selectedIndexes.Contains(indexFirstParent))
                                {
                                    isFinishCycle = true;
                                    break;
                                }
                                else 
                                {
                                    passedIndexes.Add(indexFirstParent);
                                    selectedIndexes.Add(indexFirstParent);
                                    nextNodeToFind = secondParent[indexFirstParent];
                                    break;
                                }
                               
                            }
                        } 
                    }

                    isFinishCycle = false;
                }

                if (cycleCounter % 2 != 0)
                {
                    foreach (int index in selectedIndexes)
                    {
                        firstChild[index] = firstParent[index];
                    }

                    foreach (int index in selectedIndexes)
                    {
                        secondChild[index] = secondParent[index];
                    }
                }
                else
                {
                    foreach (int index in selectedIndexes)
                    {
                        firstChild[index] = secondParent[index];
                    }

                    foreach (int index in selectedIndexes)
                    {
                        secondChild[index] = firstParent[index];
                    }
                }

                actualIndex++;
                selectedIndexes.Clear();
            }

            return (firstChild, secondChild);
        }

        private void repairIndividual(List<int> individual)
        {
            int actualCargo = 0;
            int numberNodesToCheck = individual.Count;
            int indexOfNode = 1;

            individual.Insert(0, DepotNode);

            while (numberNodesToCheck != 0)
            {
                if (actualCargo + DemandsOfNodes[individual[indexOfNode]] > Capacity)
                {
                    individual.Insert(indexOfNode, DepotNode);
                    indexOfNode++;
                    actualCargo = 0;
                }

                actualCargo += DemandsOfNodes[individual[indexOfNode]];
                numberNodesToCheck--;
                indexOfNode++;
            }

            individual.Add(DepotNode);
        }
    }
}
