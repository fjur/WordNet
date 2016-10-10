using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordNet
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectedGraph DG;

            using (System.IO.StreamReader SR = new System.IO.StreamReader("C:\\Users\\Filip\\Documents\\Visual Studio 2015\\Projects\\Algorithms 2\\Week 1\\WordNet\\WordNet\\TinyDG.txt"))
            {
                DG = new DirectedGraph(SR);
            }

            DepthFirstSearch DFS = new DepthFirstSearch(DG, 0);
        }
    }
}
