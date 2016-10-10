using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordNet
{
    public class DepthFirstSearch
    {
        bool[] marked;
        int[] edgeTo;
        int s;

        public DepthFirstSearch(DirectedGraph G, int s)
        {
            //initialize data structures
            marked = new bool[G.V()];
            //run DFS
            dfs(G, s);

        }

        private void dfs(DirectedGraph G, int v)
        {
            marked[v] = true;
            foreach (int edge in G.Adj(v))
            {
                if (!marked[edge])
                {
                    dfs(G, edge);
                }
            }
        }

        public bool visited(int s)
        {
            return marked[s];
        }
    }
}
