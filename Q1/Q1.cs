namespace Q1;
using System;

public class MinimumSpanningTree
{
    public static int SpanningTree(int V, int E, int[,] edges)
    {
        int[,] adj = new int[V, V];
        for (int i = 0; i < V; i++)
        {
            for (int j = 0; j < V; j++)
            {
                adj[i, j] = int.MaxValue;
            }
        }

        for (int i = 0; i < E; i++)
        {
            int u = edges[i, 0] - 1; 
            int v = edges[i, 1] - 1;
            int wt = edges[i, 2];
            adj[u, v] = wt;
            adj[v, u] = wt;
        }

        int[] key = new int[V];
        bool[] mst = new bool[V];

        for (int i = 0; i < V; i++)
        {
            key[i] = int.MaxValue;
            mst[i] = false;
        }

        key[0] = 0;
        int res = 0;

        for (int count = 0; count < V; count++)
        {
            int u = MinKey(key, mst, V);

            mst[u] = true;

            for (int v = 0; v < V; v++)
            {
                if (adj[u, v] != int.MaxValue && !mst[v] && adj[u, v] < key[v])
                {
                    key[v] = adj[u, v];
                }
            }
        }

        for (int i = 0; i < V; i++)
        {
            res += key[i];
        }
        return res;
    }

    public static int MinKey(int[] key, bool[] mst, int V)
    {
        int min = int.MaxValue, minIndex = -1;

        for (int v = 0; v < V; v++)
        {
            if (mst[v] == false && key[v] < min)
            {
                min = key[v];
                minIndex = v;
            }
        }
        return minIndex;
    }

    public static void Main()
    {
        string[] firstLine = Console.ReadLine().Split();
        int V = int.Parse(firstLine[0]);
        int E = int.Parse(firstLine[1]);

        int[,] edges = new int[E, 3];
        for (int i = 0; i < E; i++)
        {
            string[] line = Console.ReadLine().Split();
            edges[i, 0] = int.Parse(line[0]);
            edges[i, 1] = int.Parse(line[1]);
            edges[i, 2] = int.Parse(line[2]);
        }
        Console.WriteLine(SpanningTree(V, E, edges));
    }
}
