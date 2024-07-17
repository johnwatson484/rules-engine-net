using RulesEngine.Models;
using System.Text.Json;

var workflowRulesFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Rules", "discount.json");
var workflowRules = JsonSerializer.Deserialize<List<Workflow>>(await File.ReadAllTextAsync(workflowRulesFile));

var re = new RulesEngine.RulesEngine(workflowRules.ToArray());

var resultList = await re.ExecuteAllRulesAsync("Discount", new { country = "india", loyaltyFactor = 1, totalPurchasesToDate = 5000 }, new { totalOrders = 5 }, new { noOfVisitsPerMonth = 10 });

foreach (var result in resultList)
{
    Console.WriteLine($"Rule - {result.Rule.RuleName}, IsSuccess - {result.IsSuccess}");
}
