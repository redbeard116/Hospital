using Hospital.Command;
using Hospital.Interface.Select;
using Hospital.Model;
using System.Windows;
using System.Collections.ObjectModel;
using Hospital.Interface.Insert;
using System;

namespace Hospital.ViewModel
{
    public class StatementVM:ViewModelBase
    {
        private readonly IInsertData _insertData;
        private readonly ISelectData _selectData;
        private readonly User User;

        private User _user;

        public StatementVM(IInsertData insertData,
                           ISelectData selectData,
                           User user)
        {
            _insertData = insertData;
            _selectData = selectData;
            User = user;
            Load();
        }

        private void Load()
        {
            Users = new ObservableCollection<User>();
            var result = _selectData.GetPatient(User.UserId);
            foreach (var res in result)
                Users.Add(res);
        }

        public ObservableCollection<User> Users { get; set; }
        public User SelectedUser
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }
        public string Diagnoz { get; set; }


        public RelayCommand StatementCmd => new RelayCommand(Statement);

        private void Statement(object obj)
        {
            var outpatent = new OutpatentCard
            {
                Data = DateTime.Now.ToString(),
                MedCardId = _selectData.GetMedCard(SelectedUser.UserId).CardId,
                Diagnoz = Diagnoz
            };
            _insertData.InsertOutpatent(outpatent);
            if (obj is Window view)
            {
                view.Close();
            }
        }
    }
}
