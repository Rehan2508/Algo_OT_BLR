using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algo.App.Models;

namespace Algo.App.Services.FloydService
{
    public class FloydAlgo
    {
        public static int vertices;
        private static int MinimumDist(double[] distanceList, bool[] shortestPathSet)
        {
            int minIndex = -1;
            double minimumDist = double.MaxValue;
            for (int v = 0; v < vertices; v++)
            {
                if (shortestPathSet[v] == false && distanceList[v] <= minimumDist)
                {
                    minimumDist = distanceList[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }
        public static FloydAlgoResult Floyd(double[,] graph, int source, int destination)
        {
            int t = 0, i = 0;
            vertices = graph.GetLength(0);
            double[] distanceList = new double[vertices];
            bool[] shortestPathSet = new bool[vertices];
            int[] parent = new int[vertices];
            while (t < vertices)
            {
                distanceList[t] = double.MaxValue;
                shortestPathSet[t] = false;
                t++;
            }
            distanceList[source] = 0;
            parent[source] = -1;
            while (i < vertices - 1)
            {
                int header = MinimumDist(distanceList, shortestPathSet);
                shortestPathSet[header] = true;
                for (int v = 0; v < vertices; v++)
                {
                    if (!shortestPathSet[v] && graph[header, v] != 0
                        && distanceList[header] != int.MaxValue
                        && distanceList[header] + graph[header, v] < distanceList[v])
                    {
                        parent[v] = header;
                        distanceList[v] = distanceList[header] + graph[header, v];
                    }
                }
            }
            FloydAlgoResult result = new FloydAlgoResult();
            result.distances = distanceList;
            result.parents = parent;
            return result;
        }
    }
}
