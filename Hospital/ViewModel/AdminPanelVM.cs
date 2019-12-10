using Hospital.Command;
using Hospital.DialogService;
using Hospital.Interface.Insert;
using Hospital.Interface.Select;
using Hospital.Model;
using System.Collections.ObjectModel;
using System;
using System.Windows.Controls;

namespace Hospital.ViewModel
{
    public class AdminPanelVM : ViewModelBase
    {
        private readonly IDialogService _dialogService;
        private readonly IInsertData _insertData;
        private readonly ISelectData _selectData;
        private Position _selectPosition;

        public AdminPanelVM(IDialogService dialogService,
                            IInsertData insertData,
                            ISelectData selectData)
        {
            _dialogService = dialogService;
            _insertData = insertData;
            _selectData = selectData;
            Load();
        }

        public ObservableCollection<Position> Positions { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime BirthDate { get; set; }
        public Position SelectPosition
        {
            get=>_selectPosition;
            set
            {
                _selectPosition = value;
                OnPropertyChanged(nameof(SelectPosition));
            }
        }
        public string Email { get; set; }
        public string Login { get; set; }


        private void Load()
        {
            Positions = new ObservableCollection<Position>();
            var staffs = _selectData.GetDoctors();
            foreach (var staff in staffs)
            {
                Positions.Add(staff);
            }
        }

        public RelayCommand SignUpCmd => new RelayCommand(SignUp);

        private void SignUp(object obj)
        {
            if (obj is PasswordBox passwordBox)
            {
                var user = new User
                {
                    FirstName = FirstName,
                    SecondName = SecondName,
                    BirthDate = BirthDate.ToString(),
                    Email = Email
                };
                var userId = _insertData.AddUser(user);
                var authM = new AuthM
                {
                    UserId = userId,
                    Login = Login,
                    Password = passwordBox.Password
                };
                _insertData.AddAuthData(authM);
                var staff = new Staff
                {
                    UserId = userId,
                    PositionId = SelectPosition.PositionId
                };
                _insertData.AddStaff(staff);
            }
            _dialogService.CloseWindow();
        }
    }
}