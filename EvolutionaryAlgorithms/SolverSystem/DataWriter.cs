using EvolutionaryAlgorithms.SolverSystem.Algorithms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithms.SolverSystem
{
    class DataWriter
    {
        private const string PATH = "D:\\pwr\\outputs\\";
        private const string GENETIC_DATA_FOLDER = "genetic_data\\";
        private const string TABU_DATA_FOLDER = "tabu_search\\";
        private const string SA_DATA_FOLDER = "sa_data\\";

        private int counterOfTestRun = 0;

        public DataWriter() { }

        public void writeOutputDataFromAlgorithm(Algorithm algorithm)
        {
            switch (algorithm)
            {
                case GreedyAlgorithm:
                    GreedyAlgorithm greedyAlgorithm = (GreedyAlgorithm)algorithm;

                    if (greedyAlgorithm.SearchType == GreedySearchType.ALL)
                    {
                        writeGreedyFitnesses(greedyAlgorithm.Solutions, greedyAlgorithm.NameOfProblem);
                    }
                    else
                    {
                        writeGreedyNearestNodeFitness(greedyAlgorithm.NearestNodeFitness, greedyAlgorithm.NameOfProblem);
                    }

                    break;

                case RandomAlgorithm:
                    RandomAlgorithm randomAlgorithm = (RandomAlgorithm) algorithm;
                    writeRandomFitnessesStatisticData(randomAlgorithm.BestFitness, randomAlgorithm.WorstFitness, randomAlgorithm.AverageFitness,
                        randomAlgorithm.StandardDeviation, randomAlgorithm.NameOfProblem);
                    
                    break;

                case GeneticAlgorithm:
                    GeneticAlgorithm geneticAlgorithm = (GeneticAlgorithm) algorithm;
                    writeGeneticBestFitnesses(geneticAlgorithm.BestFitnesses, geneticAlgorithm.NameOfProblem);
                    writeGeneticDataForPlot(geneticAlgorithm.bestFitnessesInPopulations, geneticAlgorithm.worstFitnessesInPopulations,
                        geneticAlgorithm.averageFitnessesInPopulations, geneticAlgorithm.NameOfProblem);

                    break;

                case TabuSearchAlgorithm:
                    TabuSearchAlgorithm tabuSearchAlgorithm = (TabuSearchAlgorithm) algorithm;
                    //todo
                    writeTabuSearchBestFitnesses(tabuSearchAlgorithm.BestFitnesses, tabuSearchAlgorithm.NameOfProblem);
                    writeTabuSearchDataForPlot(tabuSearchAlgorithm.bestFitnessesInPopulations, tabuSearchAlgorithm.worstFitnessesInPopulations,
                        tabuSearchAlgorithm.averageFitnessesInPopulations, tabuSearchAlgorithm.currentFitnessesInPopulations, tabuSearchAlgorithm.NameOfProblem);

                    break;

                case SimulatedAnnealingAlgorithm:
                    SimulatedAnnealingAlgorithm simulatedAnnealingAlgorithm = (SimulatedAnnealingAlgorithm)algorithm;
                    writeSimulatedAnnealingBestFitnesses(simulatedAnnealingAlgorithm.BestFitnesses, simulatedAnnealingAlgorithm.NameOfProblem);
                    writeSimulatedAnnealingDataForPlot(simulatedAnnealingAlgorithm.bestFitnessesInPopulations,
                        simulatedAnnealingAlgorithm.currentFitnessesInPopulations, simulatedAnnealingAlgorithm.NameOfProblem);
                    break;
            }
        }

        private void writeGreedyFitnesses(List<double> fitnesses, string nameOfProblem)
        {
            string information = string.Format("{0}_{1}", AlgorithmType.GREEDY, nameOfProblem);
            string strFilePath = string.Format("{0}/{1}.csv", PATH, information);

            StringBuilder sbOutput = new StringBuilder();
            sbOutput.AppendLine(information);
            sbOutput.AppendLine("index, fitness");

            String newLine;

            for (int counterOfDataRow = 0; counterOfDataRow < fitnesses.Count; counterOfDataRow++)
            {
                newLine = string.Format("{0},{1}", counterOfDataRow, fitnesses[counterOfDataRow].ToString("F"));
                sbOutput.AppendLine(newLine);
            }

            File.WriteAllText(strFilePath, sbOutput.ToString());
        }

        private void writeGreedyNearestNodeFitness(double fitness, string nameOfProblem)
        {
            string information = String.Format("{0}_{1}", AlgorithmType.GREEDY, nameOfProblem);
            string strFilePath = String.Format("{0}/{1}.csv", PATH, information);

            StringBuilder sbOutput = new StringBuilder();
            sbOutput.AppendLine(information);
            sbOutput.AppendLine("fitness");

            sbOutput.AppendLine(fitness.ToString("F"));
          
            File.WriteAllText(strFilePath, sbOutput.ToString());
        }

        private void writeRandomFitnessesStatisticData(double bestFitness, double worstFitness, double averageFitness, double standardDeviation, string nameOfProblem)
        {
            string information = String.Format("{0}_{1}", AlgorithmType.RANDOM, nameOfProblem);
            string strFilePath = String.Format("{0}/{1}.csv", PATH, information);

            StringBuilder sbOutput = new StringBuilder();
            sbOutput.AppendLine(information);
            sbOutput.AppendLine("best fitness, worst fitness, average fitness, standard deviation");

            String newLine;
            newLine = string.Format("{0},{1},{2},{3}", bestFitness.ToString("F"), worstFitness.ToString("F"), averageFitness.ToString("F"), standardDeviation.ToString("F"));
            sbOutput.AppendLine(newLine);
            
            File.WriteAllText(strFilePath, sbOutput.ToString());
        }

        private void writeGeneticBestFitnesses(List<double> fitnesses, string nameOfProblem)
        {
            //string information = String.Format("{0}_{1}", AlgorithmType.GENETIC, nameOfProblem);
            string information = String.Format("{0}_{1}_{2}", AlgorithmType.GENETIC, counterOfTestRun, nameOfProblem);
            string strFilePath = String.Format("{0}/{1}.csv", PATH + GENETIC_DATA_FOLDER, information);

            StringBuilder sbOutput = new StringBuilder();
            sbOutput.AppendLine(information);
            sbOutput.AppendLine("index of algorithm runs, best fitness");

            String newLine;

            for (int counterOfDataRow = 0; counterOfDataRow < fitnesses.Count; counterOfDataRow++)
            {
                newLine = string.Format("{0},{1}", counterOfDataRow, fitnesses[counterOfDataRow].ToString("F"));
                sbOutput.AppendLine(newLine);
            }

            File.WriteAllText(strFilePath, sbOutput.ToString());

            counterOfTestRun++;
        }

        private void writeGeneticDataForPlot(List<double> bestFintesses, List<double> worstFintesses, List<double> averageFitnesses, string nameOfProblem)
        {
            
            string information = String.Format("{0}_{1}", AlgorithmType.GENETIC + "_plot", nameOfProblem);
            string strFilePath = String.Format("{0}/{1}.csv", PATH, information);

            StringBuilder sbOutput = new StringBuilder();
            sbOutput.AppendLine("best fitness, worst fitness, average fitness");

            String newLine;

            for (int i = 0; i < bestFintesses.Count; i++)
            {
                newLine = string.Format("{0},{1},{2}", bestFintesses[i].ToString("F"), worstFintesses[i].ToString("F"), averageFitnesses[i].ToString("F"));
                sbOutput.AppendLine(newLine);
            }

            File.WriteAllText(strFilePath, sbOutput.ToString());
        }

        private void writeTabuSearchBestFitnesses(List<int> fitnesses, string nameOfProblem)
        {
            //string information = String.Format("{0}_{1}", AlgorithmType.TABU_SEARCH, nameOfProblem);
            string information = String.Format("{0}_{1}_{2}", AlgorithmType.TABU_SEARCH, counterOfTestRun, nameOfProblem);
            string strFilePath = String.Format("{0}/{1}.csv", PATH + TABU_DATA_FOLDER, information);

            StringBuilder sbOutput = new StringBuilder();
            sbOutput.AppendLine(information);
            sbOutput.AppendLine("index of algorithm runs, best fitness");

            String newLine;

            for (int counterOfDataRow = 0; counterOfDataRow < fitnesses.Count; counterOfDataRow++)
            {
                newLine = string.Format("{0},{1}", counterOfDataRow, fitnesses[counterOfDataRow].ToString("F"));
                sbOutput.AppendLine(newLine);
            }

            File.WriteAllText(strFilePath, sbOutput.ToString());

            counterOfTestRun++;
        }

        private void writeTabuSearchDataForPlot(List<int> bestFintesses, List<int> worstFintesses, List<double> averageFitnesses, List<int> currentFitnesses, string nameOfProblem)
        {
            //string information = String.Format("{0}_{1}", AlgorithmType.TABU_SEARCH + "_plot", nameOfProblem);
            string information = String.Format("{0}_{1}_{2}", AlgorithmType.TABU_SEARCH+ "_plot", counterOfTestRun, nameOfProblem);
            string strFilePath = String.Format("{0}/{1}.csv", PATH + TABU_DATA_FOLDER, information);

            StringBuilder sbOutput = new StringBuilder();
            sbOutput.AppendLine("best fitness, current fitness, average fitness, worst fitness");

            String newLine;

            for (int i = 0; i < bestFintesses.Count; i++)
            {
                newLine = string.Format("{0},{1},{2},{3}", bestFintesses[i].ToString("F"), currentFitnesses[i].ToString("F"), averageFitnesses[i].ToString("F"), worstFintesses[i].ToString("F"));
                sbOutput.AppendLine(newLine);
            }

            File.WriteAllText(strFilePath, sbOutput.ToString());

            //counterOfTestRun++;
        }

        private void writeSimulatedAnnealingBestFitnesses(List<int> fitnesses, string nameOfProblem)
        {
            //string information = String.Format("{0}_{1}", AlgorithmType.SIMULATED_ANNEALING, nameOfProblem);
            string information = String.Format("{0}_{1}_{2}", AlgorithmType.SIMULATED_ANNEALING, counterOfTestRun, nameOfProblem);
            string strFilePath = String.Format("{0}/{1}.csv", PATH + SA_DATA_FOLDER, information);

            StringBuilder sbOutput = new StringBuilder();
            sbOutput.AppendLine(information);
            sbOutput.AppendLine("index of algorithm runs, best fitness");

            String newLine;

            for (int counterOfDataRow = 0; counterOfDataRow < fitnesses.Count; counterOfDataRow++)
            {
                newLine = string.Format("{0},{1}", counterOfDataRow, fitnesses[counterOfDataRow].ToString("F"));
                sbOutput.AppendLine(newLine);
            }

            File.WriteAllText(strFilePath, sbOutput.ToString());

            counterOfTestRun++;
        }

        private void writeSimulatedAnnealingDataForPlot(List<int> bestFintesses, List<int> currentFitnesses, string nameOfProblem)
        {
            //string information = String.Format("{0}_{1}", AlgorithmType.SIMULATED_ANNEALING + "_plot", nameOfProblem);
            string information = String.Format("{0}_{1}_{2}", AlgorithmType.SIMULATED_ANNEALING + "_plot", counterOfTestRun, nameOfProblem);
            string strFilePath = String.Format("{0}/{1}.csv", PATH + SA_DATA_FOLDER, information);

            StringBuilder sbOutput = new StringBuilder();
            sbOutput.AppendLine("best fitness, current fitness");

            String newLine;

            for (int i = 0; i < bestFintesses.Count; i++)
            {
                newLine = string.Format("{0},{1}", bestFintesses[i].ToString("F"), currentFitnesses[i].ToString("F"));
                sbOutput.AppendLine(newLine);
            }

            File.WriteAllText(strFilePath, sbOutput.ToString());
        }
    }
}
