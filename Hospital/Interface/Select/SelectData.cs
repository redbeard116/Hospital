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

        public List<History> GetHistory(int medCardId)
        {
            var result = db.OutpatentCards.Where(w=>w.MedCardId == medCardId);
            var historyes = new List<History>();
            foreach(var res in result)
            {
                var staff = db.Appointments.Find(res.Data);
                var userId = db.Staffs.Find(staff.DoctorId).UserId;
                var user = db.Users.Find(userId);
                historyes.Add(new History
                {
                    Diagnoz = res.Diagnoz,
                    Doctor = $"{user.FirstName} {user.SecondName}",
                    Description = staff.Description,
                    Data = res.Data
                });
            }
            return historyes;
        }

        public MedCard GetMedCard(int userId)
        {
            var med = db.MedCards.FirstOrDefault(w=>w.UserId == userId);
            if (med != null)
                return med;
            else
                return null;
        }

        public List<SheduleM> GetShedule(int medCardId)
        {
            var result = db.Appointments.Where(w => w.MedCardId == medCardId).ToList();
            var shedules = new List<SheduleM>();
            foreach(var res in result.OrderByDescending(w=>w.AppointmentId))
            {
                var userId = db.Staffs.Find(res.DoctorId).UserId;
                var user = db.Users.Find(userId);
                shedules.Add(new SheduleM
                {
                    Data = res.Data,
                    Doctor = $"{user.FirstName} {user.SecondName}"
                });
            }
            return shedules;
        }
    }
}
