using Hospital.Model;

namespace Hospital.Interface.Insert
{
    public interface IInsertData
    {
        void InsertMedCart(MedCard medcard);
        void AppointData(Appointment appoitment);
        int Registration(User user);
        void SetAuthData(AuthM auth);
        void InsertOutpatent(OutpatentCard outpatent);
    }
}
