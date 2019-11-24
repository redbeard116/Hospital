using Hospital.Command;
using Hospital.DialogService;
using Hospital.Interface.Select;
using Hospital.Model;
using MahApps.Metro.Controls.Dialogs;
using System.Windows.Controls;

namespace Hospital.ViewModel
{
    public class RegistrationVM
    {
        private readonly IDialogService _dialogService;
        private readonly ISelectData _selectData;
        private IDialogCoordinator _dialogCoordinator;
        private User User;


        public RegistrationVM(IDialogService dialogService,
                      ISelectData selectData,
                      IDialogCoordinator instance)
        {
            _dialogService = dialogService;
            _selectData = selectData;
            _dialogCoordinator = instance;
        }

        public string Email { get; set; }
        public string Login { get; set; }

        public RelayCommand SignUpCmd => new RelayCommand(SignUp);

        private void SignUp(object obj)
        {
            var passwordBox = obj as PasswordBox;

        }

        public User GetUser()
        {
            return User;
        }
    }
}
