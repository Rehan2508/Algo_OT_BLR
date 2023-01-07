using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algo.App.Models;

namespace Algo.App.Services.TravellingService
{
    public class TravellingAlgo
    {
        public static int vertices;
		//static int N = 4;

		static void copyToFinal(int[] curr_path,int N,int[] final_path)
		{
			for (int i = 0; i < N; i++)
				final_path[i] = curr_path[i];
			final_path[N] = curr_path[0];
		}

		static double firstMin(double[,] adj, int i,int N)
		{
			double min = double.MaxValue;
			for (int k = 0; k < N; k++)
				if (adj[i, k] < min && i != k)
					min = adj[i, k];
			return min;
		}

		static double secondMin(double[,] adj, int i,int N)
		{
			
			double first = double.MaxValue, second = double.MaxValue;
			for (int j = 0; j < N; j++)
			{
				if (i == j)
					continue;

				if (adj[i, j] <= first)
				{
					second = first;
					first = adj[i, j];
				}
				else if (adj[i, j] <= second &&
						adj[i, j] != first)
					second = adj[i, j];
			}
			return second;
		}

		static void TSPRec(double[,] adj, double curr_bound, double curr_weight,
					int level, int[] curr_path,Boolean[] visited,int[] final_path,double final_res)
		{
			int N = adj.Length;
			if (level == N)
			{
				if (adj[curr_path[level - 1], curr_path[0]] != 0)
				{
					double curr_res = curr_weight +
							adj[curr_path[level - 1], curr_path[0]];

					if (curr_res < final_res)
					{
						copyToFinal(curr_path,N,final_path);
						final_res = curr_res;
					}
				}
				return;
			}

			for (int i = 0; i < N; i++)
			{
				if (adj[curr_path[level - 1], i] != 0 &&
						visited[i] == false)
				{
					double temp = curr_bound;
					curr_weight += adj[curr_path[level - 1], i];

					if (level == 1)
						curr_bound -= ((firstMin(adj, curr_path[level - 1],N) +
										firstMin(adj, i,N)) / 2);
					else
						curr_bound -= ((secondMin(adj, curr_path[level - 1],N) +
										firstMin(adj, i,N)) / 2);

					if (curr_bound + curr_weight < final_res)
					{
						curr_path[level] = i;
						visited[i] = true;

						TSPRec(adj, curr_bound, curr_weight, level + 1,
							curr_path,visited,final_path,final_res);
					}

					curr_weight -= adj[curr_path[level - 1], i];
					curr_bound = temp;

					Array.Fill(visited, false);
					for (int j = 0; j <= level - 1; j++)
						visited[curr_path[j]] = true;
				}
			}
		}
		public static TravellingAlgoResult Travelling(double[,] adj, int source, int destination)
        {

			int N = adj.Length;
			int[] final_path = new int[N + 1];
			double final_res = double.MaxValue;
			Boolean[] visited = new Boolean[N];
			int[] curr_path = new int[N + 1];

            double curr_bound = 0;
            Array.Fill(curr_path, -1);
            Array.Fill(visited, false);

            for (int i = 0; i < N; i++)
                curr_bound += (firstMin(adj, i,N) +
                            secondMin(adj, i,N));

            curr_bound = (curr_bound == 1) ? curr_bound / 2 + 1 :
                                        curr_bound / 2;

            visited[0] = true;
            curr_path[0] = 0;

            TSPRec(adj, curr_bound, 0, 1, curr_path,visited,final_path,final_res);
            TravellingAlgoResult result = new TravellingAlgoResult();
            //result.distances = distanceList;
            result.parents = final_path;
			result.min_cost = final_res;
            return result;
        }
    }
}
