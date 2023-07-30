using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WPFMVVM.ViewModels;

public partial class LoginViewModel: ObservableObject
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    [NotifyPropertyChangedFor(nameof(UsernamePassword))]
    private string username;
    [ObservableProperty] 
    [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    [NotifyPropertyChangedFor(nameof(UsernamePassword))]
    private string password;

    public string UsernamePassword => $"{username} {password}";

    [RelayCommand(CanExecute = nameof(CanLogin))]
    private void Login()
    {
        //Obsługa logowania
        MessageBox.Show($"Loguję: {Username}", "Logowanie");
    }

    private bool CanLogin()
    {
        if (string.IsNullOrEmpty(Username) 
            || string.IsNullOrEmpty(Password))
            return false;
        return true;
    }
}