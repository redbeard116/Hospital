using System;
using Hospital.DialogService;

namespace Hospital.ViewModel
{
    public class AppointVM
    {
        private readonly IDialogService _dialogService;
        public AppointVM(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }
    }
}
