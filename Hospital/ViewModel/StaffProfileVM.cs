using Hospital.Command;
using Hospital.DialogService;
using Hospital.Interface.Insert;
using Hospital.Interface.Select;
using Hospital.Interface.Update;
using Hospital.Model;
using Hospital.View;
using System.Windows;
using System;

namespace Hospital.ViewModel
{
    public class StaffProfileVM:ViewModelBase
    {
        private readonly IDialogService _dialogService;
        private readonly ISelectData _selectData;
        private readonly IInsertData _insertData;

        public StaffProfileVM(IDialogService dialogService,
                              ISelectData selectData,
                              IInsertData inserData,
                              User user)
        {
            _dialogService = dialogService;
            _selectData = selectData;
            _insertData = inserData;
            User = user;
        }

        public User User { get; set; }

        public RelayCommand CloseCmd => new RelayCommand(Close);

        private void Close(object obj)
        {
            if (obj is Window view)
                view.Close();
        }

        public RelayCommand ProfileCmd => new RelayCommand(ProfileCM);

        private void ProfileCM(object obj)
        {
            var editVM = new EditProfileVM(new UpdateData(), User);
            var editV = new EditProfile
            {
                DataContext = editVM
            };
            editV.ShowDialog();
        }

        public RelayCommand SheduleCmd => new RelayCommand(Shedules);

        private void Shedules(object obj)
        {
            var sheduleVM = new SheduleVM(_dialogService, _selectData, User.UserId,true);
            var sheduleV = new Shedule
            {
                DataContext = sheduleVM
            };
            sheduleV.ShowDialog();
        }

        public RelayCommand StatemetCmd => new RelayCommand(Statemet);

        private void Statemet(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
