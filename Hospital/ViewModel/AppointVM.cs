using Hospital.Command;
using Hospital.DialogService;
using MahApps.Metro.Controls.Dialogs;
using Hospital.Interface.Select;
using Hospital.View;
using System.Windows;

namespace Hospital.ViewModel
{
    public class AppointVM
    {
        private readonly IDialogService _dialogService;
        private readonly ISelectData _selectData;

        public AppointVM(IDialogService dialogService,
                      ISelectData selectData)
        {
            _dialogService = dialogService;
            _selectData = selectData;
        }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Position { get; set; }
        public string BirthDate { get; set; }
        public string NumerStr { get; set; }
        public string Description { get; set; }

        public RelayCommand WriteCmd => new RelayCommand(Write);

        private void Write(object obj)
        {
            var answer = MessageBox.Show("У вас уже есть аккаунт?","",MessageBoxButton.YesNo,MessageBoxImage.Information);
            if (answer == MessageBoxResult.Yes)
            {
                var authV = new Auth();
                var authVM = new AuthVM(_dialogService,_selectData);
                authV.DataContext = authVM;
                if (authV.ShowDialog()==true)
                {
                    var user = authVM.GetUser();
                }
            }
            else if(answer == MessageBoxResult.No)
            {
                var regV = new Registration();
                var regVM = new RegistrationVM(_dialogService,_selectData);
                regV.DataContext = regVM;
                if (regV.ShowDialog() == true)
                {

                }
            }
        }
    }
}
