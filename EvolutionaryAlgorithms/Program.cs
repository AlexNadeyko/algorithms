using EvolutionaryAlgorithms.SolverSystem;
using EvolutionaryAlgorithms.SolverSystem.Algorithms;
using EvolutionaryAlgorithms.SolverSystem.Configurations;
using System;

namespace EvolutionaryAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] problemsToSolve = {
                @"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n32-k5.vrp",
                //@"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n37-k6.vrp",
                 @"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n39-k5.vrp",
                  //@"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n45-k6.vrp",
                //   @"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n48-k7.vrp",
                    //@"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n54-k7.vrp",
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
                new SimulatedAnnealingConfiguration(10, 500000, 5),
                new SimulatedAnnealingConfiguration(10, 500000, 10),
                new SimulatedAnnealingConfiguration(10, 500000, 30),
                 new SimulatedAnnealingConfiguration(10, 500000, 50),
                  new SimulatedAnnealingConfiguration(10, 500000, 100),
                   new SimulatedAnnealingConfiguration(10, 500000, 200),
            };

            ProblemSolver solver = new ProblemSolver();

            solver.Configurations = configurations;
            solver.PathesToProblems = problemsToSolve;

            solver.run();

        }
    }
}
