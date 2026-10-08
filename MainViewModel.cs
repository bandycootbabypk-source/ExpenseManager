using ExpenseManager.Models;
using ExpenseManager.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ExpenseManager.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly ReportService _reportService = new();
    private Expense? _selectedExpense;

    public ObservableCollection<Expense> Expenses { get; } = new();
    public ICommand AddCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand ReportCommand { get; }

    public Expense? SelectedExpense
    {
        get => _selectedExpense;
        set { _selectedExpense = value; OnPropertyChanged(); ((RelayCommand)DeleteCommand).RaiseCanExecuteChanged(); }
    }

    public decimal Total => _reportService.GetTotal(Expenses);

    public MainViewModel()
    {
        Expenses.Add(new Expense { Description = "Продукты", Amount = 1250, Category = ExpenseCategory.Food });
        Expenses.Add(new Expense { Description = "Проезд", Amount = 500, Category = ExpenseCategory.Transport });
        AddCommand = new RelayCommand(_ => AddExpense());
        DeleteCommand = new RelayCommand(_ => DeleteExpense(), _ => SelectedExpense != null);
        ReportCommand = new RelayCommand(_ => System.Windows.MessageBox.Show(_reportService.BuildReport(Expenses), "Отчёт"));
    }

    private void AddExpense()
    {
        Expenses.Add(new Expense { Description = "Новый расход", Amount = 0, Category = ExpenseCategory.Other });
        OnPropertyChanged(nameof(Total));
    }

    private void DeleteExpense()
    {
        if (SelectedExpense != null) Expenses.Remove(SelectedExpense);
        SelectedExpense = null;
        OnPropertyChanged(nameof(Total));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
