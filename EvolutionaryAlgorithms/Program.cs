using EvolutionaryAlgorithms.SolverSystem;
using EvolutionaryAlgorithms.SolverSystem.Algorithms;
using EvolutionaryAlgorithms.SolverSystem.Configurations;
using EvolutionaryAlgorithms.SolverSystem.Configurations.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace EvolutionaryAlgorithms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] problemsToSolve = {
                //@"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n32-k5.vrp",
                //@"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n37-k6.vrp",
                // @"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n39-k5.vrp",
                //  @"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n45-k6.vrp",
                //   @"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n48-k7.vrp",
                //    @"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n54-k7.vrp",
                     @"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n60-k9.vrp"
            };

            SolverConfiguration[] configurations = {


            //new SolverConfiguration(AlgorithmType.RANDOM, 10000), 
            //new SolverConfiguration(10, AlgorithmType.GENETIC, 100, 1000, 0.2, 0.5, CrossoverType.CYCLE_CROSSOVER),
            //new SolverConfiguration(10, AlgorithmType.GENETIC, 100, 1000, 0.01, 0.5, CrossoverType.CYCLE_CROSSOVER),
            //new SolverConfiguration(AlgorithmType.GREEDY),

            //new SolverConfiguration(1, AlgorithmType.GENETIC, 100, 100, 0.6, 0.0, CrossoverType.CYCLE_CROSSOVER),
            //new SolverConfiguration(1, AlgorithmType.GENETIC, 1000, 100, 0.3, 0.1, CrossoverType.CYCLE_CROSSOVER)

            //new SolverConfiguration(1, AlgorithmType.GENETIC, 1000, 100, 0.5, 0.80, CrossoverType.CYCLE_CROSSOVER)
            //new SolverConfiguration(1, AlgorithmType.GENETIC, 1000, 100, 0.5, 0.85, CrossoverType.CYCLE_CROSSOVER) //good
            //new SolverConfiguration(10, AlgorithmType.GENETIC, 1000, 100, 0.7, 0.85, CrossoverType.CYCLE_CROSSOVER) //good version 2

            //new SolverConfiguration("x", 10, AlgorithmType.TABU_SEARCH, 10000, 700, 70)
            //new SolverConfiguration(1, AlgorithmType.GENETIC, 1000, 100, 0.3, 0.85, CrossoverType.CYCLE_CROSSOVER) //Tabu



            //new version
            //new RandomConfiguration(AlgorithmType.RANDOM, 10000), 
            //new GreedyConfiguration(AlgorithmType.GREEDY, GreedySearchType.ALL),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 1, 10, 10, CrossoverType.CYCLE_CROSSOVER, 0.8, 0.5)
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 1, 10, 700, 70)
            //1693 0.8 0.5
            /*new GeneticConfiguration(AlgorithmType.GENETIC, 10, 1000, 100, CrossoverType.CYCLE_CROSSOVER, 0.85, 0.7)*/ //very good
                                                                                                                         //new GeneticConfiguration(AlgorithmType.GENETIC, 1, 1000, 100, CrossoverType.CYCLE_CROSSOVER, 0.85, 0.7) // to check

            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 1, 2000, 700, 100) // ok
            /*new SimulatedAnnealingConfiguration(1, 500000, 40) */// very very good
                                                                   //new SimulatedAnnealingConfiguration(1, 1_000_000, 6) //good

            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 1000, 100, CrossoverType.CYCLE_CROSSOVER, 0.4, 0.1)


            //test//test
            //new GeneticConfiguration(AlgorithmType.GENETIC, 1, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.0, 0.0),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 1, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.5, 0.0),


            //testing GeneticAlghoritm

            //0-10
            //Genetic 10 10000 100 Tournament size=5 Cycle Crossover Inversion X 0.0
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.0, 0.0),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.1, 0.0),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.2, 0.0),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.3, 0.0),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.4, 0.0),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.5, 0.0),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.6, 0.0),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.7, 0.0),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.8, 0.0),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.9, 0.0),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 1.0, 0.0),

            //11-21
            //Genetic 10 10000 100 Tournament size=5 Cycle Crossover Inversion 0.0 X
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.0, 0.0),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.0, 0.1),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.0, 0.2),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.0, 0.3),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.0, 0.4),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.0, 0.5),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.0, 0.6),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.0, 0.7),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.0, 0.8),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.0, 0.9),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.0, 1.0),

            //TODO
            //22-32
            //Genetic 10 10000 100 Tournament size=5 Cycle Crossover Inversion X 0.1
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.0, 0.1),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.1, 0.1),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.2, 0.1),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.3, 0.1),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.4, 0.1),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.5, 0.1),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.6, 0.1),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.7, 0.1),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.8, 0.1),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.9, 0.1),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 1.0, 0.1),

            //33-43
            //Genetic 10 10000 100 Tournament size=5 Cycle Crossover Inversion X 0.3
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.0, 0.3),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.1, 0.3),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.2, 0.3),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.3, 0.3),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.4, 0.3),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.5, 0.3),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.6, 0.3),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.7, 0.3),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.8, 0.3),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.9, 0.3),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 1.0, 0.3),

            //44-54
            //Genetic 10 10000 100 Tournament size=5 Cycle Crossover Inversion X 0.5
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.0, 0.5),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.1, 0.5),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.2, 0.5),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.3, 0.5),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.4, 0.5),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.5, 0.5),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.6, 0.5),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.7, 0.5),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.8, 0.5),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.9, 0.5),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 1.0, 0.5),

            //55-65
            //Genetic 10 10000 100 Tournament size=5 Cycle Crossover Inversion X 0.7
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.0, 0.7),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.1, 0.7),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.2, 0.7),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.3, 0.7),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.4, 0.7),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.5, 0.7),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.6, 0.7),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.7, 0.7),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.8, 0.7),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.9, 0.7),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 1.0, 0.7),

            //66-76
            //Genetic 10 10000 100 Tournament size=5 Cycle Crossover Inversion X 0.9
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.0, 0.9),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.1, 0.9),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.2, 0.9),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.3, 0.9),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.4, 0.9),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.5, 0.9),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.6, 0.9),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.7, 0.9),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.8, 0.9),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0.9, 0.9),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 1.0, 0.9),

            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 5000, 100, CrossoverType.ORDERED_CROSSOVER, 0.1, 0.1),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 5000, 100, CrossoverType.ORDERED_CROSSOVER, 0.3, 0.1),
            // new GeneticConfiguration(AlgorithmType.GENETIC, 10, 5000, 100, CrossoverType.ORDERED_CROSSOVER, 0.5, 0.1),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 5000, 100, CrossoverType.ORDERED_CROSSOVER, 0.1, 0.3),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 5000, 100, CrossoverType.ORDERED_CROSSOVER, 0.3, 0.3),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 5000, 100, CrossoverType.ORDERED_CROSSOVER, 0.5, 0.3),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 5000, 100, CrossoverType.ORDERED_CROSSOVER, 0.7, 0.3),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 5000, 100, CrossoverType.ORDERED_CROSSOVER, 0.1, 0.4), //best
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 5000, 100, CrossoverType.ORDERED_CROSSOVER, 0.3, 0.4),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 5000, 100, CrossoverType.ORDERED_CROSSOVER, 0.5, 0.4),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 5000, 100, CrossoverType.ORDERED_CROSSOVER, 0.7, 0.4),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 5000, 100, CrossoverType.ORDERED_CROSSOVER, 0.3, 0.5),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 5000, 100, CrossoverType.ORDERED_CROSSOVER, 0.5, 0.5),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 5000, 100, CrossoverType.ORDERED_CROSSOVER, 0.7, 0.5),

            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 5000, 100, CrossoverType.ORDERED_CROSSOVER, 0.3, 0.7),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 5000, 100, CrossoverType.ORDERED_CROSSOVER, 0.5, 0.7),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 5000, 100, CrossoverType.ORDERED_CROSSOVER, 0.7, 0.7)

            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 100000, 100, CrossoverType.ORDERED_CROSSOVER, 0.1, 0.4),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 100000, 100, CrossoverType.ORDERED_CROSSOVER, 0.3, 0.4),

            // new GeneticConfiguration(AlgorithmType.GENETIC, 10, 100000, 100, CrossoverType.CYCLE_CROSSOVER, 0.1, 0.4),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 100000, 100, CrossoverType.CYCLE_CROSSOVER, 0.3, 0.4),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 5000, 100, CrossoverType.ORDERED_CROSSOVER, 0.1, 0.4),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 5000, 100, CrossoverType.ORDERED_CROSSOVER, 0.1, 0.7),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 5000, 100, CrossoverType.ORDERED_CROSSOVER, 0.3, 0.2),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 5000, 100, CrossoverType.ORDERED_CROSSOVER, 0.3, 0.4),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 5000, 100, CrossoverType.ORDERED_CROSSOVER, 0.3, 0.7),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 5000, 100, CrossoverType.ORDERED_CROSSOVER, 0.5, 0.3),


            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0, 0),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0, 0),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0, 0),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0, 0),
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 10000, 100, CrossoverType.CYCLE_CROSSOVER, 0, 0),





            //testing TabuSearch
            //#tabu list //#
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 0, 20),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 50, 20),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 100, 20),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 150, 20),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 300, 20),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 500, 20),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 700, 20),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 900, 20),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 1200, 20),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 1500, 20),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 2000, 20),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 3000, 20),

            //# size of neighbors
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 150, 1),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 150, 10),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 150, 20),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 150, 30),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 150, 50),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 150, 70),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 150, 100),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 150, 150),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 150, 200),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 150, 300),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 150, 500),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 150, 700),


            // number of iterations
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 1, 1000, 1500, 100),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 100, 150, 100),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 200, 150, 100),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 300, 150, 100),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 150, 100),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 1000, 150, 100),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 1300, 150, 100),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 1500, 150, 100),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 1800, 150, 100),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 2000, 150, 100),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 2500, 150, 100),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 3000, 150, 100),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 4000, 150, 100)


            //operators 
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 6000, 150, 100)
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 500, 150, 3000)


            //Simulated Anealing
            //number of iterations
            //new SimulatedAnnealingConfiguration(10, 100, 100),
            //new SimulatedAnnealingConfiguration(10, 300, 100),
            //new SimulatedAnnealingConfiguration(10, 700, 100),
            //new SimulatedAnnealingConfiguration(10, 1000, 100),
            //new SimulatedAnnealingConfiguration(10, 1500, 100),
            //new SimulatedAnnealingConfiguration(10, 2500, 100),
            //new SimulatedAnnealingConfiguration(10, 5000, 100),
            //new SimulatedAnnealingConfiguration(10, 10000, 100),
            //new SimulatedAnnealingConfiguration(10, 200000, 100),
            //new SimulatedAnnealingConfiguration(10, 300000, 100),
            //new SimulatedAnnealingConfiguration(10, 500000, 100),
            //new SimulatedAnnealingConfiguration(10, 800000, 100),
            //new SimulatedAnnealingConfiguration(10, 1000000, 100),
            //new SimulatedAnnealingConfiguration(10, 2000000, 100),
            //new SimulatedAnnealingConfiguration(10, 500000, 100)



            //temperature
            //new SimulatedAnnealingConfiguration(10, 100000, 1),
            // new SimulatedAnnealingConfiguration(10, 100000, 8),
            //new SimulatedAnnealingConfiguration(10, 10000, 0.8),
            //new SimulatedAnnealingConfiguration(10, 100000, 9),
            //new SimulatedAnnealingConfiguration(10, 100000, 7),
            ////new SimulatedAnnealingConfiguration(10, 10000, 30),
            ////new SimulatedAnnealingConfiguration(10, 10000, 40),
            ////new SimulatedAnnealingConfiguration(10, 10000, 50),
            ////new SimulatedAnnealingConfiguration(10, 10000, 80),
            //new SimulatedAnnealingConfiguration(10, 100000, 140),
            ////new SimulatedAnnealingConfiguration(10, 10000, 200),
            ////new SimulatedAnnealingConfiguration(10, 10000, 350),
            ////new SimulatedAnnealingConfiguration(10, 10000, 500),
            ////new SimulatedAnnealingConfiguration(10, 10000, 800),
            ////new SimulatedAnnealingConfiguration(10, 10000, 1000),
            //new SimulatedAnnealingConfiguration(10, 100000, 2000),
            //new SimulatedAnnealingConfiguration(10, 10000, 3000),
            //new SimulatedAnnealingConfiguration(10, 10000, 5000)

            //new SimulatedAnnealingConfiguration(10, 1000000, 6),s

            //new SimulatedAnnealingConfiguration(10, 300000, 10),
            //new SimulatedAnnealingConfiguration(10, 300000, 0.9),
            // new SimulatedAnnealingConfiguration(10, 300000, 9),
            //  new SimulatedAnnealingConfiguration(10, 300000, 1),
            //   new SimulatedAnnealingConfiguration(10, 300000, 15),


            //new RandomConfiguration(AlgorithmType.RANDOM, 10000), 
            //new GreedyConfiguration(AlgorithmType.GREEDY, GreedySearchType.ALL),
            //new SimulatedAnnealingConfiguration(10, 1000000, 9),
            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 2000, 1000, 700),
            //new SimulatedAnnealingConfiguration(10, 500000, 5),
            //new SimulatedAnnealingConfiguration(10, 500000, 10),
            //new SimulatedAnnealingConfiguration(10, 500000, 30),
            // new SimulatedAnnealingConfiguration(10, 500000, 50),
            //  new SimulatedAnnealingConfiguration(10, 500000, 100),
            //   new SimulatedAnnealingConfiguration(10, 500000, 200),

                //new SimulatedAnnealingConfiguration(10, 500000, 34, MutationType.INVERSION),
                
                
                
                 new TabuConfiguration(AlgorithmType.TABU_SEARCH, 1, 20000,
                                    250, 800, MutationType.INVERSION),

                new SimulatedAnnealingConfiguration(1, 20000, 9,
                                MutationType.INVERSION),



                new GeneticConfiguration(AlgorithmType.GENETIC,
                                        1, 20000, 100, CrossoverType.ORDERED_CROSSOVER,
                                       0.4, MutationType.INVERSION, 0.8,
                                       SelectionType.TOURNAMENT, 160),

                //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 1, 10000,
                //                    250, 800, MutationType.INVERSION),

                //new SimulatedAnnealingConfiguration(1, 10000, 9,
                //                MutationType.INVERSION)


                //new GreedyConfiguration(AlgorithmType.GREEDY, GreedySearchType.ALL),
            };

            ProblemSolver solver = new ProblemSolver();

            solver.Configurations = configurations.ToList();
            solver.PathesToProblems = problemsToSolve;

            solver.run();


            /////

            //new Episode
            //testGeneticAlgorithm();

            //testTabuSearch();

            //testSimulatedAnnealing();

        }

        public static void testGeneticAlgorithm()
        {
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("GAGAGAGAGAGAGAGAGAGG");

            string[] problemsToSolve = {
                @"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n32-k5.vrp",
                //@"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n37-k6.vrp",
                 //@"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n39-k5.vrp",
                  @"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n45-k6.vrp",
                //   @"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n48-k7.vrp",
                    //@"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n54-k7.vrp",
                     @"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n60-k9.vrp"
            };

            //List<SolverConfiguration> configurations = new List<SolverConfiguration>();
            //configurations.Add(new GeneticConfiguration(AlgorithmType.GENETIC, 10, 200, 100, CrossoverType.ORDERED_CROSSOVER, 0.3, MutationType.INVERSION,
            //    0.4, SelectionType.TOURNAMENT, 5));
            //configurations.Add(new GeneticConfiguration(AlgorithmType.GENETIC, 10, 200, 100, CrossoverType.ORDERED_CROSSOVER, 0.3, MutationType.SWAP,
            //    0.4, SelectionType.ROULETTE));

            List<SolverConfiguration> configurations = prepareGeneticAlgorithmConfigurations();
            Console.WriteLine("***Number of configurations=" + configurations.Count + "***\n");

            ProblemSolver solver = new ProblemSolver();

            solver.Configurations = configurations;

            solver.PathesToProblems = problemsToSolve;

            solver.run();

            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$");
        }

        public static List<SolverConfiguration> prepareGeneticAlgorithmConfigurations()
        {
            List<SolverConfiguration> configurationsList = new List<SolverConfiguration>();

            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 200, 100, CrossoverType.ORDERED_CROSSOVER, 0.3, 0.4)
            //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 200, 100, CrossoverType.ORDERED_CROSSOVER, 0.3, MutationType.INVERSION,
            //    0.4, SelectionType.TOURNAMENT, 5));

            int[] numbersOfPopulations = { /*50, 100, 150,*/ 200 };
            var numberOfIndividulas = Enumerable.Range(1, 5).Select(x =>  x * 100).ToArray(); //[100 ... 1000]
            CrossoverType[] crossoverTypes = { CrossoverType.CYCLE_CROSSOVER, CrossoverType .ORDERED_CROSSOVER};
            var crossowrProbaility = Enumerable.Range(1, 4).Select(x => (double)x*2 / 10.0).ToArray(); // [0.1..0.9]
            MutationType[] mutationTypes = { MutationType.INVERSION, MutationType.SWAP };
            var swapProbaility = Enumerable.Range(1, 4).Select(x => (double)x*2 / 100.0).ToArray(); // [0.01..0.09]
            var inversionProbaility = Enumerable.Range(1, 4).Select(x => (double)(x*2) / 10.0).ToArray(); // [0.1..0.9]
            SelectionType[] selectionTypes = { SelectionType.ROULETTE, SelectionType.TOURNAMENT};
            var tournamentSize = Enumerable.Range(1, 4).Select(x => (double)x*2 / 10.0).ToArray(); // [0.1..0.9]


            //foreach (int iterationParameter in numbersOfPopulations)
            //{
            //    foreach (int numberOfIndividualsParameter in numberOfIndividulas)
            //    {

            //        foreach (SelectionType selectionTypeParameter in selectionTypes)
            //        {
            //            if (selectionTypeParameter == SelectionType.TOURNAMENT)
            //            {
            //                foreach (double tournamentSizeParameter in tournamentSize)
            //                {
            //                    foreach (CrossoverType crossoverTypeParamenter in crossoverTypes)
            //                    {
            //                        foreach (double crossowrProbailityParamenter in crossowrProbaility)
            //                        {
            //                            foreach (MutationType mutationTypeParamenter in mutationTypes)
            //                            {
            //                                if (mutationTypeParamenter == MutationType.INVERSION)
            //                                {
            //                                    foreach (double inversionProbailityParamenter in inversionProbaility)
            //                                    {
            //                                        configurationsList.Add(new GeneticConfiguration(AlgorithmType.GENETIC,
            //                                            3, iterationParameter, numberOfIndividualsParameter, crossoverTypeParamenter,
            //                                           crossowrProbailityParamenter, mutationTypeParamenter, inversionProbailityParamenter,
            //                                           selectionTypeParameter, tournamentSizeParameter));

            //                                    }
            //                                }
            //                                else 
            //                                {
            //                                    foreach (double swapProbailityParamenter in swapProbaility)
            //                                    {
            //                                        configurationsList.Add(new GeneticConfiguration(AlgorithmType.GENETIC,
            //                                            3, iterationParameter, numberOfIndividualsParameter, crossoverTypeParamenter,
            //                                           crossowrProbailityParamenter, mutationTypeParamenter, swapProbailityParamenter,
            //                                           selectionTypeParameter, tournamentSizeParameter));
            //                                    }
            //                                }

            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //            else 
            //            {
            //                foreach (CrossoverType crossoverTypeParamenter in crossoverTypes)
            //                {
            //                    foreach (double crossowrProbailityParamenter in crossowrProbaility)
            //                    {
            //                        foreach (MutationType mutationTypeParamenter in mutationTypes)
            //                        {
            //                            if (mutationTypeParamenter == MutationType.INVERSION)
            //                            {
            //                                foreach (double inversionProbailityParamenter in inversionProbaility)
            //                                {
            //                                    configurationsList.Add(new GeneticConfiguration(AlgorithmType.GENETIC,
            //                                        3, iterationParameter, numberOfIndividualsParameter, crossoverTypeParamenter,
            //                                       crossowrProbailityParamenter, mutationTypeParamenter, inversionProbailityParamenter,
            //                                       selectionTypeParameter));

            //                                }
            //                            }
            //                            else
            //                            {
            //                                foreach (double swapProbailityParamenter in swapProbaility)
            //                                {
            //                                    configurationsList.Add(new GeneticConfiguration(AlgorithmType.GENETIC,
            //                                        3, iterationParameter, numberOfIndividualsParameter, crossoverTypeParamenter,
            //                                       crossowrProbailityParamenter, mutationTypeParamenter, swapProbailityParamenter,
            //                                       selectionTypeParameter));
            //                                }
            //                            }

            //                        }
            //                    }
            //                }

            //            }
            //        }

            //    }
            //}


            foreach (int iterationParameter in numbersOfPopulations)
            {
                foreach (int numberOfIndividualsParameter in numberOfIndividulas)
                {

                    foreach (double tournamentSizeParameter in tournamentSize)
                    {
                        foreach (CrossoverType crossoverTypeParamenter in crossoverTypes)
                        {
                            foreach (double crossowrProbailityParamenter in crossowrProbaility)
                            {
                                foreach (double inversionProbailityParamenter in inversionProbaility)
                                {
                                    configurationsList.Add(new GeneticConfiguration(AlgorithmType.GENETIC,
                                        3, iterationParameter, numberOfIndividualsParameter, crossoverTypeParamenter,
                                       crossowrProbailityParamenter, MutationType.INVERSION, inversionProbailityParamenter,
                                       SelectionType.TOURNAMENT, tournamentSizeParameter));

                                }

                            }
                        }
                    }

                }
            }

            return configurationsList;
        }

        public static void testTabuSearch()
        {
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("TSTSTTSTSTTSTSTSTST");

            string[] problemsToSolve = {
                @"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n32-k5.vrp",
                //@"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n37-k6.vrp",
                 //@"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n39-k5.vrp",
                  @"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n45-k6.vrp",
                //   @"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n48-k7.vrp",
                    //@"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n54-k7.vrp",
                     @"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n60-k9.vrp"
            };





            List<SolverConfiguration> configurations = prepareTabuConfigurations();

            //List<SolverConfiguration> configurations = new List<SolverConfiguration>();
            //configurations.Add(new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 200, 500, 20, MutationType.INVERSION));
            //configurations.Add(new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 200, 500, 20, MutationType.SWAP, 0.04));
            Console.WriteLine("***Number of configurations=" + configurations.Count + "***\n");

            ProblemSolver solver = new ProblemSolver();

            solver.Configurations = configurations;

            solver.PathesToProblems = problemsToSolve;

            solver.run();

            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$");
        }

        public static List<SolverConfiguration> prepareTabuConfigurations()
        {
            List<SolverConfiguration> configurationsList = new List<SolverConfiguration>();

            //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 10, 200, 500, 20, MutationType.INVERSION);

            int[] numbersOfIterations = {/* 50, 100, 150,*/ 250 };
            var tabuListSize = Enumerable.Range(1, 9).Select(x => (double)x / 10).ToArray(); // [0.1..0.9]
            var numberOfNeighbors = Enumerable.Range(1, 9).Select(x => x * 100).ToArray(); // [10, 1000]
            MutationType[] mutationTypes = { MutationType.INVERSION, MutationType.SWAP };
            var swapProbaility = Enumerable.Range(1, 9).Select(x => (double)x / 100).ToArray(); // [0.01..0.09]

            foreach (int iterationParameter in numbersOfIterations)
            {
                foreach (double tabuListSizeParameter in tabuListSize)
                {
                    foreach (int numberOfNeighborsParameter in numberOfNeighbors)
                    {
                        foreach (MutationType mutationTypeParameter in mutationTypes)
                        {
                            if (mutationTypeParameter == MutationType.INVERSION)
                            {
                                configurationsList.Add(new TabuConfiguration(AlgorithmType.TABU_SEARCH, 3, iterationParameter,
                                    tabuListSizeParameter, numberOfNeighborsParameter, mutationTypeParameter));

                            }
                            else
                            {
                                foreach (double swapProbabilityParameter in swapProbaility)
                                {
                                    configurationsList.Add(new TabuConfiguration(AlgorithmType.TABU_SEARCH, 3, iterationParameter,
                                        tabuListSizeParameter, numberOfNeighborsParameter, mutationTypeParameter, swapProbabilityParameter));
                                }
                            }
                        }
                    }
                }
            }

            return configurationsList;
        }

        public static void testSimulatedAnnealing()
        {
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("SASASASASASASASASASASA");


            string[] problemsToSolve = {
                @"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n32-k5.vrp",
                //@"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n37-k6.vrp",
                 //@"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n39-k5.vrp",
                  @"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n45-k6.vrp",
                //   @"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n48-k7.vrp",
                    //@"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n54-k7.vrp",
                     @"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n60-k9.vrp"
            };


            List<SolverConfiguration> configurations = prepareSimulatedAnnealingConfigurations();
            //List<SolverConfiguration> configurations = new List<SolverConfiguration>();
            //configurations.Add(new SimulatedAnnealingConfiguration(10, 10000, 0.05, MutationType.INVERSION));
            //configurations.Add(new SimulatedAnnealingConfiguration(10, 10000, 0.1, MutationType.SWAP, 0.03));

            Console.WriteLine("***Number of configurations=" + configurations.Count + "***\n");


            ProblemSolver solver = new ProblemSolver();

            solver.Configurations = configurations;

            solver.PathesToProblems = problemsToSolve;

            solver.run();

            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$");
        }

        public static List<SolverConfiguration> prepareSimulatedAnnealingConfigurations()
        {
            List<SolverConfiguration> configurationsList = new List<SolverConfiguration>();

            //new SimulatedAnnealingConfiguration(10, 10000, 50);

            int[] numbersOfIterations = { /*50, 100, 150,*/ /*250*/ 40000 };
            var initialTemperatures = Enumerable.Range(1, 100).Select(x => (double) x).ToArray(); // [1..100]
            MutationType[] mutationTypes = { MutationType.INVERSION, MutationType.SWAP };
            var swapProbaility = Enumerable.Range(1, 9).Select(x => (double)x / 100).ToArray(); // [0.01..0.09]


            foreach (int iterationParameter in numbersOfIterations)
            {
                foreach (double initialTemperatureParameter in initialTemperatures)
                {
                    foreach (MutationType mutationTypeParameter in mutationTypes)
                    {
                        if (mutationTypeParameter == MutationType.INVERSION)
                        {
                            configurationsList.Add(new SimulatedAnnealingConfiguration(3, iterationParameter, initialTemperatureParameter,
                                mutationTypeParameter));

                        }
                        else
                        {
                            foreach (double swapProbabilityParameter in swapProbaility)
                            {
                                configurationsList.Add(new SimulatedAnnealingConfiguration(3, iterationParameter, initialTemperatureParameter,
                                mutationTypeParameter, swapProbabilityParameter));
                            }
                        }
                    }
                }
            }

            return configurationsList;
        }

    }
}
