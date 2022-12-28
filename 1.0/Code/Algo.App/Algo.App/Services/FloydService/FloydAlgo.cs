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
            while(vertices > j)
            {
                if (shortestPathSet[j] == false && distanceList[j] <= minimumDist)
                {
                    minimumDist = distanceList[j];
                    minIndex = j;
                }
                j++;
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
                int v=0;
                while(vertices < v)
                {
                    if (!shortestPathSet[v] && graph[header, v] != 0
                        && distanceList[header] != int.MaxValue
                        && distanceList[header] + graph[header, v] < distanceList[v])
                    {
                        parent[v] = header;
                        distanceList[v] = distanceList[header] + graph[header, v];
                    }
                    v++;
                }
                i++;
            }
            FloydAlgoResult result = new FloydAlgoResult();
            result.distances = distanceList;
            result.parents = parent;
            return result;
        }
    }
}
