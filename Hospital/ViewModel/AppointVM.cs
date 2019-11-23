using Hospital.Command;
using Hospital.DialogService;
using MahApps.Metro.Controls.Dialogs;
using Hospital.Interface.Select;
using System;

namespace Hospital.ViewModel
{
    public class AppointVM
    {
        private readonly IDialogService _dialogService;
        private readonly ISelectData _selectData;
        private IDialogCoordinator _dialogCoordinator;

        public AppointVM(IDialogService dialogService,
                      ISelectData selectData,
                      IDialogCoordinator instance)
        {
            _dialogService = dialogService;
            _selectData = selectData;
            _dialogCoordinator = instance;
        }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }
        public string NumerStr { get; set; }

        public RelayCommand WriteCmd => new RelayCommand(Write);

        private void Write(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
