using Hospital.Command;
using Hospital.DialogService;
using MahApps.Metro.Controls.Dialogs;
using Hospital.Interface.Select;
using Hospital.View;

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
        public string Position { get; set; }
        public string BirthDate { get; set; }
        public string NumerStr { get; set; }
        public string Description { get; set; }

        public RelayCommand WriteCmd => new RelayCommand(Write);

        private async void Write(object obj)
        {
            await _dialogCoordinator.ShowInputAsync(this,"","");
            if (true)
            {
                var authV = new Auth();
                var authVM = new AuthVM(_dialogService,_selectData,_dialogCoordinator);
                authV.DataContext = authVM;
                if (authV.ShowDialog()==true)
                {
                    var user = authVM.GetUser();
                }
            }
            else
            {
                var regV = new Registration();
                var regVM = new RegistrationVM(_dialogService,_selectData,_dialogCoordinator);
                regV.DataContext = regVM;
                if (regV.ShowDialog() == true)
                {

                }
            }
        }
    }
}
