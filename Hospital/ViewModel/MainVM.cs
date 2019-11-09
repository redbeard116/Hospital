using System;
using Hospital.Command;

namespace Hospital.ViewModel
{
    public class MainVM:ViewModelBase
    {
        public RelayCommand AuthorizationCmd => new RelayCommand(Authorization);

        private static void Authorization(object obj)
        {
            
        }

        public RelayCommand AppointmentCmd => new RelayCommand(Appointment);

        private static void Appointment(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
