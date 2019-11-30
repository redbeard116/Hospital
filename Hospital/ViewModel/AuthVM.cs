using Hospital.Command;
using Hospital.DialogService;
using Hospital.Interface.Select;
using Hospital.Model;
using System.Windows.Controls;
using Hospital.Interface.Insert;

namespace Hospital.ViewModel
{
    public class AuthVM
    {
        private readonly IDialogService _dialogService;
        private readonly ISelectData _selectData;
        private readonly IInsertData _insertData;
        private readonly bool IsOpen;
        private User User;

        public AuthVM(IDialogService dialogService,
                      ISelectData selectData,
                      IInsertData insertData,
                      bool isOpen = true)
        {
            _dialogService = dialogService;
            _selectData = selectData;
            _insertData = insertData;
            IsOpen = isOpen;
        }

        public string Login
        {
            get;set;
        }

        public RelayCommand AuthCmd => new RelayCommand(AuthCommand);

        private void AuthCommand(object obj)
        {
            var passwordBox = obj as PasswordBox;
            if (_selectData.Auth(Login, passwordBox.Password, out User user))
            {
                User = user;
                if (IsOpen)
                {
                    var profileVM = new ProfileVM(_dialogService, _selectData, _insertData, User);
                    var profileV = new Profile()
                    {
                        DataContext = profileVM
                    };
                    profileV.ShowDialog(); 
                }
            }
        }

        public User GetUser()
        {
            return User;
        }
    }
}