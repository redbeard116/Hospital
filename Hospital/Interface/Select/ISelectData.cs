using Hospital.Model;

namespace Hospital.Interface.Select
{
    public interface ISelectData
    {
        bool Auth(string login, string password, out User user);
    }
}
