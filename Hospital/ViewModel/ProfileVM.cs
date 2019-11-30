using Hospital.Command;
using Hospital.DialogService;
using Hospital.Interface.Select;
using Hospital.Model;
using System.Windows;
using System;
using Hospital.View;
using Hospital.Interface.Insert;

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
            throw new NotImplementedException();
        }

        public RelayCommand AppointCmd => new RelayCommand(AppointDoctor);

        private void AppointDoctor(object obj)
        {
            var appointVM = new AppointVM(_dialogService, new SelectData(),_insertData,User);
            var appoint = new Appoint() { DataContext = appointVM };
            appoint.ShowDialog();
        }
    }
}
