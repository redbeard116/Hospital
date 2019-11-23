using Hospital.View;

namespace Hospital.DialogService
{
    public class DialogService : IDialogService
    {
        public void ShowWindow(object viewModel, object dataContex)
        {
            var view = new Auth();
            view.DataContext = dataContex;
            view.ShowDialog();
        }
    }
}
