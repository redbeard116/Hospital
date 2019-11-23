﻿using Hospital.Command;
using Hospital.DialogService;
using Hospital.View;

namespace Hospital.ViewModel
{
    public class MainVM:ViewModelBase
    {
        #region Открытие окна, пока не понял как использовать
        private readonly IDialogService _dialogService; 
        #endregion

        public MainVM(IDialogService dialog)
        {
            _dialogService = dialog;
        }

        public RelayCommand AuthorizationCmd => new RelayCommand(Authorization);

        private void Authorization(object obj)
        {
            var authVM = new AuthVM(_dialogService);
            var auth = new Auth() { DataContext = authVM};
            auth.ShowDialog();
        }

        public RelayCommand AppointmentCmd => new RelayCommand(Appointment);

        private void Appointment(object obj)
        {
            var appointVM = new AppointVM(_dialogService);
            var appoint = new Appoint() { DataContext = appointVM };
            appoint.ShowDialog();
        }
    }
}