using Hospital.Command;
using Hospital.DialogService;
using Hospital.Interface.Select;
using Hospital.Model;
using System.Windows;
using System;
using Hospital.View;
using Hospital.Interface.Insert;
using Hospital.Interface.Update;

namespace Hospital.ViewModel
{
    public class ProfileVM:ViewModelBase
    {
        private readonly IDialogService _dialogService;
        private readonly ISelectData _selectData;
        private readonly IInsertData _insertData;
        private User _user;

        public ProfileVM(IDialogService dialogService,
                         ISelectData selectData,
                         IInsertData insertData,
                         User user)
        {
            _dialogService = dialogService;
            _selectData = selectData;
            _insertData = insertData;
            User = user;
        }

        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        public RelayCommand CloseCmd => new RelayCommand(Close);

        private void Close(object obj)
        {
            if (obj is Window view)
                view.Close();
        }

        public RelayCommand ProfileCmd => new RelayCommand(ProfileCM);

        private void ProfileCM(object obj)
        {
            var editVM = new EditProfileVM(new UpdateData(),User);
            var editV = new EditProfile
            {
                DataContext = editVM
            };
            editV.ShowDialog();
        }

        public RelayCommand AppointCmd => new RelayCommand(AppointDoctor);

        private void AppointDoctor(object obj)
        {
            var appointVM = new AppointVM(_dialogService, new SelectData(),_insertData,User);
            var appoint = new Appoint() { DataContext = appointVM };
            appoint.ShowDialog();
        }

        public RelayCommand SheduleCmd => new RelayCommand(Shedules);

        private void Shedules(object obj)
        {
            var sheduleVM = new SheduleVM(_dialogService, _selectData, User.UserId);
            var sheduleV = new Shedule
            {
                DataContext = sheduleVM
            };
            sheduleV.ShowDialog();
        }

        public RelayCommand HistoryCmd => new RelayCommand(Historys);

        private void Historys(object obj)
        {
            var historyVM = new MedicalHistoryVM(_dialogService,_selectData,User.UserId);
            var historyV = new MedicalHistory
            {
                DataContext = historyVM
            };
            historyV.ShowDialog();
        }
    }
}
