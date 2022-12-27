using Algo.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algo.App.Services.DijkstraService
{
    public class DijkstraAlgo
    {
        public static int vertices;
        private static int MinDistance(double[] distanceList, bool[] shortestPathSet)
        {
            int minIndex = -1;
            double minDistance = double.MaxValue;
            for(int v = 0; v < vertices; v++)
            {
                if(shortestPathSet[v] == false && distanceList[v] <= minDistance)
                {
                    minDistance = distanceList[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }

        public static DijkstraAlgoResult Dijkstra(double[,] graph, int source, int destination)
        {
            vertices = graph.GetLength(0);
            double[] distanceList = new double[vertices];
            bool[] shortestPathSet = new bool[vertices];
            int[] parent = new int[vertices];
            for(int i = 0; i < vertices; i++)
            {
                distanceList[i] = double.MaxValue;
                shortestPathSet[i] = false;
            }
            distanceList[source] = 0;
            parent[source] = -1;
            for(int i = 0; i < vertices - 1; i++)
            {
                int u = MinDistance(distanceList,shortestPathSet);
                shortestPathSet[u] = true;
                for(int v = 0; v < vertices; v++)
                {
                    if (!shortestPathSet[v] && graph[u, v] != 0
                        && distanceList[u] != int.MaxValue
                        && distanceList[u] + graph[u, v] < distanceList[v])
                    {
                        parent[v] = u;
                        distanceList[v] = distanceList[u] + graph[u, v];
                    }
                }
            }
            DijkstraAlgoResult result = new DijkstraAlgoResult();
            result.distances = distanceList;
            result.parents = parent;
            return result;
        }
    }
}
