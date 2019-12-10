using System;
using Hospital.Model;
using Hospital.DB;

namespace Hospital.Interface.Insert
{
    public class InsertData : IInsertData
    {
        private DBHospitalContext db = new DBHospitalContext();

        public void AppointData(Appointment appoitment)
        {
            db.Appointments.Add(appoitment);
            db.SaveChanges();
        }

        public void InsertMedCart(MedCard medcard)
        {
            db.MedCards.Add(medcard);
            db.SaveChanges();
        }

        public void InsertOutpatent(OutpatentCard outpatent)
        {
            db.OutpatentCards.Add(outpatent);
            db.SaveChanges();
        }

        public int Registration(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user.UserId;
        }

        public void SetAuthData(AuthM auth)
        {
            db.AuthMs.Add(auth);
            db.SaveChanges();
        }

        public int AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user.UserId;
        }

        public void AddAuthData(AuthM auth)
        {
            db.AuthMs.Add(auth);
            db.SaveChanges();
        }

        public void AddStaff(Staff staff)
        {
            db.Staffs.Add(staff);
            db.SaveChanges();
        }
    }
}
