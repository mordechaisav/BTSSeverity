using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSSeverity
{
    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int MinSeverity {  get; set; }
        public int MaxSeverity { get; set; }
        public List<string> Defenses { get; set; }
        public Node() { }

        public Node(int minSeverity, int maxSeverity, List<string> defenses)
        {
            Left = null;
            Right = null;
            MinSeverity = minSeverity;
            MaxSeverity = maxSeverity;
            Defenses = defenses;
        }
    }
}
