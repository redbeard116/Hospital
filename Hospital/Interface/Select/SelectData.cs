using Hospital.DB;
using System.Linq;
using Hospital.Model;
using System.Collections.Generic;
using System;

namespace Hospital.Interface.Select
{
    public class SelectData : ISelectData
    {
        private DBHospitalContext db = new DBHospitalContext();

        public bool Auth(string login, string password,out User user)
        {
            var userId = db.AuthMs.FirstOrDefault(w => w.Login == login && w.Password == password).UserId;
            user = db.Users.FirstOrDefault(w=>w.UserId == userId);
            return userId != 0 ? true : false;
        }

        public int GetAppointDoctor(int positionId)
        {
            var count = db.Staffs.Where(w=>w.PositionId == positionId).Count();
            return count;
        }

        public List<Position> GetDoctors()
        {
            return db.Positions.ToList();
        }

        public int GetMedCard(int userId)
        {
            var med = db.MedCards.FirstOrDefault(w=>w.UserId == userId);
            if (med != null)
                return med.CardId;
            else
                return 0;
        }
    }
}
