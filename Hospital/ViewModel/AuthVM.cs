using Hospital.Command;
using Hospital.DialogService;
using Hospital.Interface.Select;
using Hospital.Model;
using System.Windows.Controls;
using Hospital.Interface.Insert;
using Hospital.View;

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
                    _dialogService.CloseWindow();
                    if (!_selectData.IsStaff(User.UserId))
                    {
                        var profileVM = new ProfileVM(_dialogService, _selectData, _insertData, User);
                        _dialogService.ShowWindow(new Profile(),profileVM);
                    }
                    else
                    {
                        var profileVM = new StaffProfileVM(_dialogService, _selectData, _insertData, User);
                        _dialogService.ShowWindow(new StaffProfile(),profileVM);
                    }
                }
                _dialogService.CloseWindow();
            }
        }

        public User GetUser()
        {
            return User;
        }
    }
}