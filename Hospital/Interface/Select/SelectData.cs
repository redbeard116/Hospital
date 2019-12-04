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

        public bool Auth(string login, string password, out User user)
        {
            var userId = db.AuthMs.FirstOrDefault(w => w.Login == login && w.Password == password).UserId;
            user = db.Users.FirstOrDefault(w => w.UserId == userId);
            return userId != 0 ? true : false;
        }

        public int GetAppointDoctor(int positionId)
        {
            var doctors = db.Staffs.Where(w => w.PositionId == positionId).ToList();
            int doctorId = 0;
            int minCount = 0;
            foreach(var doctor in doctors)
            {
                var count = GetAppCount(doctor.UserId);
                if (count < minCount)
                {
                    minCount = count;
                    doctorId = doctor.UserId;
                }
            }
            return doctorId;
        }
        private int GetAppCount(int doctorId)
        {
            return db.Appointments.Where(w => w.DoctorId == doctorId).Count();
        }

        public List<Position> GetDoctors()
        {
            return db.Positions.ToList();
        }

        public List<History> GetHistory(int medCardId)
        {
            var result = db.OutpatentCards.Where(w => w.MedCardId == medCardId);
            var historyes = new List<History>();
            foreach (var res in result)
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
            var med = db.MedCards.FirstOrDefault(w => w.UserId == userId);
            if (med != null)
                return med;
            else
                return null;
        }

        public List<User> GetPatient(int doctorId)
        {
            var result = db.Appointments.Where(w => w.DoctorId == doctorId).ToList();
            var users = new List<User>();
            foreach (var res in result)
            {
                DateTime.TryParse(res.Data, out DateTime time);
                if (time > DateTime.Now)
                {
                    var user = db.MedCards.FirstOrDefault(w=>w.CardId == res.MedCardId);
                    users.Add(db.Users.Find(user.UserId));
                }
            }
            return users;
        }

        public List<SheduleM> GetShedule(int medCardId)
        {
            var result = db.Appointments.Where(w => w.MedCardId == medCardId).ToList();
            var shedules = new List<SheduleM>();
            foreach (var res in result.OrderByDescending(w => w.AppointmentId))
            {
                DateTime.TryParse(res.Data, out DateTime time);
                if (time > DateTime.Now)
                {
                    var userId = db.Staffs.Find(res.DoctorId).UserId;
                    var user = db.Users.Find(userId);
                    shedules.Add(new SheduleM
                    {
                        Data = res.Data,
                        User = $"{user.FirstName} {user.SecondName}"
                    });
                }
            }
            return shedules;
        }

        public List<SheduleM> GetStaffShedule(int userId)
        {
            var result = db.Appointments.Where(w => w.DoctorId == userId).ToList();
            var shedules = new List<SheduleM>();
            foreach (var res in result.OrderByDescending(w => w.AppointmentId))
            {
                DateTime.TryParse(res.Data, out DateTime time);
                if (time > DateTime.Now)
                {
                    var userid = db.MedCards.FirstOrDefault(w=>w.CardId == res.MedCardId).UserId;
                    var user = db.Users.Find(userid);
                    shedules.Add(new SheduleM
                    {
                        Data = res.Data,
                        User = $"{user.FirstName} {user.SecondName}",
                        Description = res.Description
                    });
                }
            }
            return shedules;
        }

        public bool IsStaff(int userId)
        {
            return db.Staffs.FirstOrDefault(w => w.UserId == userId) != null ? true : false;
        }
    }
}
