using System;
using Hospital.Model;
using Hospital.DB;

namespace Hospital.Interface.Update
{
    public class UpdateData : IUpdateData
    {
        private DBHospitalContext db = new DBHospitalContext();

        public void UpdateProfile(User user)
        {
            var res = db.Users.Find(user.UserId);
            res.FirstName = user.FirstName;
            res.SecondName = user.SecondName;
            res.Email = user.Email;
            db.SaveChanges();
        }
    }
}
