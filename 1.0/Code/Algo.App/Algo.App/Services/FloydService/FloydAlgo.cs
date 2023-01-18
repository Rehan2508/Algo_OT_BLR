using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algo.App.Models;
namespace Algo.App.Services.FloydService
{
    public class FloydAlgo
    {
        public static int vertices;
        static int[,] prnts = new int[23, 23];
        public static ArrayList reconstructShortestPath(int source, int destination)
        {
            var pathList = new ArrayList();
            for (int at = source; at != destination; at = prnts[at, destination])
                pathList.Add(at);
            pathList.Add(destination);
            return pathList;
        }
        public static FloydAlgoResult Floyd(double[,] graph, int source, int destination)
        {
            vertices = graph.GetLength(0);
            for (int g = 0; g < vertices; ++g)
            {
                for (int j = 0; j < vertices; ++j)
                {
                    if (g != j && graph[g, j] == 0)
                    {
                        graph[g, j] = 999999999;
                    }
                }
            }
            double[,] dist = new double[vertices, vertices];
            int a, b, k;
            for (a = 0; a < vertices; a++)
            {
                for (b = 0; b < vertices; b++)
                {
                    if (graph[a, b] != 999999999) prnts[a, b] = b;
                    dist[a, b] = graph[a, b];
                }
            }
            for (k = 0; k < vertices; k++)
            {
                for (a = 0; a < vertices; a++)
                {
                    for (b = 0; b < vertices; b++)
                    {
                        if (dist[a, k] + dist[k, b] < dist[a, b])
                        {
                            dist[a, b] = dist[a, k] + dist[k, b];
                            prnts[a, b] = prnts[a, k];
                        }
                    }
                }
            }
            ArrayList floydPath = reconstructShortestPath(source, destination);
            int[] obj1 = (int[])floydPath.ToArray(typeof(int));
            FloydAlgoResult result = new FloydAlgoResult();
            result.distances = dist;
            result.parents = obj1;
            return result;
        }
    }
}