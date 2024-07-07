namespace Q3;
using System;

class graph
{
    static int V = 11; 

    int minDistance(int[] dist, bool[] sptSet)
    {
        int min = int.MaxValue, min_index = -1;

        for (int v = 0; v < V; v++)
            if (!sptSet[v] && dist[v] <= min)
            {
                min = dist[v];
                min_index = v;
            }
        return min_index;
    }

    int dijkstra(int[,] graph, int src, int dest)
    {
        int[] dist = new int[V];
        bool[] sptSet = new bool[V];

        for (int i = 0; i < V; i++)
        {
            dist[i] = int.MaxValue;
            sptSet[i] = false;
        }
        dist[src] = 0;

        for (int count = 0; count < V - 1; count++)
        {
            int u = minDistance(dist, sptSet);

            sptSet[u] = true;

            for (int v = 0; v < V; v++)
                if (!sptSet[v] && graph[u, v] != 0
                    && dist[u] != int.MaxValue
                    && dist[u] + graph[u, v] < dist[v])
                    dist[v] = dist[u] + graph[u, v];
        }
        return dist[dest];
    }
    static void Main()
    {
        graph g = new graph();
        int[,] graph = new int[,]
        {
            { 0, 4, 0, 0, 0, 0, 0, 8, 0, 0, 0 },
            { 4, 0, 8, 0, 0, 0, 0, 11, 0, 0, 0 },
            { 0, 8, 0, 7, 0, 4, 0, 0, 2, 0, 0 },
            { 0, 0, 7, 0, 9, 14, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 9, 0, 10, 0, 0, 0, 0, 0 },
            { 0, 0, 4, 14, 10, 0, 2, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 2, 0, 1, 6, 0, 0 },
            { 8, 11, 0, 0, 0, 0, 1, 0, 7, 8, 0 },
            { 0, 0, 2, 0, 0, 0, 6, 7, 0, 7, 8 },
            { 0, 0, 0, 0, 0, 0, 0, 8, 7, 0, 4 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 8, 4, 0 }
        };

        int dest = int.Parse(Console.ReadLine());
        int result = g.dijkstra(graph, 0, dest);

        Console.WriteLine($"{result}");
    }
}
