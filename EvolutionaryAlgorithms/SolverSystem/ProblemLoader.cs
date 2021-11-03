using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithms.SolverSystem
{
    class ProblemLoader
    {
        private static readonly int NAME_ROW = 0;
        private static readonly int DIMENSION_ROW = 3;
        private static readonly int CAPACITY_ROW = 5;
        private static readonly int FIRST_NODE_COORDINATES_ROW = 7;

        private string[] _linesArray;

        public string NameOfProblem
        { get; private set; }

        public int Capacity
        { get; private set; }

        public (int, int)[] CoordinatesOfNodes
        { get; private set; }

        public int[] DemandsOfNodes
        { get; private set; }

        public int Dimension
        { get; private set; }

        public void loadProblem(string path)
        {
            readFile(path);
            parseProblem();
        }

        private void readFile(string path)
        {
            IEnumerable<string> lines = File.ReadLines(path);

            _linesArray = lines.ToArray();
        }

        private void parseProblem()
        {
            parseProblemName();
            parseDimension();
            parseCapacity();
            parseCoordinationsOfNodes();
            parseDemandsOfNodes();
        }

        private void parseProblemName()
        {
            string[] splittedLine = _linesArray[NAME_ROW].Split(' ');

            NameOfProblem = splittedLine[2];
        }

        private void parseDimension()
        {
            string[] splittedLine = _linesArray[DIMENSION_ROW].Split(' ');

            Dimension = Int32.Parse(splittedLine[2]);
        }

        private void parseCapacity()
        {
            string[] splittedLine = _linesArray[CAPACITY_ROW].Split(' ');

            Capacity = Int32.Parse(splittedLine[2]);
        }

        private void parseCoordinationsOfNodes()
        {
            (int, int)[] coordinates = new (int, int)[Dimension];
            int nodeIndex = 0;
            string[] splittedLine = null;

            for (int rowIndex = FIRST_NODE_COORDINATES_ROW; rowIndex < FIRST_NODE_COORDINATES_ROW + Dimension; rowIndex++)
            {
                splittedLine = _linesArray[rowIndex].Split(' ');

                (int, int) coordinate = (Int32.Parse(splittedLine[2]), Int32.Parse(splittedLine[3]));

                coordinates[nodeIndex++] = coordinate;
            }

            CoordinatesOfNodes = coordinates;
        }

        private void parseDemandsOfNodes()
        {
            int[] demands = new int[Dimension];
            int nodeIndex = 0;
            int firstDemandRow = FIRST_NODE_COORDINATES_ROW + Dimension + 1;

            for (int rowIndex = firstDemandRow; rowIndex < firstDemandRow + Dimension; rowIndex++)
            {
                string[] splittedLine = _linesArray[rowIndex].Split(' ');

                demands[nodeIndex++] = Int32.Parse(splittedLine[1]);
            }

            DemandsOfNodes = demands;
        }
    }
}
