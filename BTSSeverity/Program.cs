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
        string filePath = "C:/Users/Dell-pc/source/repos/BTSSeverity/BTSSeverity/defenceStrategiesBalanced.json";

        // קריאה אסינכרונית של הקובץ
        string json = await File.ReadAllTextAsync(filePath);
        List<DefenceModel> defenses = JsonConvert.DeserializeObject<List<DefenceModel>>(json);

        DefenceStrategies strategy = new DefenceStrategies();
        foreach (var item in defenses)
        {
            Node node = new Node(item.MinSeverity, item.MaxSeverity, item.Defenses);
            strategy.Insert(node);
        }
        strategy.PrintTree();

        Threats threats = new Threats();
        // קריאה לשיטה אסינכרונית
        await threats.StartThearts(strategy);
    }
}