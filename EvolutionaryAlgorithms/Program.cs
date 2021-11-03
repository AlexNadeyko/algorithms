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
                //@"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n32-k5.vrp",
                //@"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n37-k6.vrp",
                // @"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n39-k5.vrp",
                //  @"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n45-k6.vrp",
                   //@"C:\Users\Alex\source\repos\EvolutionaryAlgorithms\EvolutionaryAlgorithms\Problems\A-n48-k7.vrp",
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
                //new GeneticConfiguration(AlgorithmType.GENETIC, 10, 1000, 100, CrossoverType.CYCLE_CROSSOVER, 0.85, 0.7) //very good
                //new GeneticConfiguration(AlgorithmType.GENETIC, 1, 1000, 100, CrossoverType.CYCLE_CROSSOVER, 0.85, 0.7) // to check
                            
                //new TabuConfiguration(AlgorithmType.TABU_SEARCH, 1, 2000, 700, 100) // ok
                new SimulatedAnnealingConfiguration(1, 100000, 6) // very very good
                };

            ProblemSolver solver = new ProblemSolver();

            solver.Configurations = configurations;
            solver.PathesToProblems = problemsToSolve;

            solver.run();

        }
    }
}
