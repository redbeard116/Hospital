using Hospital.Command;
using Hospital.DialogService;
using Hospital.Interface.Insert;
using Hospital.Interface.Select;
using Hospital.Model;
using System.Windows.Controls;

namespace Hospital.ViewModel
{
    public class RegistrationVM
    {
        private readonly IDialogService _dialogService;
        private readonly ISelectData _selectData;
        private readonly IInsertData _insertData;
        private readonly bool IsProf;
        private User User;


        public RegistrationVM(IDialogService dialogService,
                      ISelectData selectData,
                      IInsertData insertData,
                      User user,
                      bool isProf = false)
        {
            _dialogService = dialogService;
            _selectData = selectData;
            _insertData = insertData;
            IsProf = isProf;
            User = user;
        }

        public string Email { get; set; }
        public string Login { get; set; }

        public RelayCommand SignUpCmd => new RelayCommand(SignUp);

        private void SignUp(object obj)
        {
            User.Email = Email;
            User.UserId = _insertData.Registration(User);
            var passwordBox = obj as PasswordBox;
            _insertData.SetAuthData(new AuthM {UserId = User.UserId,Login = Login,Password = passwordBox.Password });
            if (!IsProf)
            {
                var profileVM = new ProfileVM(_dialogService, _selectData, _insertData, User);
                _dialogService.ShowWindow(new Profile(), profileVM);
            }
            _dialogService.CloseWindow();
        }

        public User GetUser()
        {
            return User;
        }
    }
}
