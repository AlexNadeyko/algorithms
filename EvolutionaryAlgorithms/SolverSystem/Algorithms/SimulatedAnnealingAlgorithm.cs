using EvolutionaryAlgorithms.SolverSystem.Configurations.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithms.SolverSystem.Algorithms
{
    public class SimulatedAnnealingAlgorithm : Algorithm
    {
        private readonly double _initialTemperature;
        private readonly int _numberOfIterations;
        private readonly MutationType _mutationType;
        private readonly double _swapProbability;
        private int _numberOfRuns;
        private readonly double _annealingFactor;
        private double _currentTemperature;
        private List<int> _currentSolution;
        private int _currentSolutionFitness;
        private readonly Random _random;
        private readonly double _initialtemperaturePercentage;

        public List<int> BestFitnesses
        { get; set; }

        public List<int> bestFitnessesInPopulations;
        public List<int> currentFitnessesInPopulations;

        public SimulatedAnnealingAlgorithm(double initialTemperaturePercent, int numberOfIterations, int numberOfRuns,
            MutationType mutationType, double swapProbability = 0)
        {
            //_initialTemperature = numberOfIterations * initialTemperaturePercent;
            _initialTemperature = initialTemperaturePercent;
            _numberOfIterations = numberOfIterations;
            _numberOfRuns = numberOfRuns;
            _annealingFactor = _initialTemperature / _numberOfIterations;
            _mutationType = mutationType;
            _swapProbability = swapProbability;

            _initialtemperaturePercentage = initialTemperaturePercent;

            _random = new Random();
            BestFitnesses = new List<int>();

            currentFitnessesInPopulations = new List<int>();
            bestFitnessesInPopulations = new List<int>();
        }

        public override void run()
        {
            int counter = 0;

            for (int indexOfRun = 0; indexOfRun < _numberOfRuns; indexOfRun++)
            {
                _currentTemperature = _initialTemperature;

                _currentSolution = generateIndividual();
                _currentSolutionFitness = (int) calculateFitness(_currentSolution);
                BestFitness = _currentSolutionFitness;
                bestSolution = new List<int>(_currentSolution);

                bestFitnessesInPopulations.Add(BestFitness);
                currentFitnessesInPopulations.Add(BestFitness);

                for (int indexOfIteration = 0; indexOfIteration < _numberOfIterations; indexOfIteration++)
                {
                    var mutant = new List<int>(_currentSolution);

                    if (_mutationType == MutationType.INVERSION)
                    {
                        inversion(mutant);
                    }
                    else
                    {
                        swapMutation(mutant);
                    }
                    
                    repairSolution(mutant);

                    var mutantFitness = (int) calculateFitness(mutant);

                    if (mutantFitness < _currentSolutionFitness)
                    {
                        _currentSolution = new List<int>(mutant);
                        _currentSolutionFitness = mutantFitness;

                        if (mutantFitness < BestFitness)
                        {
                            BestFitness = mutantFitness;
                            bestSolution = new List<int>(mutant);
                            //Console.WriteLine($"fitness: {BestFitness} Iter: {indexOfIteration} Temp: {_currentTemperature:0.00}");
                        }
                    }
                    else if (Math.Exp((_currentSolutionFitness - mutantFitness) / _currentTemperature) > _random.NextDouble())
                    {
                        _currentSolution = new List<int>(mutant);
                        _currentSolutionFitness = mutantFitness;
                    }

                    _currentTemperature -= _annealingFactor;

                    bestFitnessesInPopulations.Add(BestFitness);
                    currentFitnessesInPopulations.Add(_currentSolutionFitness);
                }
               
                //Console.WriteLine(counter);
                counter++;

                BestFitnesses.Add(BestFitness);
                //Console.WriteLine($"<<<{BestFitness}>>>");
            }

            //_currentSolution = generateIndividual();
            //_currentSolutionFitness = calculateFitness(_currentSolution);
            //BestFitness = _currentSolutionFitness;
            //bestSolution = new List<int>(_currentSolution);

            //for (int indexOfIteration = 0; indexOfIteration < _numberOfIterations; indexOfIteration++)
            //{
            //    var mutant = new List<int>(_currentSolution);
            //    inversion(mutant);
            //    repairSolution(mutant);

                //var (mutant, mutantFitness) = getMutant();



                //ss


            //    var mutantFitness = calculateFitness(mutant);

            //    if (mutantFitness < _currentSolutionFitness)
            //    {
            //        _currentSolution = mutant;
            //        _currentSolutionFitness = mutantFitness;

            //        if (mutantFitness < BestFitness)
            //        {
            //            BestFitness = mutantFitness;
            //            bestSolution = new List<int>(mutant);
            //            Console.WriteLine($"fitness: {BestFitness} Iter: {indexOfIteration} Temp: {_currentTemperature:0.00}");
            //        }
            //    }
            //    else if (Math.Exp((_currentSolutionFitness - mutantFitness) / _currentTemperature) > _random.NextDouble())
            //    {
            //        _currentSolution = mutant;
            //        _currentSolutionFitness = mutantFitness;
            //    }

            //    _currentTemperature -= _annealingFactor;


            //}

            

            
        }

        private void inversion(List<int> solution)
        {
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
                if (_random.NextDouble() < _swapProbability)
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

        //double initialTemperature, int numberOfIterations,
        public string getConfigurationData()
        {
            return "SA//Number of iterations=" + _numberOfIterations + "; initial temperature=" + _initialtemperaturePercentage
                + ";type of mutation=" + _mutationType + (_mutationType == MutationType.SWAP ? "swap probability=" + _swapProbability : "");

        }
    }
}
