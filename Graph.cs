using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordNet
{
    public class DirectedGraph
    {
        private readonly int _v;
        private readonly int _e;
        private Bag<int>[] adj;

        //Create an empty Graph
        public DirectedGraph(int v)
        {
            _v = v;
            _e = 0;
            adj = new Bag<int>[v];
            for (int i = 0; i < v; i++)
            {
                adj[i] = new Bag<int>();
            }
        }

        public DirectedGraph(StreamReader file)
        {
            string line;

            _v = Int32.Parse(file.ReadLine());
            _e = Int32.Parse(file.ReadLine());

            adj = new Bag<int>[_v];
            for (int i = 0; i < _v; i++)
            {
                adj[i] = new Bag<int>();
            }

            while ((line = file.ReadLine()) != null)
            {
                int entry1 = Int32.Parse(line.Substring(0, 2));
                int entry2 = Int32.Parse(line.Substring(2));
                AddEdge(entry1, entry2);
            }
        }

        public void AddEdge(int v, int w)
        {
            adj[v].add(w);
            // adj[w].add(v);
        }

        public IEnumerable<int> Adj(int v)
        {
            return adj[v];
        }

        public int V()
        {
            return _v;
        }

        public int E()
        {
            return _e;
        }
    }
}
