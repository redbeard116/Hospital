using Hospital.DB;
using System.Linq;
using Hospital.Model;

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
    }
}
