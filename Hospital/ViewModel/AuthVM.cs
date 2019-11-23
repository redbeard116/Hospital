﻿using Hospital.Command;
using Hospital.DialogService;

namespace Hospital.ViewModel
{
    public class AuthVM:ViewModelBase
    {
        private readonly IDialogService _dialogService;

        public AuthVM(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }
    }
}
