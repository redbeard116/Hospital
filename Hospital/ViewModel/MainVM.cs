using Hospital.Command;
using Hospital.DialogService;
using Hospital.View;
using Hospital.Interface.Select;
using MahApps.Metro.Controls.Dialogs;
using Hospital.Interface.Insert;
using Hospital.Interface.Update;

namespace Hospital.ViewModel
{
    public class MainVM:ViewModelBase
    {
        #region Открытие окна, пока не понял как использовать
        private readonly IDialogService _dialogService;
        #endregion

        private readonly ISelectData _selectData;
        private readonly IInsertData _insertData;
        private readonly IUpdateData _updateData;

        public MainVM(IDialogService dialog)
        {
            _dialogService = dialog;
            _selectData = new SelectData();
            _insertData = new InsertData();
            _updateData = new UpdateData();
        }

        public RelayCommand AuthorizationCmd => new RelayCommand(Authorization);

        private void Authorization(object obj)
        {
            var authVM = new AuthVM(_dialogService,_selectData,_insertData);
            var auth = new Auth() { DataContext = authVM};
            auth.ShowDialog();
        }

        public RelayCommand AppointmentCmd => new RelayCommand(Appointment);

        private void Appointment(object obj)
        {
            var appointVM = new AppointVM(_dialogService,_selectData,_insertData,null);
            var appoint = new Appoint() { DataContext = appointVM };
            appoint.ShowDialog();
        }
    }
}
