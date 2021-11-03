using EvolutionaryAlgorithms.SolverSystem.Algorithms;
using EvolutionaryAlgorithms.SolverSystem.Configurations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithms.SolverSystem
{
    class ProblemSolver
    {
        public String[] PathesToProblems
        { get; set; }

        public SolverConfiguration[] Configurations
        { get; set; }

        private ProblemLoader _loader;
        private DataWriter _writer;

        public ProblemSolver()
        {
            _loader = new ProblemLoader();
            _writer = new DataWriter();
        }

        public void run()
        {
            int[] cityToVisitNodes;
            int[,] destinationMatrix;
            int depotNode;
            Algorithm algorithm;

            foreach (string path in PathesToProblems)
            {
                _loader.loadProblem(path);

                foreach (SolverConfiguration configuration in Configurations)
                {   
                    depotNode = 0;

                    //if (configuration.DepotNode != 0) // for Greedy
                    //{
                    //    depotNode = configuration.DepotNode;
                    //}

                    cityToVisitNodes = initializeCityToVisitNodes(_loader.Dimension, depotNode);
                    destinationMatrix = initializeDestinationMatrix(_loader.CoordinatesOfNodes);
                    algorithm = prepareAlgorithm(configuration, depotNode, cityToVisitNodes, destinationMatrix);

                    algorithm.run();

                    _writer.writeOutputDataFromAlgorithm(algorithm);

                    //GeneticAlgorithm geneticAlgorithm = (GeneticAlgorithm)algorithm;
                    //writeDateForPlot(geneticAlgorithm.bestFitnessesInPopulations, geneticAlgorithm.worstFitnessesInPopulations, geneticAlgorithm.averageFitnessesInPopulations);


                    //fix
                    //writeSolutions(configuration.Algorithm, algorithm.BestFitnesses, algorithm.WorstFitnesses, algorithm.AverageFitness, algorithm.StandardDeviation);          
                }
            }
        }

        private int[] initializeCityToVisitNodes(int dimension, int depotNode)
        {
            List<int> nodes = new List<int>(dimension);

            for (int i = 0; i < dimension; i++)
            {
                nodes.Add(i);
            }
            nodes.Remove(depotNode);

            return nodes.ToArray();
        }

        private int[,] initializeDestinationMatrix((int, int)[] coordinatesOfNodes)
        {
            int dimension = coordinatesOfNodes.Length;
            int[,] destinationMatrix = new int[dimension, dimension];
            int coordinateX1, coordinateY1, coordinateX2, coordinateY2;  

            for(int rowIndex = 0; rowIndex < dimension; rowIndex++)
            {
                (coordinateX1, coordinateY1) = coordinatesOfNodes[rowIndex];

                for (int columnIndex = 0; columnIndex < dimension; columnIndex++)
                {
                    (coordinateX2, coordinateY2) = coordinatesOfNodes[columnIndex];

                    destinationMatrix[rowIndex, columnIndex] = (int) Math.Round(Math.Sqrt(Math.Pow(coordinateX2 - coordinateX1, 2) + Math.Pow(coordinateY2 - coordinateY1, 2)));
                }
            }

            return destinationMatrix;
        }

        private Algorithm prepareAlgorithm(SolverConfiguration configuration, int depotNode, int[] cityToVisitNodes, int[,] destinationMatrix)
        {
            Algorithm algorithm = null;

            switch (configuration.AlgorithmType)
            {
                case AlgorithmType.GREEDY:
                    GreedyConfiguration greedyConfig = (GreedyConfiguration) configuration;
                    GreedyAlgorithm greedyAlgorithm = new GreedyAlgorithm(greedyConfig.SearchType);

                    algorithm = greedyAlgorithm;
                    //List<double> solutions = new List<double>();



                    //for (int i = 0; i < _loader.Dimension; i++)
                    //{
                    //    greedyAlgorithm.DepotNode = i;
                    //    greedyAlgorithm.run();

                    //    _writer.writeOutputDataFromAlgorithm(greedyAlgorithm);
                    //}


                    break;

                case AlgorithmType.RANDOM:
                    RandomConfiguration randomConfig = (RandomConfiguration) configuration;
                    RandomAlgorithm randomAlgorithm =  new RandomAlgorithm(randomConfig.NumberOfAlgorithmRuns);
                    algorithm = randomAlgorithm;

                    break;

                case AlgorithmType.GENETIC:
                    GeneticConfiguration geneticConfig = (GeneticConfiguration) configuration;
                    GeneticAlgorithm geneticAlgorithm = new GeneticAlgorithm(geneticConfig.NumberOfAlgorithmRuns, geneticConfig.NumberOfPopulations,
                        geneticConfig.NumberOfIndividuals, geneticConfig.MutationProbaility, geneticConfig.CrossoverProbability, geneticConfig.CrossoverType);
                    algorithm = geneticAlgorithm;

                    break;

                case AlgorithmType.TABU_SEARCH:
                    TabuConfiguration tabuConfiguration = (TabuConfiguration) configuration;
                    TabuSearchAlgorithm tabuSearchAlgorithm = new TabuSearchAlgorithm(tabuConfiguration.NumberOfAlgorithmRuns, 
                        tabuConfiguration.NumberOfIterations, tabuConfiguration.SizeOfTabuList, tabuConfiguration.NumberOfNeighbors);
                    algorithm = tabuSearchAlgorithm;

                    break;

                case AlgorithmType.SIMULATED_ANNEALING:
                    SimulatedAnnealingConfiguration simulatedAnnealingConfiguration = (SimulatedAnnealingConfiguration)configuration;
                    SimulatedAnnealingAlgorithm simulatedAnnealingAlgorithm = new SimulatedAnnealingAlgorithm(simulatedAnnealingConfiguration.InitialTemperature,
                        simulatedAnnealingConfiguration.NumberOfIterations, simulatedAnnealingConfiguration.NumberOfRuns);
                    algorithm = simulatedAnnealingAlgorithm;

                    break;
            }

            algorithm.Capacity = _loader.Capacity;
            algorithm.DemandsOfNodes = _loader.DemandsOfNodes;
            algorithm.NameOfProblem = _loader.NameOfProblem;
            algorithm.Dimension = _loader.Dimension;
            algorithm.DepotNode = depotNode;
            algorithm.CityToVisitNodes = cityToVisitNodes;
            algorithm.DestinationMatrix = destinationMatrix;


            //ds
            //algorithm.run();

            //_writer.writeOutputDataFromAlgorithm(algorithm);


            return algorithm;
        }


        private void writeSolutions(AlgorithmType algorithmType, List<double> bestFintesses, List<double> worstFintesses, double averageFitness, double standardDeviation)
        {
            string path = "D:\\pwr\\outputs\\";
            string information = String.Format("{0}_{1}", algorithmType.ToString(), _loader.NameOfProblem);

            string strFilePath = String.Format("{0}/{1}.csv", path, information);
                
            StringBuilder sbOutput = new StringBuilder();

            sbOutput.AppendLine(information);

            sbOutput.AppendLine("index of population, best fitness, worst fitness");

            String newLine;

            for (int i = 0; i < bestFintesses.Count; i++)
            {
                //sbOutput.AppendLine(bestFintesses[i].ToString());
                if (algorithmType == AlgorithmType.GREEDY)
                {
                    newLine = string.Format("{0},{1}", i, bestFintesses[i].ToString("F"));
                }
                else if (algorithmType == AlgorithmType.RANDOM)
                {
                    newLine = string.Format("{0},{1},{2},{3},{4}", i, bestFintesses[i].ToString("F"), worstFintesses[i].ToString("F"), averageFitness.ToString("F"), standardDeviation.ToString("F"));
                }
                else if (algorithmType == AlgorithmType.GENETIC)
                {
                    newLine = string.Format("{0},{1},{2}", i, bestFintesses[i].ToString("F"), worstFintesses[i].ToString("F"));
                }
                else
                {
                    newLine = string.Format("{0},{1}", i, bestFintesses[i].ToString("F"));
                }
               
                sbOutput.AppendLine(newLine);
            }

            File.WriteAllText(strFilePath, sbOutput.ToString());
        }

        private void writeDateForPlot(List<double> bestFintesses, List<double> worstFintesses, List<double> averageFitnesses)
        {
            string path = "D:\\pwr\\outputs\\";
            string information = String.Format("{0}_{1}", AlgorithmType.GENETIC.ToString() + "_plot", _loader.NameOfProblem);

            string strFilePath = String.Format("{0}/{1}.csv", path, information);

            StringBuilder sbOutput = new StringBuilder();

            //sbOutput.AppendLine(information);

            sbOutput.AppendLine("best fitness, worst fitness, average fitness");

            String newLine;

            for (int i = 0; i < bestFintesses.Count; i++)
            {
                
               
                newLine = string.Format("{0},{1},{2}", bestFintesses[i].ToString("F"), worstFintesses[i].ToString("F"), averageFitnesses[i].ToString("F"));
                

                sbOutput.AppendLine(newLine);
            }

            File.WriteAllText(strFilePath, sbOutput.ToString());
        }
    }
}
