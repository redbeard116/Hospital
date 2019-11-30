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
        private User User;

        private string _login;

        public AuthVM(IDialogService dialogService,
                      ISelectData selectData)
        {
            _dialogService = dialogService;
            _selectData = selectData;
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
            }
        }

        public User GetUser()
        {
            return User;
        }
    }
}