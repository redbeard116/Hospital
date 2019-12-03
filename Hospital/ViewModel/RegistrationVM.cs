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
        private User User;


        public RegistrationVM(IDialogService dialogService,
                      ISelectData selectData,
                      IInsertData insertData,
                      User user)
        {
            _dialogService = dialogService;
            _selectData = selectData;
            _insertData = insertData;
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
            var profileVM = new ProfileVM(_dialogService, _selectData, _insertData, User);
            var profileV = new Profile()
            {
                DataContext = profileVM
            };
            profileV.ShowDialog();
        }

        public User GetUser()
        {
            return User;
        }
    }
}
