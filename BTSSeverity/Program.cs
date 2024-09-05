using BTSSeverity;
using BTSSeverity.Models;
using Newtonsoft.Json;
using System;
class Program
{
    static void Main()
    {

        string filePath = "C:/Users/Dell-pc/source/repos/BTSSeverity/BTSSeverity/defenceStrategiesBalanced.json";
        string json = File.ReadAllText(filePath);
        List<DefenceModel> defenses = JsonConvert.DeserializeObject<List<DefenceModel>>(json);
        DefenceStrategies strategy = new DefenceStrategies();
        foreach (var item in defenses)
        {
            Node node = new Node(item.MinSeverity, item.MaxSeverity, item.Defenses);
            strategy.Insert(node);
        }
        strategy.PrintTree();

    }
}