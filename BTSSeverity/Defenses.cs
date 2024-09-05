using BTSSeverity.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSSeverity
{
    //מחלקה שמטפלת בפונקציות של הגנה
    internal class Defenses
    {
        //שליפת ההגנות מתוך קובץ והחזה של רשימה שלהם 
        ////O(n)
        public List<DefenceModel> StartDefenses()
        {
            string filePath = "C:/Users/Dell-pc/source/repos/BTSSeverity/BTSSeverity/defenceStrategiesBalanced.json";


            string json = File.ReadAllText(filePath);
            List<DefenceModel> defenses = JsonConvert.DeserializeObject<List<DefenceModel>>(json);
            return defenses;
        }

        //הכנסה של כל ההגנות לתוך עץ בינארי והחזרה של העץ
        //O(n)
        public DefenceStrategies InsertToTree(List<DefenceModel> defenses)
        {
            DefenceStrategies tree = new DefenceStrategies();
            foreach (var item in defenses)
            {
                Node node = new Node(item.MinSeverity, item.MaxSeverity, item.Defenses);
                tree.Insert(node);

            }
            return tree;
        }

    }
}
