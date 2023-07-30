using System;
using System.Windows;
using System.Windows.Input;

namespace WPFMVVM.ViewModels;

public class LoginCommand: ICommand
{
    private readonly LoginViewModelFrameworkless context;

    public LoginCommand(LoginViewModelFrameworkless context)
    {
        this.context = context;
    }

    public bool CanExecute(object? parameter)
    {
        if (string.IsNullOrEmpty(context.Username) 
                              || string.IsNullOrEmpty(context.Password))
            return false;
        return true;
    }

    public void Execute(object? parameter)
    {
        //obsługa logowania
        MessageBox.Show($"Loguję: {context.Username}", "Logowanie");
    }

    public event EventHandler? CanExecuteChanged
    {
        add
        {
            CommandManager.RequerySuggested += value;
        }
        remove
        {
            CommandManager.RequerySuggested -= value;
        }
    }
}