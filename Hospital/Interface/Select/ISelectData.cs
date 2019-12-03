using Hospital.Model;
using System.Collections.Generic;

namespace Hospital.Interface.Select
{
    public interface ISelectData
    {
        bool Auth(string login, string password, out User user);
        MedCard GetMedCard(int userId);
        List<Position> GetDoctors();
        int GetAppointDoctor(int positionId);
        List<History> GetHistory(int medCardId);
        List<SheduleM> GetShedule(int medCardId);
    }
}
