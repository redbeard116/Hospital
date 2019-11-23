using System;

namespace Hospital.DialogService
{
    public interface IDialogService
    {
        void ShowWindow(object viewModel, object dataContex);
    }
}
