using Hospital.Model;
using System.Collections.Generic;

namespace Hospital.Interface.Select
{
    public interface ISelectData
    {
        bool Auth(string login, string password, out User user);
        int GetMedCard(int userId);
        List<Position> GetDoctors();
        int GetAppointDoctor(int positionId);
    }
}
