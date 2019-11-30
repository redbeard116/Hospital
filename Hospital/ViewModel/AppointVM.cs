using Hospital.Command;
using Hospital.DialogService;
using Hospital.Interface.Select;
using Hospital.View;
using System.Windows;
using Hospital.Model;
using Hospital.Interface.Insert;
using System.Collections.ObjectModel;

namespace Hospital.ViewModel
{
    public class AppointVM:ViewModelBase
    {
        private readonly IDialogService _dialogService;
        private readonly ISelectData _selectData;
        private readonly IInsertData _insertData;
        private Position _position;
        private User User;

        public AppointVM(IDialogService dialogService,
                      ISelectData selectData,
                      IInsertData insertData,
                      User user)
        {
            _dialogService = dialogService;
            _selectData = selectData;
            _insertData = insertData;
            User = user;
            Load();
        }
        
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string BirthDate { get; set; }
        public string NumerStr { get; set; }
        public string Description { get; set; }
        public Position SelectPosition
        {
            get =>_position;
            set
            {
                _position = value;
                OnPropertyChanged(nameof(SelectPosition));
            }
        }

        public ObservableCollection<Position> Positions { get; set; }

        public RelayCommand WriteCmd => new RelayCommand(Write);

        private void Write(object obj)
        {
            if (User == null)
            {
                var answer = MessageBox.Show("У вас уже есть аккаунт?", "", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (answer == MessageBoxResult.Yes)
                {
                    var authV = new Auth();
                    var authVM = new AuthVM(_dialogService, _selectData, _insertData,false);
                    authV.DataContext = authVM;
                    if (authV.ShowDialog().Value)
                    {
                        User = authVM.GetUser();
                        Appoint();
                    }
                }
                else if (answer == MessageBoxResult.No)
                {
                    var regV = new Registration();
                    var user = new User {FirstName = FirstName,SecondName= SecondName,BirthDate = BirthDate };
                    var regVM = new RegistrationVM(_dialogService, _selectData,_insertData, user);
                    regV.DataContext = regVM;
                    if (regV.ShowDialog().Value)
                    {
                        User = regVM.GetUser();
                        _insertData.InsertMedCart(new MedCard { UserId = User.UserId, CardNumber = NumerStr });
                        Appoint();
                    }
                } 
            }
            if (obj is Window view)
                view.Close();
            Continue();
        }

        private void Load()
        {
            Positions = new ObservableCollection<Position>();
            var staffs = _selectData.GetDoctors();
            foreach (var staff in staffs)
            {
                Positions.Add(staff);
            }
        }

        private void Continue()
        {
            var answer = MessageBox.Show("Продолжить?", "", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (answer == MessageBoxResult.Yes)
            {
                var profileVM = new ProfileVM(_dialogService, _selectData, _insertData, User);
                var profileV = new Profile()
                {
                    DataContext = profileVM
                };
                profileV.ShowDialog();
            }
        }

        private void Appoint()
        {
            var appoint = new Appointment
            {
                MedCardId = _selectData.GetMedCard(User.UserId),
                Description = Description,
                DoctorId = _selectData.GetAppointDoctor(SelectPosition.PositionId)
            };
            _insertData.AppointData(appoint);
        }
    }
}
