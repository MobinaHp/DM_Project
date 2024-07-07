namespace  Q2;
using System;
using System.Collections.Generic;

class Graph
{
    // Structure to represent an edge with two vertices
    struct Edge
    {
        public char Start;
        public char End;
        public Edge(char start, char end)
        {
            Start = start;
            End = end;
        }
    }

    static List<(char, char)> GetDualGraphEdges(List<Edge> edges)
    {
        Dictionary<char, List<char>> adjacencyList = new Dictionary<char, List<char>>();
        foreach (var edge in edges)
        {
            if (!adjacencyList.ContainsKey(edge.Start))
            {
                adjacencyList[edge.Start] = new List<char>();
            }
            if (!adjacencyList.ContainsKey(edge.End))
            {
                adjacencyList[edge.End] = new List<char>();
            }
            adjacencyList[edge.Start].Add(edge.End);
            adjacencyList[edge.End].Add(edge.Start);
        }

        List<(char, char)> dualEdges = new List<(char, char)>();
        foreach (var edge in edges)
        {
            dualEdges.Add((edge.Start, edge.End));
        }

        return dualEdges;
    }

    static void Main()
    {
        int EdgesCount = int.Parse(Console.ReadLine());
        List<Edge> edges = new List<Edge>();

        for (int i = 0; i < EdgesCount; i++)
        {
            string edgeInput = Console.ReadLine();
            edges.Add(new Edge(edgeInput[0], edgeInput[1]));
        }

        List<(char, char)> dualGraphEdges = GetDualGraphEdges(edges);
        Console.WriteLine(dualGraphEdges.Count);
    }
}
//هر یال در گراف دوگان متناظر با یک یال در گراف اصلی است پس برای هر یال در گراف اصلی یالی در گراف 
//دوگان آن وجود دارد پس تعداد یال‌ها رد گراف دوگان و گراف اصلی برابر است .
