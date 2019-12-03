﻿using Hospital.Command;
using Hospital.DialogService;
using Hospital.Interface.Select;
using Hospital.Model;
using System.Collections.ObjectModel;

namespace Hospital.ViewModel
{
    public class SheduleVM:ViewModelBase
    {
        private readonly IDialogService _dialogService;
        private readonly ISelectData _selectData;

        public SheduleVM(IDialogService dialogService,
                         ISelectData selectData,
                         int userId)
        {
            _dialogService = dialogService;
            _selectData = selectData;
            Shedules = new ObservableCollection<SheduleM>();
            Load(userId);
        }

        public ObservableCollection<SheduleM> Shedules { get; set; }

        private void Load(int userId)
        {
            var medcard = _selectData.GetMedCard(userId);
            var result = _selectData.GetShedule(medcard.CardId);
            foreach (var res in result)
                Shedules.Add(res);
        }
    }
}