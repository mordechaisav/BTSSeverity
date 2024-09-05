using BTSSeverity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSSeverity
{
    //יצירת מחלקה שמממשת את הפעולות של עץ בינארי
    public class DefenceStrategies
    {
        private Node _root;
        public DefenceStrategies()
        {
            _root = null;
        }

        //הכנסה לתוך העץ
        //o(log(n))
        public void Insert(Node newNode)
        {
            _root = InsertRecursiv(_root, newNode);


        }

        //פונקצייה רקורסיבית שמסייעת להכניס ערכים לעץ
        //o(log(n))
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
        //פונקציה שמדפיסה את כל העץ לפי המבנה של העץ
        //O(n)
        // O(n)
        public void PrintTree()
        {
            PrintTreeRecursiv(_root, "", true);
        }

        //פונקצייה רקורסיבית שמסייעת להדפסה
        //O(n)
        private void PrintTreeRecursiv(Node node, string indent, bool last)
        {
            if (node != null)
            {
                Console.Write(indent);
                if (last)
                {
                    Console.Write("└──Right");
                    indent += "   ";
                }
                else
                {
                    Console.Write("├──Left");
                    indent += "│  ";
                }
                Console.WriteLine(
                    $" Child: [{node.MinSeverity}-{node.MaxSeverity}] Defenses: {string.Join(", ", node.Defenses)}"
                );
                PrintTreeRecursiv(node.Left, indent, false);
                PrintTreeRecursiv(node.Right, indent, true);
            }
        }

        //פונקציה שמקבלת מספר ובודקת אם נמצא בטווח של אחת ההגנות
        //o(log(n))
        public Node Find(int value)
        {
            return FindRecursiv(_root, value);
        }
        //פונקציה רקורסיבית שעוזרת למצוא הגנה במערך
        //o(log(n))
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

        //פונקציה שמוצאת את ההגנה עם הטווח המינימלי הנמוך ביותר
        //o(log(n))
        public int? GetMin()
        {
            return GetMinRecursiv(_root);
        }

        //פונקציה שעוזרת למצוא את הטווח המינימלי
        //o(log(n))
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


        public void Balance()
        {
            var nodes = new List<DefenceModel>();
            StoreInOrder(_root, nodes);
            _root = BalanceRec(nodes, 0, nodes.Count - 1);
        }

        private void StoreInOrder(Node node, List<DefenceModel> nodes)
        {
            if (node == null)
                return;

            StoreInOrder(node.Left, nodes);
            DefenceModel model = new DefenceModel
            {
                MaxSeverity = node.MaxSeverity,
                MinSeverity = node.MinSeverity,
                Defenses = node.Defenses,
            };
            nodes.Add(model);
            StoreInOrder(node.Right, nodes);
        }

        private Node BalanceRec(List<DefenceModel> nodes, int start, int end)
        {
            if (start > end)
                return null;

            int mid = (start + end) / 2;
            Node node = new Node
            {
                MaxSeverity = nodes[mid].MaxSeverity,
                MinSeverity = nodes[mid].MinSeverity,
                Defenses = nodes[mid].Defenses,

            };

            node.Left = BalanceRec(nodes, start, mid - 1);
            node.Right = BalanceRec(nodes, mid + 1, end);

            return node;
        }
    }

}
