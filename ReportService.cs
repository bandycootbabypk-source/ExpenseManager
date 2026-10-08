using ExpenseManager.Models;
using System.Text;

namespace ExpenseManager.Services;

public class ReportService
{
    public decimal GetTotal(IEnumerable<Expense> expenses) => expenses.Sum(e => e.Amount);

    public Dictionary<ExpenseCategory, decimal> GetByCategory(IEnumerable<Expense> expenses) =>
        expenses.GroupBy(e => e.Category).ToDictionary(g => g.Key, g => g.Sum(e => e.Amount));

    public string BuildReport(IEnumerable<Expense> expenses)
    {
        var list = expenses.ToList();
        var sb = new StringBuilder();
        sb.AppendLine("Отчёт по расходам");
        sb.AppendLine($"Всего: {GetTotal(list):N2}");
        foreach (var item in GetByCategory(list).OrderByDescending(x => x.Value))
            sb.AppendLine($"{item.Key}: {item.Value:N2}");
        return sb.ToString();
    }
}
