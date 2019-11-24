using System;
using Hospital.Command;
using Hospital.DialogService;
using Hospital.Interface.Select;
using Hospital.Model;
using MahApps.Metro.Controls.Dialogs;
using System.Windows.Controls;

namespace Hospital.ViewModel
{
    public class AuthVM
    {
        private readonly IDialogService _dialogService;
        private readonly ISelectData _selectData;
        private IDialogCoordinator _dialogCoordinator;
        private User User;

        private string _login;

        public AuthVM(IDialogService dialogService,
                      ISelectData selectData,
                      IDialogCoordinator instance)
        {
            _dialogService = dialogService;
            _selectData = selectData;
            _dialogCoordinator = instance;
        }

        public string Login
        {
            get;set;
        }

        public RelayCommand AuthCmd => new RelayCommand(AuthCommand);

        private async void AuthCommand(object obj)
        {
            var passwordBox = obj as PasswordBox;
            if (_selectData.Auth(Login, passwordBox.Password, out User user))
            {
                User = user;
                await _dialogCoordinator.ShowMessageAsync(this, "HEADER", "MESSAGE");
            }
        }

        public User GetUser()
        {
            return User;
        }
    }
}