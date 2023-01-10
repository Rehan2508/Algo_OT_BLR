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
			int j = 0;
			while (vertices > j)
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
			// Converting no path (which is zero) into Infinite 
			for (int g = 0; g < vertices; ++g)
			{
				for (int j = 0; j < vertices; ++j)
				{
					if (g != j && graph[g, j] == 0)
					{
						graph[g, j] = 999999999;
					}
				}
			}
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
				int v = 0;
				while (vertices > v)
				{
					if (!shortestPathSet[v] && graph[header, v] != 0 && distanceList[header] != int.MaxValue
				  && distanceList[header] + graph[header, v] < distanceList[v])
					{
						parent[v] = header;
						distanceList[v] = distanceList[header] + graph[header, v];
					}
					v++;
				}
				i++;
			}
			double[,] dist = new double[vertices, vertices];
			int a, b, k;
			for (a = 0; a < vertices; a++)
			{
				for (b = 0; b < vertices; b++)
				{
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
						}
					}
				}
			}
			FloydAlgoResult result = new FloydAlgoResult();
			result.distances = dist;
			result.parents = parent;
			return result;
		}
	}
}