using Hospital.Command;
using Hospital.Interface.Update;
using Hospital.Model;
using System.Windows;

namespace Hospital.ViewModel
{
    public class EditProfileVM:ViewModelBase
    {
        private readonly IUpdateData _updateData;

        public EditProfileVM(IUpdateData updateData,
                             User user)
        {
            _updateData = updateData;
            User = user;
        }

        public User User { get; set; }

        public RelayCommand EditProfileCmd => new RelayCommand(EditProfile);

        private void EditProfile(object obj)
        {
            _updateData.UpdateProfile(User);
            if(obj is Window view)
            {
                view.Close();
            }
        }
    }
}
