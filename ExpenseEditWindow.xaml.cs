using ExpenseManager.Models;
using ExpenseManager.ViewModels;
using System.Windows;

namespace ExpenseManager.Views;

public partial class ExpenseEditWindow : Window
{
    public ExpenseEditWindow(Expense expense)
    {
        InitializeComponent();
        DataContext = new ExpenseEditViewModel(expense);
    }
}
