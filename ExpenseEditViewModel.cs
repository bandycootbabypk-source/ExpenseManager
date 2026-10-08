using ExpenseManager.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExpenseManager.ViewModels;

public class ExpenseEditViewModel : INotifyPropertyChanged
{
    public Expense Expense { get; }
    public ExpenseEditViewModel(Expense expense) => Expense = expense;
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
