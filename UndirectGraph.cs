using System;
using System.Collections.Generic;
namespace Lab_graph
{
    public class UndirectGraph  
    {
       int _vertex;   
        List<int>[] _adjacentMatrix;

      
        public UndirectGraph(int v)
        {
            _vertex = v;
            _adjacentMatrix = new List<int>[v];
            for (int i = 0; i < v; ++i)
                _adjacentMatrix[i] = new List<int>();
            InitGraph();
        }
        private void InitGraph()
        {
            _adjacentMatrix = new List<int>[_vertex];
            for (int i = 0; i < _vertex; i++)
                _adjacentMatrix[i] = new List<int>();
        }
        public void AddEdge(int u, int v)
        {
            _adjacentMatrix[u].Add(v);
            _adjacentMatrix[v].Add(u);
        }
        private void RemoveEdge(int u, int v)
        {
            _adjacentMatrix[u].Remove(v);
            _adjacentMatrix[v].Remove(u);
        }
        public void PrintEulerTour()
        {
            int u = 0;
            for (int i = 0; i < _vertex; i++)
                if (_adjacentMatrix[i].Count % 2 == 1)
                {
                    u = i;
                    break;
                }
            PrintEulerUtil(u);
           
        }
        public int temp;
        private void PrintEulerUtil(int u)
        {
           
            for (int i = 0; i < _adjacentMatrix[u].Count; i++)
            {
                int v = _adjacentMatrix[u][i];
               
                if (IsValidNextEdge(u, v))
                {
                    Console.Write(u + " ");
                    temp = v;
                    
                    RemoveEdge(u, v);
                    PrintEulerUtil(v);
                }
               
            }   
        }
        private bool IsValidNextEdge(int u, int v)
        {
            if (_adjacentMatrix[u].Count == 1)
                return true;
            bool[] isVisited = new bool[this._vertex];
            int count1 = DFSCount(u, isVisited);
            RemoveEdge(u, v);
            isVisited = new bool[this._vertex];
            int count2 = DFSCount(u, isVisited);
            RemoveEdge(u, v);
            if (count1 > count2)
                return false;
            else
                return true;
        }
        private int DFSCount(int v, bool[] isVisited)
        {
            isVisited[v] = true;
            int count = 1;
            foreach (int i in _adjacentMatrix[v])
                if (!isVisited[i])
                    count = count + DFSCount(i, isVisited);
            return count;
        }
        void DFSUtil(int v, bool[] visited)
        {
            visited[v] = true;
            foreach (int i in _adjacentMatrix[v])
            {
                int n = i;
                if (!visited[n])
                    DFSUtil(n, visited);
            }
        }
        bool IsConnected()
        {
            bool[] visited = new bool[_vertex];
            int i;
            for (i = 0; i < _vertex; i++)
                visited[i] = false;
            for (i = 0; i < _vertex; i++)
                if (_adjacentMatrix[i].Count != 0)
                    break;
            if (i == _vertex)
                return true;
            DFSUtil(i, visited);
            for (i = 0; i < _vertex; i++)
                if (visited[i] == false && _adjacentMatrix[i].Count > 0)
                    return false;
            return true;
        }
        int IsEulerian()
        {
            if (IsConnected() == false)
                return 0;
            int odd = 0;
            for (int i = 0; i < _vertex; i++)
                if (_adjacentMatrix[i].Count % 2 != 0)
                    odd++;
            if (odd > 2)
                return 0;
            return (odd == 2) ? 1 : 2;
        }
        public char test()
        {
            int result = IsEulerian();char res;
            if (result == 0)
            {
                Console.WriteLine(" This graph is not Eulerian");
                res = 'n';
            }
            else if (result == 1)
            {
                Console.WriteLine(" This graph has a Euler path");
                res = 'p';
            }
            else
            {
                Console.WriteLine(" This graph has a Euler cycle");
                res = 'c';
            }
            return res;
        }

    }
}
