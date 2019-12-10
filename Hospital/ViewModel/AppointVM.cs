using Hospital.Command;
using Hospital.DialogService;
using Hospital.Interface.Select;
using Hospital.View;
using System.Windows;
using Hospital.Model;
using Hospital.Interface.Insert;
using System.Collections.ObjectModel;
using System;

namespace Hospital.ViewModel
{
    public class AppointVM : ViewModelBase
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
        public DateTime BirthDate { get; set; }
        public string NumerStr { get; set; }
        public string Description { get; set; }
        public Position SelectPosition
        {
            get => _position;
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
                    var authVM = new AuthVM(_dialogService, _selectData, _insertData, false);
                    var result =_dialogService.ShowWindow(new Auth(), authVM);
                    if (result.HasValue)
                    {
                        User = authVM.GetUser();
                    }
                }
                else if (answer == MessageBoxResult.No)
                {
                    var user = new User { FirstName = FirstName, SecondName = SecondName, BirthDate = BirthDate.ToString() };
                    var regVM = new RegistrationVM(_dialogService, _selectData, _insertData, user,true);
                    var result = _dialogService.ShowWindow(new Registration(),regVM);
                    if (result.HasValue)
                    {
                        User = regVM.GetUser();
                        _insertData.InsertMedCart(new MedCard { UserId = User.UserId, CardNumber = NumerStr });
                    }
                }
            }
            Appoint();
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
            if (User != null)
            {
                NumerStr = _selectData.GetMedCard(User.UserId).CardNumber;
                FirstName = User.FirstName;
                SecondName = User.SecondName;
                DateTime.TryParse(User.BirthDate, out DateTime birthDate);
                BirthDate = BirthDate;
            }
        }

        private void Continue()
        {
            var answer = MessageBox.Show("Продолжить?", "", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (answer == MessageBoxResult.Yes)
            {
                var profileVM = new ProfileVM(_dialogService, _selectData, _insertData, User);
                _dialogService.ShowWindow(new Profile(),profileVM);
            }
        }

        private void Appoint()
        {
            var appoint = new Appointment
            {
                MedCardId = _selectData.GetMedCard(User.UserId).CardId,
                Description = Description,
                DoctorId = _selectData.GetAppointDoctor(SelectPosition.PositionId),
                Data = DateTime.Now.AddDays(+3).ToString()
            };
            _insertData.AppointData(appoint);
        }
    }
}
