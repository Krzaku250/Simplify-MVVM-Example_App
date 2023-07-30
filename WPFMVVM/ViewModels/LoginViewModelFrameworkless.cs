using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace WPFMVVM.ViewModels;

public class LoginViewModelFrameworkless : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    private string username;

    public string Username
    {
        get => username;
        set => SetProperty(ref username, value);
    }

    private string password;

    public string Password
    {
        get => password;
        set => SetProperty(ref password, value);
    }

    private ICommand loginCommand;

    public ICommand LoginCommand
    {
        get
        {
            if (loginCommand is null)
                loginCommand = new RelayCommand(
                    arg =>
                    {
                        //Obsługa logowania
                        MessageBox.Show($"Loguję: {Username}", "Logowanie");
                    },
                    arg =>
                    {
                        if (string.IsNullOrEmpty(Username)
                            || string.IsNullOrEmpty(Password))
                            return false;
                        return true;
                    });
            //loginCommand = new LoginCommand(this);
            return loginCommand;
        }
    }

    // public string Username 
    // {  
    //     get  
    //     {  
    //         return username;  
    //     }  
    //     set  
    //     {  
    //         username = value;  
    //         OnPropertyChanged("Username");  
    //     }  
    // }
}