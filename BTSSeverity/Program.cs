using BTSSeverity;
using BTSSeverity.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        //שאיבת כל ההגנות מתוך קובץ והכנסה לרשימה
        Defenses defense = new Defenses();
        List<DefenceModel> defences = defense.StartDefenses();

        //השהייה בין פעולה לפעולה
        Console.WriteLine("insert defenses to tree");
        await Task.Delay(4000);

        //הכנסת כל ההגנות לעץ חיפוש בינארי
        DefenceStrategies tree = defense.InsertToTree(defences);


        Console.WriteLine("print the tree");
        await Task.Delay(4000);

        //הדפסת העץ
        tree.PrintTree();

        //מיון העץ
        tree.Balance();

        //הדפסת העץ הממוין
        tree.PrintTree();

        Console.WriteLine("the threats sent");
        await Task.Delay(4000);
        //שאיבה של כל ההתקפות והדפסת הגנה מתאימה
        Threats threats = new Threats();
        await threats.StartThearts(tree);
    }
}