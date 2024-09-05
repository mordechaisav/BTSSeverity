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
        public void PrintTree()
        {
            PrintTreeRec(_root, 0);
        }

        //פונקצייה רקורסיבית שמסייעת להדפסה
        //O(n)
        private void PrintTreeRec(Node node, int level)
        {
            if (node == null)
                return;

            Console.WriteLine(new string(' ', level * 2) + $"Severity {node.MinSeverity}-{node.MaxSeverity}: {string.Join(", ", node.Defenses)}");

            PrintTreeRec(node.Left, level + 1);
            PrintTreeRec(node.Right, level + 1);
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
    }

}
