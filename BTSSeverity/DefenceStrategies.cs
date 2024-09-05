using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSSeverity
{
    public class DefenceStrategies
    {
        private Node _root;
        public DefenceStrategies()
        {
            _root = null;
        }
        public void Insert(Node newNode)
        {
            _root = InsertRecursiv(_root, newNode);


        }
        private Node InsertRecursiv(Node root, Node newNode)
        {
            if (root == null)
            {
                root = newNode;
                return root;
            }

            if (root.MinSeverity < newNode.MinSeverity)
            {
                root.Right = InsertRecursiv(root.Right, newNode);
            }
            else
            {
                root.Left = InsertRecursiv(root.Left, newNode);
            }
            return root;
        }
        public void PrintTree()
        {
            PrintTreeRec(_root, 0);
        }

        private void PrintTreeRec(Node node, int level)
        {
            if (node == null)
                return;

            Console.WriteLine(new string(' ', level * 2) + $"Severity {node.MinSeverity}-{node.MaxSeverity}: {string.Join(", ", node.Defenses)}");

            PrintTreeRec(node.Left, level + 1);
            PrintTreeRec(node.Right, level + 1);
        }

        public Node Find(int value)
        {
            return FindRecursiv(_root, value);
        }
        private Node FindRecursiv(Node root, int value)
        {
            if (root == null)
            {
                return root;
            }
            if (root.MinSeverity <= value && root.MaxSeverity >= value)
            {
                return root;
            }
            if (root.MaxSeverity < value)
            {
                return FindRecursiv(root.Right, value);
            }
            else
            {
                return FindRecursiv(root.Left, value);
            }
        }
        public int? GetMin()
        {
            return GetMinRecursiv(_root);
        }
        private int? GetMinRecursiv(Node node)
        {
            if (node == null)
            { return null; }
            if (node.Left == null)
            {
                return node.MinSeverity;
            }
            return GetMinRecursiv(node.Left);

        }
        //public int? GetMax()
        //{
        //    return MaxRecursiv(_root);
        //}
        //private int? MaxRecursiv(Node node)
        //{
        //    if (node == null) { return null; }
        //    if (node.Right == null)
        //    {
        //        return node.Value;
        //    }
        //    return MaxRecursiv(node.Right);
        //}

    }

}
