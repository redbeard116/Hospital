using Hospital.Command;
using Hospital.DialogService;
using Hospital.Interface.Select;
using Hospital.Model;
using System.Collections.ObjectModel;

namespace Hospital.ViewModel
{
    public class MedicalHistoryVM:ViewModelBase
    {
        private readonly IDialogService _dialogService;
        private readonly ISelectData _selectData;
        

        public MedicalHistoryVM(IDialogService dialogService,
                                ISelectData selectData,
                                int userId)
        {
            _dialogService = dialogService;
            _selectData = selectData;
            History = new ObservableCollection<History>();
        }

        private void Load(int userId)
        {
            var medcard = _selectData.GetMedCard(userId);
            var result = _selectData.GetHistory(medcard.CardId);
            foreach (var res in result)
            {
                History.Add(res);
            }
        }

        public ObservableCollection<History> History { get; set; }
    }
}
