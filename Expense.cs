namespace ExpenseManager.Models;

public class Expense
{
    public string Description { get; set; } = "";
    public decimal Amount { get; set; }
    public ExpenseCategory Category { get; set; }
    public DateTime Date { get; set; } = DateTime.Today;
}
