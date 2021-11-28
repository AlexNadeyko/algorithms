
using EvolutionaryAlgorithms.SolverSystem.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EvolutionaryAlgorithms.SolverSystem
{
    public class DataAnalyzer
    {
        public string ProblemName { get; set; }

        private List<DataAnalyzerItem> geneticAlghoritmData;
        private List<DataAnalyzerItem> tabuSearchData;
        private List<DataAnalyzerItem> simulatedAnnealingData;

        public DataAnalyzer() 
        {
            geneticAlghoritmData = new List<DataAnalyzerItem>();
            tabuSearchData = new List<DataAnalyzerItem>();
            simulatedAnnealingData = new List<DataAnalyzerItem>();
        }

        public void readData(Algorithm algorithm)
        {
            switch (algorithm)
            {
                case GeneticAlgorithm:
                    GeneticAlgorithm geneticAlgorithm = (GeneticAlgorithm)algorithm;
                    geneticAlghoritmData.Add(analyzeData(geneticAlgorithm.BestFitnesses, geneticAlgorithm.getConfigurationData()));
                    break;

                case TabuSearchAlgorithm:
                    TabuSearchAlgorithm tabuSearchAlgorithm = (TabuSearchAlgorithm)algorithm;
                    tabuSearchData.Add(analyzeData(tabuSearchAlgorithm.BestFitnesses, tabuSearchAlgorithm.getConfigurationData()));
                    break;


                case SimulatedAnnealingAlgorithm:
                    SimulatedAnnealingAlgorithm simulatedAnnealingAlgorithm = (SimulatedAnnealingAlgorithm)algorithm;
                    simulatedAnnealingData.Add(analyzeData(simulatedAnnealingAlgorithm.BestFitnesses, simulatedAnnealingAlgorithm.getConfigurationData()));
                    break;
            }
        }

        public void displayAnalyzedData()
        {
            List<DataAnalyzerItem> data;
            DataAnalyzerItem bestDataItem;

            if (geneticAlghoritmData.Count > 0)
            {
                data = geneticAlghoritmData;
            }
            else if (tabuSearchData.Count > 0)
            {
                data = tabuSearchData;

            }
            else if (simulatedAnnealingData.Count > 0)
            {
                data = simulatedAnnealingData;
            }
            else 
            {
                Console.WriteLine("Error in analyzing data module");
                return;
            }

            bestDataItem = data[0];

            foreach (DataAnalyzerItem dataItem in data)
            {
                //Console.WriteLine(dataItem);

                if (dataItem.AverageFitness < bestDataItem.AverageFitness)
                {
                    bestDataItem = dataItem;
                }
            }
            Console.WriteLine("***********************************************************");
            Console.WriteLine("Best Data for problem - " + ProblemName + ":\n" + bestDataItem);
            Console.WriteLine("***********************************************************\n\n\n");
        }

        public void clearData()
        {
            geneticAlghoritmData.Clear();
            tabuSearchData.Clear(); ;
            simulatedAnnealingData.Clear(); ;
        }
        

        private DataAnalyzerItem analyzeData(List<int> fitnesses, string configurationData)
        {
            double bestFitness;
            double worstFitness;
            double averageFitness;
            double standartDeviation;
            double sum;

            bestFitness = fitnesses.Min();
            worstFitness = fitnesses.Max();
            averageFitness = fitnesses.Average();
            
            sum = fitnesses.Sum(d => Math.Pow(d - averageFitness, 2));
            standartDeviation = Math.Sqrt((sum) / (fitnesses.Count() - 1));

            return new DataAnalyzerItem(bestFitness, worstFitness, averageFitness, standartDeviation, configurationData);
        }


    }

    public class DataAnalyzerItem
    {
        public double BestFitness { get; }
        public double WorstFitness { get; }
        public double AverageFitness { get; }
        public double StandardDeviation { get; }
        public string ConfigurationData { get; }

        public DataAnalyzerItem(double bestFitness, double worstFitness, double averageFitness, double standardDeviation,
            string configurationData)
        {
            BestFitness = bestFitness;
            WorstFitness = worstFitness;
            AverageFitness = averageFitness;
            StandardDeviation = standardDeviation;
            ConfigurationData = configurationData;
        }

        public override string ToString()
        {
            return "BestFitness=" + BestFitness + "; WorstFitness=" + WorstFitness + "; AverageFitness=" + AverageFitness +
                "; StandardDeviation=" + StandardDeviation + "\n" + ConfigurationData;
        }
    }
}
